using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] PhaseManager m_phaseManager;
    public PhaseManager phaseManager { get { return m_phaseManager; } }

    [SerializeField] EntityManagerPlayer m_playerManager;
    public EntityManagerPlayer playerManager { get { return m_playerManager; } }

    [SerializeField] EntityManagerNPC m_npcManager;
    public EntityManagerNPC npcManager { get { return m_npcManager; } }

    [SerializeField] EntityManagerEvent m_eventManager;
    public EntityManagerEvent eventManager { get { return m_eventManager; } }

    [SerializeField] LevelManager m_levelManager;
    public LevelManager levelManager { get { return m_levelManager; } }

    [SerializeField] UIManager m_uiManager;
    public UIManager uiManager { get { return m_uiManager; } }

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        m_levelManager.SetupAllGridsOnLevelStart();
        m_playerManager.SetupEntitiesOnLevelStart();
        m_npcManager.SetupEntitiesOnLevelStart();
        m_eventManager.SetupEntitiesOnLevelStart();
        m_phaseManager.SetPhase(PhaseEnum.WaitInput);
    }

    private void Update()
    {
        if (m_phaseManager.currentPhase != PhaseEnum.None)
            m_phaseManager.UpdateCurrentPhase();
    }
}
