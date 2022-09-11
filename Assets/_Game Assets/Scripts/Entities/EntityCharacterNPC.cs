using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;

public enum AlertStateEnum
{
    Idle,
    Suspicious,
    Alert,
    Search
}

public abstract class EntityCharacterNPC : EntityCharacter
{
    public AlertStateEnum alertState { get; protected set; } = AlertStateEnum.Idle;

    [SerializeField] protected VoicePack m_voicePack;
    public VoicePack voicePack { get { return m_voicePack; } }

    [SerializeField] protected UnityEvent[] m_idleWaitInputs;
    protected int currentIdle = 0;

    protected int m_skipTurnIdleCount = 0;
    public virtual void SkipTurnNPC(int turns = 1)
    {
        StoredActionSkipTurn();
        if(alertState == AlertStateEnum.Idle)
        {
            if (m_skipTurnIdleCount == 0)
                m_skipTurnIdleCount = turns;
            else
                m_skipTurnIdleCount = Mathf.Max(m_skipTurnIdleCount - 1, 0);

            if (m_skipTurnIdleCount == 0)
                _NextCurrentIdle();
        }
    }

    public virtual void TurnToDegreeNPC(float degree)
    {
        storedActions.Add(new StoredActionTurn(this, degree));
        _NextCurrentIdle();
    }

    protected virtual void _DoIdle()
    {
        if (m_idleWaitInputs.Length == 0)
        {
            SkipTurnNPC();
            return;
        }

        m_idleWaitInputs[currentIdle].Invoke();
    }

    protected virtual void _NextCurrentIdle()
    {
        if (alertState == AlertStateEnum.Idle)
            currentIdle = (int)Mathf.Repeat(currentIdle + 1, m_idleWaitInputs.Length);
    }

    // pathfinding masih boros : cek levelpathfinding.cs buat plan optimisasi
    protected void _MoveToPointNPC(Vector3 point, int moveRange = 1)
    {
        LevelPathfinding pathfinding = new LevelPathfinding(transform.position, point);
        LevelGridNode nextNode = null;
        if(pathfinding.CheckCanUseSimpleFindPath())
        {
            nextNode = pathfinding.SimpleFindPath();
        } else
        {
            List<LevelGridNode> nodes = pathfinding.FindPath();
            if (nodes == null || nodes.Count <= 1)
            {
                SkipTurnNPC();
                return;
            }

            nextNode = nodes[1];
        }

        float angle = Mathf.Atan2(nextNode.realWorldPos.x - transform.position.x, nextNode.realWorldPos.z - transform.position.z) * Mathf.Rad2Deg;
        storedActions.Add(new StoredActionTurn(this, angle, false));

        Vector3 dir = (nextNode.realWorldPos - transform.position).normalized;
        storedActions.Add(new StoredActionMove(this, dir, true, moveRange));
    }

    protected bool _CheckHasArrivedAtPoint(Vector3 point, float arrivedOffset = 0.0f)
    {
        return Vector3.Distance(transform.position, point) < (arrivedOffset + 0.1f);
    }
}
