using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class EntityCharacterNPC3DBot : EntityCharacterNPC
{
    [SerializeField] protected int m_maxAlertLevel = 15;
    public int maxAlertLevel { get { return m_maxAlertLevel; } }

    public int currentAlertLevel { get; protected set; } = 0;

    [SerializeField] protected UnityEvent[] m_searchWaitInputs;
    protected int m_currentSearch = 0;

    protected Vector3 m_guardedArea;
    protected bool m_guardedAreaHasBeenSetup = false;
    protected float m_guardedRotation = 0.0f;

    public override void SetupWaitInput()
    {
        base.SetupWaitInput();

        if (!m_guardedAreaHasBeenSetup)
        {
            m_guardedAreaHasBeenSetup = true;
            m_guardedArea = transform.position;
            m_guardedRotation = transform.rotation.eulerAngles.y;
        }
    }

    protected int m_skipTurnSearchCount = 0;
    public override void SkipTurnNPC(int turns = 1)
    {
        base.SkipTurnNPC(turns);
        if (alertState == AlertStateEnum.Search)
        {
            if (m_skipTurnSearchCount == 0)
                m_skipTurnSearchCount = turns;
            else
                m_skipTurnSearchCount = Mathf.Max(m_skipTurnSearchCount - 1, 0);

            if (m_skipTurnSearchCount == 0)
                _NextCurrentIdle();
        }
    }

    public void SetGuardArea(Transform waypoint)
    {
        m_guardedArea = waypoint.position;
        _NextCurrentIdle();
    }

    protected override void _DoIdle()
    {
        if (!_CheckHasArrivedAtPoint(m_guardedArea))
        {
            _MoveToPointNPC(m_guardedArea);
        }
        else
        {
            if (m_idleWaitInputs.Length == 0)
            {
                TurnToDegreeNPC(m_guardedRotation);
            }

            base._DoIdle();
        }
    }

    protected override void _NextCurrentIdle()
    {
        base._NextCurrentIdle();

        if (alertState == AlertStateEnum.Search)
            m_currentSearch = Mathf.Min(m_currentSearch + 1, m_searchWaitInputs.Length);
    }

    protected virtual void _DoSearch()
    {
        if (m_searchWaitInputs.Length == 0)
        {
            SkipTurnNPC();
            return;
        }

        m_searchWaitInputs[m_currentSearch].Invoke();
    }
}
