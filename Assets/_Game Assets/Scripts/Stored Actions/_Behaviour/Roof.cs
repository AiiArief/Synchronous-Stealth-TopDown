using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Roof : MonoBehaviour
{
    [SerializeField] string m_enableRoofSceneName = "Level 1";

    private void Awake()
    {
        bool isActiveScene = SceneManager.GetActiveScene().name == m_enableRoofSceneName;
        int layer = (isActiveScene) ? LayerMask.NameToLayer("Roof") : LayerMask.NameToLayer("Default");
        for (int i=1; i<transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.layer = layer;
        }
    }
}
