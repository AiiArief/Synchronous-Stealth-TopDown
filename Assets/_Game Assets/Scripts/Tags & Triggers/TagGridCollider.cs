using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagGridCollider : MonoBehaviour
{
    [SerializeField] FootStepType m_gridFootStepType = FootStepType.Default;
    public FootStepType gridFootStepType { get { return m_gridFootStepType; } }
}
