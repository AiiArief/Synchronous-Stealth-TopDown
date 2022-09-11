using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearAlert : MonoBehaviour
{
    EntityCharacterNPC3DBot m_bot;
    bool m_hasBeenSetup = false;

    public TagFootStepSource closestFootStepSource { get; private set; }
    public Vector3 lastTargetPos { get; private set; }

    public void SetupHearAlertWaitInput(EntityCharacterNPC3DBot bot)
    {
        if (!m_hasBeenSetup)
        {
            m_hasBeenSetup = true;
            m_bot = bot;
        }
    }

    public void HandleHearAlertAfterInput()
    {
        // bedain suara dari npc sama suara dari player ??
        Transform stepSoundsParent = GameManager.Instance.levelManager.stepSoundEffectParent;
        float closestDistance = Mathf.Infinity;
        closestFootStepSource = null;
        foreach(Transform child in stepSoundsParent)
        {
            TagFootStepSource footStepSource = child.GetComponent<TagFootStepSource>();
            float distance = Vector3.Distance(transform.position, child.position);
            if(footStepSource && distance < footStepSource.GenerateMaxSize())
            {
                if(distance < closestDistance)
                {
                    closestDistance = distance;
                    closestFootStepSource = footStepSource;
                    lastTargetPos = footStepSource.transform.position;
                }
            }
        }
    }
}
