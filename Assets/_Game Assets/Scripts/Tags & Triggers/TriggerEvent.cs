using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum EventTriggerType
{
    PlayerTouch, NPCOnlyTouch, AnyCharacterTouch
}

public class TriggerEvent : MonoBehaviour
{
    public int eventTriggerId { get { return transform.GetSiblingIndex(); } }

    [SerializeField] EventTriggerType m_triggerType = EventTriggerType.PlayerTouch;

    [SerializeField] UnityEvent m_event;

    public void SetIsAvailable(bool cond, float delayTime = 1.0f)
    {
        if (!cond && delayTime <= 0.0f)
        {
            gameObject.SetActive(false);
            return;
        }

        if(!cond) 
            StartCoroutine(DelaySetActive(delayTime));

        GetComponent<Animator>().SetBool("isAvailable", cond);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (m_triggerType == EventTriggerType.PlayerTouch)
        {
            EntityCharacterPlayer player = other.GetComponent<EntityCharacterPlayer>();
            if (player)
            {
                if (m_event.GetPersistentEventCount() > 0)
                {
                    m_event.Invoke();
                    return;
                }
            }
        }
    }

    private IEnumerator DelaySetActive(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
}
