using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ReflectionProbeOptimizer : MonoBehaviour
{
    ReflectionProbe m_probe;
    EntityCharacterPlayer m_mainPlayer;

    private void Awake()
    {
        m_probe = GetComponent<ReflectionProbe>();

        StartCoroutine(_ReflectionAPIHandler());
    }

    private IEnumerator _ReflectionAPIHandler()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();

            if (!m_mainPlayer)
                m_mainPlayer = GameManager.Instance.playerManager.GetMainPlayer();

            if (m_mainPlayer)
            {
                int qualityLevel = QualitySettings.GetQualityLevel();

                int playerCloseEnough = _CheckPlayerIsCloseEnough();

                bool isClose = qualityLevel == 3 && playerCloseEnough == 2;
                m_probe.timeSlicingMode = (isClose) ? ReflectionProbeTimeSlicingMode.NoTimeSlicing : ReflectionProbeTimeSlicingMode.AllFacesAtOnce;

                if (playerCloseEnough > 0)
                    m_probe.RenderProbe();
            }
        }
    }

    private int _CheckPlayerIsCloseEnough()
    {
        float viewDistance = Mathf.Max(m_probe.size.x, m_probe.size.z);
        float cameraRadius = 20.0f / 2; // temporary, size camera / 2 palingan
        float distance = Vector3.Distance(m_mainPlayer.transform.position, transform.position);

        float totalDistance = distance - viewDistance - cameraRadius;
        return (totalDistance <= 0.0f) ? (totalDistance <= -viewDistance) ? 2 : 1 : 0;
    }
}
