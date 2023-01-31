using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityCharacterNPC2DHumanoidLaptop : EntityCharacterNPC
{
    [SerializeField] AudioSource m_audioSource;
    public AudioSource audioSource { get { return m_audioSource; } }

    public override void WaitInput()
    {
        base.WaitInput();

        _DoIdle();
    }

    public override void AfterInput()
    {
        base.AfterInput();

        afterActionHasDone = true;
    }
}
