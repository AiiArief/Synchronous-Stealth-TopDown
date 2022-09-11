using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum InteractType
{
    PlayerOnly,
    NPCOnly,
    AllEntities
}

[System.Serializable]
public class InteractDirection
{
    [SerializeField] bool m_left;
    public bool left { get { return m_left; } }
    [SerializeField] bool m_right;
    public bool right { get { return m_right; } }
    [SerializeField] bool m_up;
    public bool up { get { return m_up; } }
    [SerializeField] bool m_down;
    public bool down { get { return m_down; } }
}

public class TagEntityInteractable : MonoBehaviour
{
    [SerializeField] InteractType m_interactType = InteractType.PlayerOnly;

    [SerializeField] InteractDirection m_interactDirection;

    [SerializeField] UnityEvent m_interactEvent;

    public void Interact(EntityCharacter whoInteracted)
    {
        if ((m_interactType == InteractType.PlayerOnly && whoInteracted is EntityCharacterPlayer) ||
           (m_interactType == InteractType.NPCOnly && whoInteracted is EntityCharacterNPC) ||
           m_interactType == InteractType.AllEntities)
        {
            m_interactEvent.Invoke();
        }
    }

    public bool CheckInteractDirection(Vector3 direction)
    {
        return (
            (m_interactDirection.left && direction == Vector3.right) ||
            (m_interactDirection.right && direction == Vector3.left) ||
            (m_interactDirection.up && direction == Vector3.back) ||
            (m_interactDirection.down && direction == Vector3.forward)
        );
    }
}
