using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
[CustomEditor(typeof(LevelGrid))]
class LevelGridEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        LevelGrid grid = (LevelGrid)target;
        if(GUILayout.Button("Destroy Nodes"))
        {
            grid.EditorDestroyAllNodes();
            EditorUtility.SetDirty(target);
            EditorUtility.SetDirty(grid.levelGridNodeScriptableObject);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        if(GUILayout.Button("Generate Nodes"))
        {
            grid.EditorGenerateAllGridNodes();
            EditorUtility.SetDirty(target);
            EditorUtility.SetDirty(grid.levelGridNodeScriptableObject);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }
}
#endif
