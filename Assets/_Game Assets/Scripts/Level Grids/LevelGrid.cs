using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{
    [SerializeField] Vector2 m_size;
    public Vector2 size { get { return m_size; } }

    public Vector3 startPos { get; private set; }

    [SerializeField] LevelGridNodeScriptableObject m_levelGridNodeScriptableObject;
    public LevelGridNodeScriptableObject levelGridNodeScriptableObject { get { return m_levelGridNodeScriptableObject; } }

    public LevelGridNode[,] gridNodes { get; private set; }

    public void EditorGenerateAllGridNodes()
    {
        EditorDestroyAllNodes();

        Vector3 tempStartPos = _CalculateStartPos();
        m_levelGridNodeScriptableObject.levelGridNodes = new LevelGridNode[(int)size.x * (int)size.y];
        int index = 0;
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                m_levelGridNodeScriptableObject.levelGridNodes[index] = new LevelGridNode();
                m_levelGridNodeScriptableObject.levelGridNodes[index].EditorGenerateGridNode(new Vector2(i, j), new Vector3(tempStartPos.x + i, tempStartPos.y, tempStartPos.z + j));
                index++;
            }
        }
    }

    public void EditorDestroyAllNodes()
    {
        m_levelGridNodeScriptableObject.levelGridNodes = null;
    }

    public void SetupGridOnLevelStart()
    {
        startPos = _CalculateStartPos();
        gridNodes = new LevelGridNode[(int)size.x, (int)size.y];

        int index = 0;
        for(int i=0; i<size.x; i++ )
        {
            for(int j=0; j<size.y; j++)
            {
                gridNodes[i, j] = new LevelGridNode(m_levelGridNodeScriptableObject.levelGridNodes[index], this);
                index++;
            }
        }
    }

    public LevelGridNode ConvertPosToNode(Vector3 pos)
    {
        int x = Mathf.RoundToInt(0 - startPos.x + pos.x);
        int z = Mathf.RoundToInt(0 - startPos.z + pos.z);

        if (!_CheckNodeIsExist(new Vector2(x, z)))
            return null;

        return gridNodes[x, z];
    }

    public void ResetAllPathNode()
    {
        for(int i=0; i<size.x; i++)
        {
            for(int j=0; j<size.y; j++)
            {
                gridNodes[i, j].ResetPathNode();
            }
        }
    }

    private Vector3 _CalculateStartPos()
    {
        return new Vector3(transform.position.x - size.x / 2, transform.position.y, transform.position.z - size.y / 2);
    }

    private bool _CheckNodeIsExist(Vector2 pos)
    {
        if (pos.x < 0 || pos.x >= m_size.x)
            return false;

        if (pos.y < 0 || pos.y >= m_size.y)
            return false;

        return true;
    }
}
