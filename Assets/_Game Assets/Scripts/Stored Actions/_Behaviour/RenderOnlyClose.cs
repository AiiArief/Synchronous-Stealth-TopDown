using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class RenderOnlyClose : MonoBehaviour
{
    MeshRenderer m_meshRenderer;
    EntityCharacterPlayer m_mainPlayer;

    private void Awake()
    {
        m_meshRenderer = GetComponent<MeshRenderer>();

        StartCoroutine(RenderOnlyCloseToPlayer());
    }

    private IEnumerator RenderOnlyCloseToPlayer()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();

            if (!m_mainPlayer)
                m_mainPlayer = GameManager.Instance.playerManager.GetMainPlayer();

            if (m_mainPlayer)
            {
                m_meshRenderer.enabled = _CheckPlayerIsCloseEnough();
            }
        }
    }

    private bool _CheckPlayerIsCloseEnough()
    {
        float distance = Vector3.Distance(m_mainPlayer.transform.position, transform.position);
        return distance <= 1.5f;
    }
}
