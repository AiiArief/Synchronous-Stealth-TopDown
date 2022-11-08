using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EntityCharacterPlayer : EntityCharacter
{
    public int playerId { get { return transform.GetSiblingIndex(); } }

    public override void SetupWaitInput()
    {
        base.SetupWaitInput();
    }

    public override void WaitInput()
    {
        base.WaitInput();

        if (_CheckIsOnEvent())
        {
            _HandleIsCombatAnimation();
            return;
        }

        float moveH = Input.GetAxisRaw("Horizontal" + " #" + playerId);
        float moveV = Input.GetAxisRaw("Vertical" + " #" + playerId);
        bool isMoving = Mathf.Abs(moveH) > 0.0f || Mathf.Abs(moveV) > 0.0f;
        bool moveMod = Input.GetButton("Move Modifier" + " #" + playerId);
        bool skipTurn = _CheckDoubleInput("Move Modifier" + " #" + playerId, 0.5f);
        bool pause = Input.GetKey(KeyCode.Escape);

        if (skipTurn)
        {
            StoredActionSkipTurn();
            storedActions.Add(new StoredActionCustom(() => _HandleIsCombatAnimation()));
            return;
        }

        if (isMoving)
        {
            int moveRange = moveMod ? 2 : 1;
            Vector3 moveDir = (Mathf.Abs(_FCInput(moveH) + _FCInput(moveV)) != 1.0f) ? new Vector3(0.0f, 0.0f, _FCInput(moveV)) : new Vector3(_FCInput(moveH), 0.0f, _FCInput(moveV));
            float angle = Mathf.Atan2(moveDir.x, moveDir.z) * Mathf.Rad2Deg;

            storedActions.Add(new StoredActionTurn(this, angle, false));
            storedActions.Add(new StoredActionMove(this, moveDir, true, moveRange));
            storedActions.Add(new StoredActionCustom(() => _HandleIsCombatAnimation()));
            return;
        }

        if (pause)
        {
            StoredActionSkipTurn();
            storedActions.Add(new StoredActionCustom(() => GameManager.Instance.eventManager.genericEvent.PlayerPause()));
        }
    }

    public override void SetupProcessInput()
    {
        base.SetupProcessInput();

        _ResetAllInputButtonVariable();
    }

    public override void AfterInput()
    {
        base.AfterInput();

        afterActionHasDone = true;
    }

    private float _FCInput(float input)
    {
        return (input < 0.0f) ? Mathf.Floor(input) : Mathf.Ceil(input);
    }

    [HideInInspector] float m_buttonDownCount = 0;
    [HideInInspector] float m_buttonDownTime = 0;
    private bool _CheckDoubleInput(string inputName, float buttonDownDelay)
    {
        if (Input.GetButtonDown(inputName))
        {
            m_buttonDownCount++;
            if (m_buttonDownCount == 1) m_buttonDownTime = Time.time;
        }
        if (m_buttonDownCount > 1 && Time.time - m_buttonDownTime < buttonDownDelay)
        {
            m_buttonDownCount = 0;
            m_buttonDownTime = 0;
            return true;
        }
        else if (m_buttonDownCount > 2 || Time.time - m_buttonDownTime > 1) m_buttonDownCount = 0;
        return false;
    }

    [HideInInspector] float m_buttonHoldTime = 0;
    private bool _CheckHoldInput(string inputName, float holdTime)
    {
        if (Input.GetButtonDown(inputName))
            m_buttonHoldTime = 0;

        if (Input.GetButton(inputName))
        {
            m_buttonHoldTime += Time.deltaTime;
        }

        return m_buttonHoldTime >= holdTime;
    }

    private void _ResetAllInputButtonVariable()
    {
        m_buttonDownCount = 0;
        m_buttonDownTime = 0;
        m_buttonHoldTime = 0;
    }

    private bool _CheckIsOnEvent()
    {
        var disableMoveInputList = storedStatusEffects.OfType<StoredStatusEffectEventControl>();
        return disableMoveInputList.Count() > 0;
    }

    private void _HandleIsCombatAnimation()
    {
        if(!_CheckIsOnEvent())
        {
            var npcs = GameManager.Instance.npcManager.GetNPCPlayableList();
            for (int i = 0; i < npcs.Count; i++)
            {
                if (npcs[i] is EntityCharacterNPC3DBot && Vector3.Distance(npcs[i].transform.position, transform.position) <= 20.0f / 2 + 1)
                {
                    animator.SetBool("isCombat", true);
                    return;
                }
            }
        }

        animator.SetBool("isCombat", false);
    }
}
