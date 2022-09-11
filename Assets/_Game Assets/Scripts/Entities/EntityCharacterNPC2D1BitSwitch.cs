using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class EntityCharacterNPC2D1BitSwitch : EntityCharacterNPC2D1Bit
{
    [SerializeField] EntityCharacterNPC2D1BitDoor[] m_switchForDoors;
    public EntityCharacterNPC2D1BitDoor[] switchForDoors { get { return m_switchForDoors; } }

    [SerializeField] bool m_currentIsOn = false;
    [SerializeField] Expression_2D1Bit m_isOnExpression = Expression_2D1Bit.Dead;
    public bool currentIsOn { get { return m_currentIsOn; } }

    [SerializeField] UnityEvent m_onChangeToIsOn;
    [SerializeField] UnityEvent m_onChangeToIsOff;

    StoredStatusEffectCustom m_autoCloseEffect;
    public bool hasAutoCloseEffect { get { return m_autoCloseEffect != null; } }

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

    public void SetCurrentIsOn(bool isOn)
    {
        m_currentIsOn = isOn;
        if (isOn) m_onChangeToIsOn.Invoke();
        else m_onChangeToIsOff.Invoke();
    }

    public void UseSwitch(int autoSwitchTurn = 0)
    {
        if (m_autoCloseEffect == null)
        {
            _UseSwitchForDoor();

            if (autoSwitchTurn > 0)
            {
                m_autoCloseEffect = new StoredStatusEffectCustom(() => { },
                () =>
                {
                    autoSwitchTurn = (autoSwitchTurn < 0) ? autoSwitchTurn : Mathf.Max(0, autoSwitchTurn - 1);
                    _HandleSoundTikTok(autoSwitchTurn);
                    if (autoSwitchTurn == 0)
                    {
                        _UseSwitchForDoor();

                        storedStatusEffects.Remove(m_autoCloseEffect);
                        m_autoCloseEffect = null;
                    }
                });

                storedStatusEffects.Add(m_autoCloseEffect);
            }
        }
    }

    private void _UseSwitchForDoor()
    {
        SetCurrentIsOn(!m_currentIsOn);
        bool callControlledSwitchFirstTime = true;
        foreach (EntityCharacterNPC2D1BitDoor door in m_switchForDoors)
        {
            door.SetDoorIsClosed(!door.currentIsClosed, false, callControlledSwitchFirstTime);
            callControlledSwitchFirstTime = false;
        }
    }

    private void _HandleSoundTikTok(int currentAutoSwitch)
    {
        if((currentAutoSwitch > 12 && currentAutoSwitch % 4 == 0) || 
            (currentAutoSwitch > 4 && currentAutoSwitch <= 12 && currentAutoSwitch % 2 == 0) ||
            (currentAutoSwitch <= 4))
            GetComponent<AudioSource>().PlayOneShot(GlobalGameManager.Instance.databaseManager.tikTok);
    }

    private void _UpdateLineRenderer()
    {
        if(animator.runtimeAnimatorController)
        {
            animator.speed = 1;
            animator.SetBool("currentIsOn", m_currentIsOn);
        }

        if (GameManager.Instance.playerManager.GetMainPlayer().storedStatusEffects.OfType<StoredStatusEffectEventControl>().Count() > 0)
            return;

        SetExpression(m_currentIsOn ? m_isOnExpression : m_startExpression);
    }
}
