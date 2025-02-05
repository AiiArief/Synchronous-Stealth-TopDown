using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class RefllectionProbeTools
{
#if UNITY_EDITOR
    [MenuItem("Tools/Reflection Probe/Remove All Reflection Probe Optimizer")]
    static void Remove()
    {
        var rpos = GameObject.FindObjectsOfType<ReflectionProbeOptimizer>();
        Debug.Log($"Found {rpos.Length} reflection probe optimizers, will remove them.");

        try
        {
            foreach (var rpo in rpos)
            {
                GameObject.DestroyImmediate(rpo);
            }

            EditorUtility.SetDirty(Selection.activeObject); // Mark the scene as dirty to save changes
            AssetDatabase.SaveAssets(); // Save the scene file
            AssetDatabase.Refresh();
        }
        catch (Exception ex)
        {
            Debug.Log(ex.ToString());
        }
    }

    [MenuItem("Tools/Reflection Probe/Set All Reflection Probe To On Awake")]
    static void SetAllOnAwake()
    {
        var rp = GameObject.FindObjectsOfType<ReflectionProbe>();
        Debug.Log($"Found {rp.Length} reflection probe optimizers, will set them.");

        try
        {
            foreach (var rpo in rp)
            {
                Undo.RecordObject(rpo, "Set Reflection Probe Settings"); // Record the change for Undo/Redo

                rpo.mode = UnityEngine.Rendering.ReflectionProbeMode.Realtime;
                rpo.refreshMode = UnityEngine.Rendering.ReflectionProbeRefreshMode.OnAwake;
                rpo.timeSlicingMode = UnityEngine.Rendering.ReflectionProbeTimeSlicingMode.NoTimeSlicing;

                if(!rpo.TryGetComponent<ReflectionProbeOptimizer>(out _))
                    Undo.AddComponent<ReflectionProbeOptimizer>(rpo.gameObject);
            }

            EditorUtility.SetDirty(Selection.activeObject); // Mark the scene as dirty to save changes
            AssetDatabase.SaveAssets(); // Save the scene file
            AssetDatabase.Refresh();
        }
        catch (Exception ex)
        {
            Debug.Log(ex.ToString());
        }
    }
#endif
}