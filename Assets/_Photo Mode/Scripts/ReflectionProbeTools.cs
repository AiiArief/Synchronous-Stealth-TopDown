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

            AssetDatabase.Refresh();
            //while (rpos.Length > 0)
            //{
            //    GameObject.Destroy(rpos[0]);
            //}
        }
        catch (Exception ex)
        {
            Debug.Log(ex.ToString());
        }
    }
#endif
}