using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CutsceneCamera : MonoBehaviour
{
    bool m_isUsing = false;

    public void UseCamera(int cameraId = -1)
    {
        if (cameraId > transform.childCount)
            return;

        if (!m_isUsing)
        {
            m_isUsing = true;
            _EnableRoofs(true);
        }

        _DisableAllCameras();

        if (cameraId >= 0)
            transform.GetChild(cameraId).gameObject.SetActive(true);
        else
            _GetClosestCameraFromPlayer().SetActive(true);
    }

    public void ReleaseCamera()
    {
        m_isUsing = false;

        _EnableRoofs(false);
        _DisableAllCameras();
    }

    private void _EnableRoofs(bool on)
    {
        if (on)
            _AddLayerToCullingMask(Camera.main, 10);
        else
            _RemoveLayerFromCullingMask(Camera.main, 10);
    }

    private void _DisableAllCameras()
    {
        foreach (Transform child in transform)
            child.gameObject.SetActive(false);
    }

    private GameObject _GetClosestCameraFromPlayer()
    {
        var player = GameManager.Instance.playerManager.GetMainPlayer();
        var closesDistance = Mathf.Infinity;
        GameObject selectedCamera = null;
        for(int i=0; i<transform.childCount; i++)
        {
            var dist = Vector3.Distance(player.transform.position, transform.GetChild(i).position);
            if (dist < closesDistance)
            {
                closesDistance = dist;
                selectedCamera = transform.GetChild(i).gameObject;
            }
        }

        return selectedCamera;
    }

    private void _AddLayerToCullingMask(Camera camera, int layer)
    {
        camera.cullingMask |= 1 << layer;
    }

    private void _RemoveLayerFromCullingMask(Camera camera, int layer)
    {
        camera.cullingMask &= ~(1 << layer);
    }
}
