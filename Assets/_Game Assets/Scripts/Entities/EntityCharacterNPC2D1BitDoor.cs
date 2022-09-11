using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorType
{
    AlwaysOn,
    NeedPassword,
    NeedPassword2,
    SwitchControlled,
    AlwaysDead,
    SwitchPassword
}

public class PasswordChoice
{
    public int trueAnswer { get; private set; }
    public LocalizationString[] choiceStrings { get; private set; }
    public Dialogue hintDialogue { get; private set; }
    public bool revealAnswer { get; private set; }

    public PasswordChoice(int trueAnswer, string[] choiceStrings, Dialogue hintDialogue, bool revealAnswer = false)
    {
        this.trueAnswer = trueAnswer;
        this.choiceStrings = _ConvertArrayStringToLocalizationString(choiceStrings);
        this.hintDialogue = hintDialogue;
        this.revealAnswer = revealAnswer;
    }

    public PasswordChoice(int trueAnswer, LocalizationString[] choiceStrings, Dialogue hintDialogue, bool revealAnswer = false)
    {
        this.trueAnswer = trueAnswer;
        this.choiceStrings = choiceStrings;
        this.hintDialogue = hintDialogue;
        this.revealAnswer = revealAnswer;
    }

    private LocalizationString[] _ConvertArrayStringToLocalizationString(string[] choiceStrings)
    {
        LocalizationString[] locStrs = new LocalizationString[choiceStrings.Length];
        for (int i = 0; i < choiceStrings.Length; i++)
        {
            locStrs[i] = new LocalizationString(choiceStrings[i], choiceStrings[i]);
        }

        return locStrs;
    }
}

public class EntityCharacterNPC2D1BitDoor : EntityCharacterNPC2D1Bit
{
    [SerializeField] bool m_currentIsClosed = true;
    public bool currentIsClosed { get { return m_currentIsClosed; } }

    [SerializeField] EntityCharacterNPC2D1BitDoor[] m_connectedDoors;

    BoxCollider m_doorCollider;
    TagEntityUnpassable m_doorUnpassable;
    TagEntityInteractable m_doorInteractable;

    [Header("For Line Renderer")]
    [SerializeField] DoorType m_doorType = DoorType.AlwaysOn;
    [SerializeField] int m_doorTypePassword_eventId = -1;
    [SerializeField] EntityCharacterNPC2D1BitSwitch[] m_doorTypeControlled_switchs;

    public override void WaitInput()
    {
        base.WaitInput();

        _UpdateLineRenderer();
        _DoIdle();
    }

    public override void AfterInput()
    {
        base.AfterInput();

        afterActionHasDone = true;
    }

    public void SetDoorIsClosed(bool isClosed) { SetDoorIsClosed(isClosed, true, true); }
    public void SetDoorIsClosed(bool isClosed, bool callConnectedDoorToo, bool callControlledSwitchToo)
    {
        m_currentIsClosed = isClosed;

        animator.SetBool("currentIsClosed", currentIsClosed);

        StartCoroutine(_HandleDoorCollider(isClosed));

        if (callControlledSwitchToo)
        {
            foreach (EntityCharacterNPC2D1BitSwitch sw in m_doorTypeControlled_switchs)
            {
                sw.SetCurrentIsOn(!isClosed);
            }
        }

        if (callConnectedDoorToo)
        {
            foreach (EntityCharacterNPC2D1BitDoor door in m_connectedDoors)
            {
                door.SetDoorIsClosed(isClosed, false, false);
            }
        }
    }

    [HideInInspector] int[] m_playerAnswer;
    [HideInInspector] int m_currentPasswordIndex;
    public void EnterPassword(PasswordChoice[] passwordChoices, Action trueAction, Action wrongAction)
    {
        m_playerAnswer = new int[passwordChoices.Length];
        m_currentPasswordIndex = 0;
        _EnterPasswordRecursive(passwordChoices, trueAction, wrongAction);
    }

    public bool CheckPasswordWithKey(string key)
    {
        bool isTrue = PlayerPrefs.GetString(key, false.ToString()) == true.ToString();

        return isTrue;
    }

    protected override void _AssignComponent()
    {
        base._AssignComponent();
        m_doorCollider = GetComponent<BoxCollider>();
        m_doorUnpassable = GetComponent<TagEntityUnpassable>();
        m_doorInteractable = GetComponent<TagEntityInteractable>();

        SetDoorIsClosed(currentIsClosed, false, false);
        SetExpression(m_startExpression);
    }

