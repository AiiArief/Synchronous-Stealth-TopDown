using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ReflectionProbeOptimizer : MonoBehaviour
{
    ReflectionProbe m_probe;
    EntityCharacterPlayer m_mainPlayer;

    [SerializeField] bool m_debug = false;

    private void Awake()
    {
        m_probe = GetComponent<ReflectionProbe>();

        StartCoroutine(_ReflectionAPIHandler());
    }

    private IEnumerator _ReflectionAPIHandler()
    {
        m_probe.RenderProbe();

        while (true)
        {
            yield return new WaitForEndOfFrame();

            if (!m_mainPlayer)
                m_mainPlayer = GameManager.Instance.playerManager.GetMainPlayer();

            if (m_mainPlayer)
            {
                int qualityLevel = QualitySettings.GetQualityLevel();
                m_probe.resolution = 32 * (int)Mathf.Pow(2, qualityLevel);

                int playerCloseEnough = _CheckPlayerIsCloseEnough();

                //bool isClose = qualityLevel == 3 && playerCloseEnough == 2;
                //m_probe.timeSlicingMode = (isClose) ? ReflectionProbeTimeSlicingMode.NoTimeSlicing : ReflectionProbeTimeSlicingMode.AllFacesAtOnce;

                bool renderNow = (qualityLevel >= 2) ? playerCloseEnough > 0 : playerCloseEnough == 2;

                if (renderNow)
                {
                    m_probe.RenderProbe();

                    if (m_debug) Debug.Log("Rendered : " + gameObject.name);

                    //if (qualityLevel < 3)
                      //  yield return new WaitForSeconds((1.0f / 60) * 5 * ((qualityLevel == 2) ? 2 : 8));
                }
            }
        }
    }

    /**
     * Out : 
     * 2 = player is inside
     * 1 = player outside but camera can look
     * 0 = player outside & camera can't look
     **/
    private int _CheckPlayerIsCloseEnough()
    {
        float viewDistance = Mathf.Max(m_probe.size.x, m_probe.size.z);
        float cameraRadius = 20.0f / 2; // temporary, size camera / 2 palingan
        float distance = Vector3.Distance(m_mainPlayer.transform.position, transform.position);

        float totalDistance = distance - viewDistance - cameraRadius;
        return (totalDistance <= 0.0f) ? (totalDistance <= -viewDistance) ? 2 : 1 : 0;
    }
}
