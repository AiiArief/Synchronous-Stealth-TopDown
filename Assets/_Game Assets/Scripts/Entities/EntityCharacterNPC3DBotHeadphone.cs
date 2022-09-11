using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class EntityCharacterNPC3DBotHeadphone : EntityCharacterNPC3DBot
{
    [SerializeField] VisionLook m_visionLook;
    public VisionLook visionLook { get { return m_visionLook; } }

    public override void SetupWaitInput()
    {
        base.SetupWaitInput();

        m_visionLook.SetupVisionLookWaitInput(this);
    }

    public override void WaitInput()
    {
        base.WaitInput();

        switch (alertState)
        {
            case AlertStateEnum.Idle:
                _DoIdle();
                break;
            case AlertStateEnum.Suspicious:
                _MoveToPointNPC(visionLook.alertTargetEntity.transform.position);
                break;
            case AlertStateEnum.Alert:
                StoredActionSkipTurn();
                break;
            case AlertStateEnum.Search:
                if (!_CheckHasArrivedAtPoint(visionLook.lastTargetPos))
                    _MoveToPointNPC(visionLook.lastTargetPos);
                else
                    _DoSearch();
                break;
        }

        m_visionLook.HandleVisionLookWaitInput();
        storedActions.Add(new StoredActionVisionLook(this, m_visionLook));
        storedActions.Add(new StoredActionCustom(() => _HandleIsCombatAnimation()));
    }

    public override void AfterInput()
    {
        base.AfterInput();

        visionLook.HandleVisionLookAfterInput();
        switch (alertState)
        {
            case AlertStateEnum.Idle:
                afterActionHasDone = true;
                alertState = _CheckVisionLookGuarding(AlertStateEnum.Idle);
                if (alertState == AlertStateEnum.Alert)
                {
                    currentAlertLevel = maxAlertLevel;
                    _CapturePlayer();
                    return;
                }

                break;
            case AlertStateEnum.Suspicious:
                afterActionHasDone = true;
                currentAlertLevel = Mathf.Min(currentAlertLevel + 1, maxAlertLevel);
                // pindahin kamera ke default?

                if (currentAlertLevel >= maxAlertLevel || visionLook.isInVisionList.ContainsValue(IsInVisionArea.AlertArea))
                {
                    alertState = AlertStateEnum.Alert;
                    currentAlertLevel = maxAlertLevel;
                    _CapturePlayer();
                    return;
                }

                if (visionLook.CheckAllIsInVisionAreTheSame(IsInVisionArea.OutOfArea))
                {
                    alertState = AlertStateEnum.Search;
                }
                break;
            case AlertStateEnum.Search:
                afterActionHasDone = true;
                alertState = _CheckVisionLookGuarding(AlertStateEnum.Search);

                if (alertState == AlertStateEnum.Alert)
                {
                    currentAlertLevel = maxAlertLevel;
                    _CapturePlayer();
                    return;
                }

                if (alertState == AlertStateEnum.Search && m_currentSearch >= m_searchWaitInputs.Length)
                {
                    m_currentSearch = 0;
                    currentAlertLevel = 0;
                    alertState = AlertStateEnum.Idle;
                    return;
                }

                break;
            case AlertStateEnum.Alert:
                afterActionHasDone = true;
                break;
        }
    }

    protected AlertStateEnum _CheckVisionLookGuarding(AlertStateEnum fallback)
    {
        bool alertMode = visionLook.isInVisionList.ContainsValue(IsInVisionArea.AlertArea);
        bool susMode = !alertMode && visionLook.isInVisionList.ContainsValue(IsInVisionArea.SuspiciousArea);
        return (alertMode) ? AlertStateEnum.Alert : (susMode) ? AlertStateEnum.Suspicious : fallback;
    }

    private void _CapturePlayer()
    {
        EntityCharacterPlayer caughtPlayer = visionLook.alertTargetEntity as EntityCharacterPlayer;
        if (caughtPlayer.storedStatusEffects.OfType<StoredStatusEffectCaptured>().Any())
            return;

        caughtPlayer.storedStatusEffects.Add(new StoredStatusEffectCaptured(caughtPlayer, this));
    }

    private void _HandleIsCombatAnimation()
    {
        animator.SetBool("isCombat", alertState != AlertStateEnum.Idle);
        animator.SetInteger("expression", (alertState != AlertStateEnum.Idle) ? 0 : 3);
    }
}
