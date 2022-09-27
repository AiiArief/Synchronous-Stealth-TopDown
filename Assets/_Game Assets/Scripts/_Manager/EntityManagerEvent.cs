using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntityManagerEvent : EntityManager
{
    [SerializeField] EntityEvent_Generic m_genericEvent;
    public EntityEvent_Generic genericEvent { get { return m_genericEvent; } }

    [SerializeField] Transform m_triggerEventParent;
    public TriggerEvent[] memoryTriggerEvents { get; private set; }
    public TriggerEvent[] diaryTriggerEvents { get; private set; }

    [SerializeField] Transform m_triggerCheckpointsParent;
    public TriggerCheckpoint[] triggerCheckpoints { get; private set; }
    public int currentcheckpoint { get; private set; } = 0;

    [SerializeField] EntityLevelFX m_levelFX;

    public List<Action> afterInputActionList { get; private set; } = new List<Action>();

    public override void SetupEntitiesOnLevelStart()
    {
        base.SetupEntitiesOnLevelStart();
        
        currentcheckpoint = PlayerPrefs.GetInt(ProfileManager.PLAYERPREFS_CURRENTSCENECHECKPOINT, 0);
        _AssignAllEventAndCheckpointTriggers();
        _RefreshAllEventTriggers();
        _RefreshAllCheckpoints();

        m_genericEvent.EventOnLoadLevel();
        _ExecuteFirstAction();

        m_levelFX.FXOnLoadLevel();
    }

    public override void SetupEntitiesOnAfterInputStart()
    {
        base.SetupEntitiesOnAfterInputStart();
        _ExecuteFirstAction();
    }

    public bool ChangeCheckpoint(int checkpoint)
    {
        if (currentcheckpoint == checkpoint)
            return false;

        currentcheckpoint = checkpoint;
        PlayerPrefs.SetInt(ProfileManager.PLAYERPREFS_CURRENTSCENECHECKPOINT, checkpoint);
        _RefreshAllCheckpoints();

        m_genericEvent.CheckpointEvent();

        return true;
    }

    private void _ExecuteFirstAction()
    {
        if(afterInputActionList.Count > 0)
        {
            afterInputActionList[0].Invoke();
            afterInputActionList.RemoveAt(0);
        }
    }

    private void _AssignAllEventAndCheckpointTriggers()
    {
        var memoryTriggersParent = m_triggerEventParent.Find("Memory Triggers");
        memoryTriggerEvents = new TriggerEvent[memoryTriggersParent.childCount];
        for (int i = 0; i < memoryTriggerEvents.Length; i++)
        {
            memoryTriggerEvents[i] = memoryTriggersParent.GetChild(i).GetComponent<TriggerEvent>();
        }

        var diaryTriggersParent = m_triggerEventParent.Find("Diary Triggers");
        diaryTriggerEvents = new TriggerEvent[diaryTriggersParent.childCount];
        for (int i = 0; i < diaryTriggerEvents.Length; i++)
        {
            diaryTriggerEvents[i] = diaryTriggersParent.GetChild(i).GetComponent<TriggerEvent>();
        }

        triggerCheckpoints = new TriggerCheckpoint[m_triggerCheckpointsParent.childCount];
        for(int i=0; i<triggerCheckpoints.Length; i++)
        {
            triggerCheckpoints[i] = m_triggerCheckpointsParent.GetChild(i).GetComponent<TriggerCheckpoint>();
        }
    }

    private void _RefreshAllEventTriggers()
    {
        for (int i = 0; i < memoryTriggerEvents.Length; i++)
        {
            string key = ProfileManager.PLAYERPREFS_HAVEPASSWORD + "_" + SceneManager.GetActiveScene().name + "_" + (memoryTriggerEvents[i].eventTriggerId + 1);
            bool isAvailable = PlayerPrefs.GetString(key, false.ToString()) == false.ToString();
            memoryTriggerEvents[i].SetIsAvailable(isAvailable, 0.0f);
        }

        for (int i = 0; i < diaryTriggerEvents.Length; i++)
        {
            string key = ProfileManager.PLAYERPREFS_HAVEDIARY + "_" + SceneManager.GetActiveScene().name + "_" + (diaryTriggerEvents[i].eventTriggerId + 1);
            bool isAvailable = PlayerPrefs.GetString(key, false.ToString()) == false.ToString();
            diaryTriggerEvents[i].SetIsAvailable(isAvailable, 0.0f);
        }
    }

    private void _RefreshAllCheckpoints()
    {
        for(int i=0; i<triggerCheckpoints.Length; i++)
        {
            triggerCheckpoints[i].SetIsCheckpointHere(currentcheckpoint == triggerCheckpoints[i].checkpointId);
        }
    }
}