    private void _UpdateLineRenderer()
    {
        animator.speed = 1;
        switch (m_doorType)
        {
            case DoorType.AlwaysOn:
                animator.SetBool("currentLineIsOn", true);
                break;
            case DoorType.AlwaysDead:
                animator.SetBool("currentLineIsOn", false);
                break;
            case DoorType.NeedPassword2:
                animator.SetTrigger("RGB");
                break;
            case DoorType.NeedPassword:
                string key = ProfileManager.PLAYERPREFS_HAVEPASSWORD + "_" + UnityEngine.SceneManagement.SceneManager.GetActiveScene().name + "_" + m_doorTypePassword_eventId;
                animator.SetBool("currentLineIsOn", PlayerPrefs.GetString(key, false.ToString()) == true.ToString());
                break;
            case DoorType.SwitchControlled:
                bool currentIsOn = false;
                for (int i = 0; i < m_doorTypeControlled_switchs.Length; i++)
                    if (m_doorTypeControlled_switchs[i].currentIsOn)
                    {
                        currentIsOn = true;
                        break;
                    }

                animator.SetBool("currentLineIsOn", currentIsOn);
                break;
            case DoorType.SwitchPassword:
                string key2 = ProfileManager.PLAYERPREFS_HAVEPASSWORD + "_" + UnityEngine.SceneManagement.SceneManager.GetActiveScene().name + "_" + m_doorTypePassword_eventId;
                bool currentIsOn2 = PlayerPrefs.GetString(key2, false.ToString()) == true.ToString();
                if (!currentIsOn2)
                {
                    for (int i = 0; i < m_doorTypeControlled_switchs.Length; i++)
                        if (m_doorTypeControlled_switchs[i].currentIsOn)
                        {
                            currentIsOn2 = true;
                            break;
                        }
                }

                animator.SetBool("currentLineIsOn", currentIsOn2);
                break;
        }
    }

    private void _EnterPasswordRecursive(PasswordChoice[] passwordChoices, Action trueAction, Action wrongAction)
    {
        UIManager um = GameManager.Instance.uiManager;
        PasswordChoice cPC = passwordChoices[m_currentPasswordIndex];
        string dialogueStr = cPC.hintDialogue.dialogueStr + ((cPC.revealAnswer) ? "\n(" + LocalizationManager.Translate(LocalizationManager.GENERIC_THE_ANSWER_IS) + LocalizationManager.Translate(cPC.choiceStrings[cPC.trueAnswer]) + ".)" : "");

        um.AddUIAction(() => StartCoroutine(um.AddDialogue(new Dialogue(cPC.hintDialogue.nameStr, dialogueStr, cPC.hintDialogue.voice),
        new DialogueChoice[3] {
                new DialogueChoice(cPC.choiceStrings[0], () => {
                    m_playerAnswer[m_currentPasswordIndex] = 0;
                    if(m_currentPasswordIndex+1 >= passwordChoices.Length)
                    {
                        _CheckPassword(passwordChoices, trueAction, wrongAction);
                    } else
                    {
                        m_currentPasswordIndex++;
                        _EnterPasswordRecursive(passwordChoices, trueAction, wrongAction);
                    }
                }),
                new DialogueChoice(cPC.choiceStrings[1], () => {
                    m_playerAnswer[m_currentPasswordIndex] = 1;
                    if(m_currentPasswordIndex+1 >= passwordChoices.Length)
                    {
                        _CheckPassword(passwordChoices, trueAction, wrongAction);
                    } else
                    {
                        m_currentPasswordIndex++;
                        _EnterPasswordRecursive(passwordChoices, trueAction, wrongAction);
                    }
                }),
                new DialogueChoice(cPC.choiceStrings[2], () => {
                    m_playerAnswer[m_currentPasswordIndex] = 2;
                    if(m_currentPasswordIndex+1 >= passwordChoices.Length)
                    {
                        _CheckPassword(passwordChoices, trueAction, wrongAction);
                    } else
                    {
                        m_currentPasswordIndex++;
                        _EnterPasswordRecursive(passwordChoices, trueAction, wrongAction);
                    }
                }),
            })));
    }

    private void _CheckPassword(PasswordChoice[] passwordChoices, Action trueAction, Action wrongAction)
    {
        bool answerIsTrue = true;
        for (int j = 0; j < passwordChoices.Length; j++)
        {
            if (m_playerAnswer[j] != passwordChoices[j].trueAnswer)
            {
                answerIsTrue = false;
                break;
            }
        }

        _HandleCheckSound(answerIsTrue);
        if (answerIsTrue) trueAction.Invoke();
        else wrongAction.Invoke();
    }

    private void _HandleCheckSound(bool answerIsTrue)
    {
        var dm = GlobalGameManager.Instance.databaseManager;
        GetComponent<AudioSource>().PlayOneShot((answerIsTrue) ? dm.passwordTrue : dm.passwordWrong);
    }

    private IEnumerator _HandleDoorCollider(bool isClosed)
    {
        if(!isClosed)
        {
            m_doorCollider.enabled = isClosed;
            m_doorUnpassable.enabled = isClosed;
            m_doorInteractable.enabled = isClosed;
            yield return null;
        } else
        {
            yield return new WaitForSeconds(GameManager.Instance.phaseManager.processInput.minimumTimeBeforeNextPhase);

            m_doorCollider.enabled = isClosed;
            m_doorUnpassable.enabled = isClosed;
            m_doorInteractable.enabled = isClosed;
        }
    }
}
