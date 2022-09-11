using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class TriggerCheckpoint: MonoBehaviour
{
    public int checkpointId { get { return transform.GetSiblingIndex(); } }

    [SerializeField][Range(0, 360)] float m_startRotation = 0;
    public float startRotation { get { return m_startRotation; } }

    [SerializeField] AudioSource m_teleporterArea;
    public AudioSource teleportArea { get { return m_teleporterArea; } }

    [SerializeField] UnityEvent m_onCheckpointEvent;

    public bool isCheckpointHere { get; private set; } = false;

    public void SetIsCheckpointHere(bool cond)
    {
        isCheckpointHere = cond;
        GetComponent<Animator>().SetBool("isCheckpointHere", isCheckpointHere);
    }

    public void ChangeCheckpointToHere()
    {
        var succeed = GameManager.Instance.eventManager.ChangeCheckpoint(checkpointId);
    }

    private void OnTriggerStay(Collider other)
    {
        if (isCheckpointHere)
            return;

        EntityCharacterPlayer player = other.GetComponent<EntityCharacterPlayer>();
        if(player)
        {
            if(m_onCheckpointEvent.GetPersistentEventCount() > 0)
            {
                m_onCheckpointEvent.Invoke();
                return;
            }
        }
    }
}
