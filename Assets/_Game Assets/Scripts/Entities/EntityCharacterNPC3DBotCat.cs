using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public enum AlertSource
{
    NoAlert,
    Vision,
    Hear
}

public class EntityCharacterNPC3DBotCat : EntityCharacterNPC3DBot
{
    [SerializeField] VisionLook m_visionLook;
    public VisionLook visionLook { get { return m_visionLook; } }

    [SerializeField] HearAlert m_hearAlert;
    public HearAlert hearAlert { get { return m_hearAlert; } }

    AlertSource m_alertSource = AlertSource.NoAlert;
    AlertSource m_lastAlertSource = AlertSource.NoAlert;

    public override void SetupWaitInput()
    {
        base.SetupWaitInput();

        m_visionLook.SetupVisionLookWaitInput(this);
        m_hearAlert.SetupHearAlertWaitInput(this);
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
                _MoveToPointNPC(_GenerateSuspiciousSearchPosition());
                break;
            case AlertStateEnum.Alert:
                StoredActionSkipTurn();
                break;
            case AlertStateEnum.Search:
                if (!_CheckHasArrivedAtPoint(_GenerateSuspiciousSearchPosition()))
                    _MoveToPointNPC(_GenerateSuspiciousSearchPosition());
                else
                    _DoSearch();
                break;
        }

        m_visionLook.HandleVisionLookWaitInput();
        storedActions.Add(new StoredActionVisionLook(this, m_visionLook));
    }

    public override void AfterInput()
    {
        base.AfterInput();

        visionLook.HandleVisionLookAfterInput();
        hearAlert.HandleHearAlertAfterInput();
        switch (alertState)
        {
            case AlertStateEnum.Idle:
                afterActionHasDone = true;
                alertState = _GenerateAlertState(AlertStateEnum.Idle);
                m_lastAlertSource = m_alertSource;

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
                alertState = _GenerateAlertState(AlertStateEnum.Search);
                m_lastAlertSource = (alertState != AlertStateEnum.Search) ? m_alertSource : m_lastAlertSource;

                if (alertState == AlertStateEnum.Alert || currentAlertLevel >= maxAlertLevel)
                {
                    currentAlertLevel = maxAlertLevel;
                    _CapturePlayer();
                    return;
                }
                break;
            case AlertStateEnum.Search:
                afterActionHasDone = true;
                alertState = _GenerateAlertState(AlertStateEnum.Search);

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

    protected AlertStateEnum _GenerateAlertState(AlertStateEnum fallback)
    {
        m_alertSource = AlertSource.NoAlert;

        bool alertMode = visionLook.isInVisionList.ContainsValue(IsInVisionArea.AlertArea);
        bool susMode = !alertMode && visionLook.isInVisionList.ContainsValue(IsInVisionArea.SuspiciousArea);
        m_alertSource = (alertMode || susMode) ? AlertSource.Vision : AlertSource.NoAlert;

        if (alertMode || susMode)
            return (alertMode) ? AlertStateEnum.Alert : (susMode) ? AlertStateEnum.Suspicious : fallback;

        susMode = hearAlert.closestFootStepSource; // cara ngecek nya ga akurat, closest foot step source bakalan diapus dalam waktu sedetik
        m_alertSource = (susMode) ? AlertSource.Hear : AlertSource.NoAlert;

        return (susMode) ? AlertStateEnum.Suspicious : fallback;
    }

    private void _CapturePlayer()
    {
        EntityCharacterPlayer caughtPlayer = visionLook.alertTargetEntity as EntityCharacterPlayer;
        if (caughtPlayer.storedStatusEffects.OfType<StoredStatusEffectCaptured>().Any())
            return;

        caughtPlayer.storedStatusEffects.Add(new StoredStatusEffectCaptured(caughtPlayer));
        caughtPlayer.storedStatusEffects.Add(new StoredStatusEffectAutoSkip(caughtPlayer));
    }

    private Vector3 _GenerateSuspiciousSearchPosition()
    {
        switch (alertState)
        {
            case AlertStateEnum.Suspicious:
                if (m_alertSource == AlertSource.Vision)
                    return visionLook.alertTargetEntity.transform.position;

                if (m_alertSource == AlertSource.Hear)
                    return hearAlert.lastTargetPos;

                break;
            case AlertStateEnum.Search:
                if (m_lastAlertSource == AlertSource.Vision)
                    return visionLook.lastTargetPos;

                if (m_lastAlertSource == AlertSource.Hear)
                    return hearAlert.lastTargetPos;

                break;
        }

        return transform.position;
    }
}
