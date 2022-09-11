using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Transform m_stepSoundEffectParent;
    public Transform stepSoundEffectParent { get { return m_stepSoundEffectParent; } }

    [SerializeField] int minYPosToleration = -1;
    [SerializeField] LevelGrid[] m_grids;
    public LevelGrid[] grids { get { return m_grids; } }

    public void SetupAllGridsOnLevelStart()
    {
        foreach (LevelGrid grid in m_grids)
        {
            grid.SetupGridOnLevelStart();
        }
    }

    public LevelGrid GetClosestGridFromPosition(Vector3 pos)
    {
        for (int i = 0; i < m_grids.Length; i++)
        {
            bool isYBetweenGrid =
                (m_grids.Length == 1) ? true :
                (i == 0) ? pos.y < m_grids[i + 1].startPos.y + minYPosToleration :
                (i == m_grids.Length - 1) ? pos.y >= m_grids[i].startPos.y + minYPosToleration :
                pos.y >= m_grids[i].startPos.y + minYPosToleration && pos.y < m_grids[i + 1].startPos.y + minYPosToleration;

            if (isYBetweenGrid)
            {
                //Vector2 pos2D = new Vector2(pos.x, pos.z);
                //bool isXBetweenGrid = pos2D.x >= m_grids[i].startPos.x && pos2D.x < m_grids[i].startPos.x + m_grids[i].size.x;
                //bool isZBetweenGrid = pos2D.y >= m_grids[i].startPos.y && pos2D.y < m_grids[i].startPos.y + m_grids[i].size.y;
                //if (isXBetweenGrid && isZBetweenGrid)
                    return m_grids[i];
            }
        }

        return null;
    }
}
