using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelGridNodeScriptableObject", menuName = "Level/LevelGridNodeScriptableObject", order = 1)]
public class LevelGridNodeScriptableObject : ScriptableObject
{
    public LevelGridNode[] levelGridNodes;
}
