using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

#region Dialogue Classes
public class Dialogue
{
    public string nameStr;
    public string dialogueStr;
    public VoicePack voice;

    public Dialogue(string nameStr, string dialogueStr, VoicePack voice = null)
    {
        this.nameStr = nameStr;
        this.dialogueStr = dialogueStr;
        this.voice = voice;
    }

    public Dialogue(LocalizationString nameStr, LocalizationString dialogueStr, VoicePack voice = null)
    {
        this.nameStr = LocalizationManager.Translate(nameStr);
        this.dialogueStr = LocalizationManager.Translate(dialogueStr);
        this.voice = voice;
    }

    public Dialogue(string nameStr, LocalizationString dialogueStr, VoicePack voice = null)
    {
        this.nameStr = nameStr;
        this.dialogueStr = LocalizationManager.Translate(dialogueStr);
        this.voice = voice;
    }

    public Dialogue(LocalizationString nameStr, string dialogueStr, VoicePack voice = null)
    {
        this.nameStr = LocalizationManager.Translate(nameStr);
        this.dialogueStr = dialogueStr;
        this.voice = voice;
    }
}

public class DialogueChoice
{
    public string choiceDialogueStr;
    public Action choiceButtonAction;

    public DialogueChoice(string choiceDialogueStr, Action choiceButtonAction)
    {
        this.choiceDialogueStr = choiceDialogueStr;
        this.choiceButtonAction = choiceButtonAction;
    }

    public DialogueChoice(LocalizationString choiceDialogueStr, Action choiceButtonAction)
    {
        this.choiceDialogueStr = LocalizationManager.Translate(choiceDialogueStr);
        this.choiceButtonAction = choiceButtonAction;
    }
}
#endregion

#region Tutorial Classes
public enum TutorialType
{
    Shoot, MoveMod, Move, None
}

public enum TutorialPlatform
{
    PC, XBOX, NSwitch
}

public class Tutorial
{
    public TutorialType tutorialType { get; private set; }
    public LocalizationString locString { get; private set; }

    public Tutorial(TutorialType tutorialType, LocalizationString locString)
    {
        this.tutorialType = tutorialType;
        this.locString = locString;
    }
}

[System.Serializable]
public class UITutorialObject
{
    [SerializeField] Animator tutorialAnimator;
    [SerializeField] Text tutorialText;
    public GameObject GetParent() { return tutorialAnimator.transform.parent.gameObject; }

    public void DisableTutorial()
    {
        tutorialAnimator.gameObject.SetActive(false);
    }

    public void ActivateTutorial(Tutorial tutorial, bool instantActive = true)
    {
        if (instantActive) tutorialAnimator.gameObject.SetActive(true);

        tutorialAnimator.SetInteger("type", (int)tutorial.tutorialType);
        //tutorialAnimator.SetInteger("platform", 0); // ngurus platform gmana ya
        tutorialText.text = LocalizationManager.Translate(tutorial.locString);
    }
}
#endregion

public class UIManager : MonoBehaviour
{
    [SerializeField] Animator m_transition;

    [Header("UI Dialogue")]
    [SerializeField] RectTransform m_uiDialogue;
    [SerializeField] Text m_dialogueNameText;
    [SerializeField] Text m_dialogueText;
    [SerializeField] float m_textSpeed = 0.25f;

    [SerializeField] RectTransform m_choiceButtons;
    DialogueChoice[] m_choiceButtonActions;

    [Header("UI Tutorial")]
    [SerializeField] RectTransform m_uiTutorial;
    [SerializeField] UITutorialObject[] m_notificationTutorialObjects;
    [SerializeField] UITutorialObject m_dialogueTutorialObject;
    [SerializeField] UITutorialObject[] m_choiceTutorialObjects;

    List<Action> m_uiActions = new List<Action>();
    List<Tutorial> m_tutorialQueue = new List<Tutorial>();

    Coroutine m_uiTutorialCoroutine;

    public void AddUIAction(Action action)
    {
        if (m_uiActions.Count <= 0)
        {
            action.Invoke();
        }

        m_uiActions.Add(action);
    }

    public void ClearUIAction()
    {
        if (m_uiActions.Count == 0)
            return;

        m_uiActions.Clear();
        m_uiActions.Add(() => StartCoroutine(DelayUntilPhaseInput(PhaseEnum.AfterInput)));
    }

    #region UI Dialogue
    public void ChoiceButton(int choiceId)
    {
        m_choiceButtonActions[choiceId].choiceButtonAction.Invoke();
        m_uiDialogue.gameObject.SetActive(false);
        NextAction();
    }

    public IEnumerator AnimateTransition(string animation = "fade", float waitTime = 1.0f)
    {
        m_transition.SetTrigger(animation);
        yield return new WaitForSecondsRealtime(waitTime);
        NextAction();
    }

    public IEnumerator DelayNextAction(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        NextAction();
    }

