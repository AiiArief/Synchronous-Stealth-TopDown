using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Roof : MonoBehaviour
{
    [SerializeField] string m_enableRoofSceneName = "Level 1";
    [SerializeField] GameObject m_roofHidden;

    private void Awake()
    {
        bool isActiveScene = SceneManager.GetActiveScene().name == m_enableRoofSceneName;
        int layer = (isActiveScene) ? LayerMask.NameToLayer("Roof") : LayerMask.NameToLayer("Default");
        m_roofHidden.gameObject.SetActive(isActiveScene);

        ChangeObjectLayerRecursively(transform, layer);
    }

    private void ChangeObjectLayerRecursively(Transform _transform, int layer)
    {
        foreach (Transform t in _transform)
        {
            if (t.gameObject == m_roofHidden)
                continue;

            t.gameObject.layer = layer;

            ChangeObjectLayerRecursively(t, layer);
        }
    }
}
