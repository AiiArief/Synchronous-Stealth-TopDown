using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseProcessInput : MonoBehaviour
{
    [SerializeField] bool m_debugMode = false;

    [SerializeField] float m_minimumTimeBeforeNextPhase = 0.25f;
    public float minimumTimeBeforeNextPhase { get { return m_minimumTimeBeforeNextPhase; } }
    public float currentTimeBeforeNextPhase { get; private set; } = 0.0f;

    public void ActivateProcessInput()
    {
        gameObject.SetActive(true);

        currentTimeBeforeNextPhase = 0.0f;
        GameManager.Instance.playerManager.SetupEntitiesOnProcessInputStart();
        GameManager.Instance.npcManager.SetupEntitiesOnProcessInputStart();
        GameManager.Instance.eventManager.SetupEntitiesOnProcessInputStart();
    }

    public void UpdateProcessInput()
    {
        bool playerManagerHasDoneProcess = GameManager.Instance.playerManager.CheckEntitiesHasDoneProcessInput();
        bool enemyManagerHasDoneProcess = GameManager.Instance.npcManager.CheckEntitiesHasDoneProcessInput();
        bool eventManagerHasDoneProcess = GameManager.Instance.eventManager.CheckEntitiesHasDoneProcessInput();

        currentTimeBeforeNextPhase += Time.deltaTime;
        bool timeHasPassed = currentTimeBeforeNextPhase >= m_minimumTimeBeforeNextPhase;

        if(m_debugMode && timeHasPassed)
        {
            GameManager.Instance.playerManager.DebugProcessInputCheckEntitiesHasDone();
            GameManager.Instance.npcManager.DebugProcessInputCheckEntitiesHasDone();
            GameManager.Instance.eventManager.DebugProcessInputCheckEntitiesHasDone();
        }

        if (timeHasPassed && playerManagerHasDoneProcess && enemyManagerHasDoneProcess && eventManagerHasDoneProcess)
        {
            GameManager.Instance.phaseManager.SetPhase(PhaseEnum.AfterInput);
        }
    }
}