    public IEnumerator DelayUntilPhaseInput(PhaseEnum phase)
    {
        while (GameManager.Instance.phaseManager.currentPhase != phase)
            yield return new WaitForEndOfFrame();

        NextAction();
    }

    bool isSkipFlag;
    Coroutine skipCoroutine;
    public IEnumerator AddDialogue(Dialogue dialogue, DialogueChoice[] buttonActions = null)
    {
        m_uiDialogue.gameObject.SetActive(true);
        m_dialogueTutorialObject.DisableTutorial();

        m_dialogueNameText.text = (dialogue.nameStr == null) ? "" : dialogue.nameStr;

        m_choiceButtons.gameObject.SetActive(false);
        m_choiceButtonActions = buttonActions;
        for (int i = 0; i < m_choiceButtons.childCount; i++)
        {
            m_choiceButtons.GetChild(i).gameObject.SetActive(false);
        }

        skipCoroutine = StartCoroutine(_HandleSkipText());
        isSkipFlag = false;

        int strIndex = 0;
        string str = "";
        string strComplete = dialogue.dialogueStr;
        while (strIndex < strComplete.Length)
        {
            str += strComplete[strIndex++];
            m_dialogueText.text = str;

            if (dialogue.voice)
                dialogue.voice.TextToSpeech(str[str.Length - 1]);

            if (isSkipFlag)
            {
                m_dialogueText.text = strComplete;
                strIndex = strComplete.Length;
            }

            yield return new WaitForSecondsRealtime(m_textSpeed * Time.deltaTime);
        }

        isSkipFlag = true;
        StopCoroutine(skipCoroutine);

        if (buttonActions == null)
        {
            m_dialogueTutorialObject.ActivateTutorial(new Tutorial(TutorialType.Shoot, LocalizationManager.TUTORIAL_NEXT));

            while (true)
            {
                if (Input.GetButtonDown("Shoot #0"))
                    break;

                yield return null;
            }

            m_uiDialogue.gameObject.SetActive(false);
            NextAction();
        }
        else
        {
            m_choiceButtons.gameObject.SetActive(true);
            for (int i = 0; i < buttonActions.Length; i++)
            {
                Button childButton = m_choiceButtons.GetChild(i).GetComponent<Button>();
                childButton.gameObject.SetActive(true);
                childButton.GetComponentInChildren<Text>().text = buttonActions[i].choiceDialogueStr;
            }

            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(m_choiceButtons.GetChild(0).gameObject);
            foreach (UITutorialObject choiceTutorialObject in m_choiceTutorialObjects)
            {
                choiceTutorialObject.ActivateTutorial(new Tutorial(TutorialType.Shoot, LocalizationManager.TUTORIAL_SELECT), false);
            }
        }
    }

    public void NextAction()
    {
        m_uiActions.RemoveAt(0);

        if (m_uiActions.Count > 0)
        {
            m_uiActions[0].Invoke();
        }
    }

    private IEnumerator _HandleSkipText()
    {
        while (true)
        {
            if (Input.GetButtonDown("Shoot #0") && !isSkipFlag)
            {
                isSkipFlag = true;

                yield return new WaitForSecondsRealtime(m_textSpeed / 5 * Time.deltaTime);
            }

            yield return null;
        }
    }
    #endregion

    #region UI Tutorial
    public void AddTutorial(Tutorial tutorial, float autoDestroyTime = -1.0f)
    {
        m_tutorialQueue.Add(tutorial);

        if (m_uiTutorialCoroutine == null)
            m_uiTutorialCoroutine = StartCoroutine(_HandleUITutorial());

        if (autoDestroyTime > 0.0f)
            StartCoroutine(RemoveTutorial(tutorial, autoDestroyTime));
    }

    public IEnumerator RemoveTutorial(Tutorial tutorial, float destroyTime = 0.5f)
    {
        yield return new WaitForSeconds(destroyTime);
        m_notificationTutorialObjects[m_tutorialQueue.IndexOf(tutorial)].GetParent().GetComponent<Animator>().SetTrigger("exit");
        yield return new WaitForSeconds(0.5f);
        yield return new WaitForEndOfFrame();
        m_notificationTutorialObjects[m_tutorialQueue.IndexOf(tutorial)].GetParent().SetActive(false);
        m_tutorialQueue.Remove(tutorial);
    }

    private IEnumerator _HandleUITutorial()
    {
        while (true)
        {
            m_uiTutorial.gameObject.SetActive(m_tutorialQueue.Count > 0);
            if(m_tutorialQueue.Count > 0)
            {
                for (int i = 0; i < m_notificationTutorialObjects.Length; i++)
                {
                    bool isActive = i < m_tutorialQueue.Count;
                    m_notificationTutorialObjects[i].GetParent().SetActive(isActive);
                    if (isActive)
                        m_notificationTutorialObjects[i].ActivateTutorial(m_tutorialQueue[i]);
                    else
                        m_notificationTutorialObjects[i].DisableTutorial();
                }
            }

            yield return new WaitForEndOfFrame();
        }
    }

    #endregion
}
