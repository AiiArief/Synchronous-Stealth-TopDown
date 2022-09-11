using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

public class TriggerArea : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera m_vcam;

    [SerializeField] UnityEvent m_onTriggerEnterEvent;
    [SerializeField] UnityEvent m_onTriggerExitEvent;

    bool m_isPlayerHere = false;

    private void OnTriggerStay(Collider other)
    {
        if (m_isPlayerHere)
            return;

        EntityCharacterPlayer player = other.GetComponent<EntityCharacterPlayer>();
        if (player)
        {
            m_isPlayerHere = true;

            if (m_vcam)
                m_vcam.gameObject.SetActive(true);

            if(m_onTriggerEnterEvent.GetPersistentEventCount() > 0)
            {
                m_onTriggerEnterEvent.Invoke();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!m_isPlayerHere)
            return;

        EntityCharacterPlayer player = other.GetComponent<EntityCharacterPlayer>();
        if (player)
        {
            m_isPlayerHere = false;

            if (m_vcam)
                m_vcam.gameObject.SetActive(false);

            if (m_onTriggerExitEvent.GetPersistentEventCount() > 0)
            {
                m_onTriggerExitEvent.Invoke();
            }
        }
    }
}
