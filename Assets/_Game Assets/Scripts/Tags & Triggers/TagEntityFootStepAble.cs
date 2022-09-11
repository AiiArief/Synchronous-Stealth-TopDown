using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FootStepType
{
    Default,
    Silence,
    Shallow
}

/***
 * Entity is able to produce foot step
 */
public class TagEntityFootStepAble: MonoBehaviour
{
    [SerializeField] TagFootStepSource m_defaultFootStepPrefab;
    [SerializeField] TagFootStepSource m_shallowFootStepPrefab;

    public void Step(LevelGridNode posNode, bool isRunning = true)
    {
        Transform stepSoundsParent = GameManager.Instance.levelManager.stepSoundEffectParent;
        TagFootStepSource footstep = Instantiate(_ConvertFromEnumToAudioSource(posNode.nodeFootStepType), stepSoundsParent, true);
        footstep.transform.position = posNode.realWorldPos;
        footstep.SetupStepSource(isRunning);
    }

    private TagFootStepSource _ConvertFromEnumToAudioSource(FootStepType footStepType)
    {
        switch(footStepType)
        {
            case FootStepType.Shallow:
                return m_shallowFootStepPrefab;
            default:
                return m_defaultFootStepPrefab;           
        }
    }
}
