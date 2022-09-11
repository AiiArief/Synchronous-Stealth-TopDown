using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using UniHumanoid;

public class ForceTPose
{
    [MenuItem("Tools/Character/ForceT-Pose")]
    static void TPose()
    {
        var selected = Selection.activeGameObject;
        if (!selected)
            return;

        if (!selected.TryGetComponent<Animator>(out var animator))
            return;

        var skeletons = animator.avatar?.humanDescription.skeleton;

        var root = animator.transform;
        var tfs = root.Traverse();
        var dir = new Dictionary<string, Transform>(tfs.Count());
        foreach (var tf in tfs)
        {
            if (!dir.ContainsKey(tf.name))
                dir.Add(tf.name, tf);
        }

        foreach (var skeleton in skeletons)
        {
            if (!dir.TryGetValue(skeleton.name, out var bone))
                continue;

            bone.localPosition = skeleton.position;
            bone.localRotation = skeleton.rotation;
            bone.localScale = skeleton.scale;
        }
    }
}