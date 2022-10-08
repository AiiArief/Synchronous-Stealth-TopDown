using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPathfinding
{
    private const int MOVE_STRAIGHT_COST = 10;

    List<LevelGridNode> m_openList;
    List<LevelGridNode> m_closedList;

    LevelGrid grid;
    LevelGridNode startNode = null;
    LevelGridNode endNode = null;

    public LevelPathfinding(Vector3 startWorldPos, Vector3 endWorldPos)
    {
        /*LevelGrid startNodeGrid = GameManager.Instance.levelManager.GetClosestGridFromPosition(startWorldPos);
        LevelGrid endNodeGrid = GameManager.Instance.levelManager.GetClosestGridFromPosition(endWorldPos);

        if (startNodeGrid != endNodeGrid)
        {
            Debug.Log("Different Grid");
            return null;
        }*/

        grid = GameManager.Instance.levelManager.grids[0];
        startNode = grid.ConvertPosToNode(startWorldPos);
        endNode = grid.ConvertPosToNode(endWorldPos);
    }

    public bool CheckCanUseSimpleFindPath()
    {
        if (startNode == null || endNode == null)
        {
            Debug.Log("Invalid Node :\nStart Node : " + startNode + "\nEnd Node : " + endNode);
            return false;
        }

        RaycastHit[] hits = Physics.RaycastAll(startNode.realWorldPos + Vector3.up, (endNode.realWorldPos + Vector3.up) - (startNode.realWorldPos + Vector3.up), Vector3.Distance(startNode.realWorldPos, endNode.realWorldPos));
        for(int i=0; i<hits.Length; i++)
        {
            if (hits[i].collider.GetComponent<TagGridCollider>())
            {
                return false;
            }
        }

        return true;
    }

    public LevelGridNode SimpleFindPath()
    {
        Vector3 dir = (endNode.realWorldPos - startNode.realWorldPos).normalized;
        Vector3 nextPos = new Vector3(Mathf.Round(dir.x), 0.0f, (Mathf.Round(dir.x) != 0) ? 0.0f : Mathf.Round(dir.z) );
        return grid.ConvertPosToNode(startNode.realWorldPos + nextPos);
    }

    // trik2 optimisasi :
    // kalo tujuan udah ada entity, jangan ngesearch semuanya
    // kalo pathfindingnya masih sama ga usah find path
    // kalo lebih dari jarak mungkin ubah endworldpos ke terdeket
    public List<LevelGridNode> FindPath()
    {
        if (startNode == null || endNode == null)
        {
            Debug.Log("Invalid Node :\nStart Node : " + startNode + "\nEnd Node : " + endNode);
            return null;
        }

        m_openList = new List<LevelGridNode> { startNode };
        m_closedList = new List<LevelGridNode>();

        grid.ResetAllPathNode();

        startNode.gCost = 0;
        startNode.hCost = _CalculateDistanceCost(startNode, endNode);
        startNode.CalculateFCost();

        // this shit is costlyyyyy apalgi kalo jaoh
        while (m_openList.Count > 0)
        {
            LevelGridNode currentNode = _CalculateLowestFCostNode(m_openList);

            if (currentNode == endNode)
            {
                return _CalculatePath(endNode);
            }

            m_openList.Remove(currentNode);
            m_closedList.Add(currentNode);

            foreach (LevelGridNode neighbourNode in _GenerateNeighbourList(currentNode))
            {
                if (m_closedList.Contains(neighbourNode)) continue;
                if (neighbourNode.isStaticNode) //|| !neighbourNode.CheckListEntityIsPassable()) // ini tuh kalo ada entity di tujuan bakalan false
                {
                    m_closedList.Add(neighbourNode);
                    continue;
                }

                int tentativeGCost = currentNode.gCost + _CalculateDistanceCost(currentNode, neighbourNode);
                if (tentativeGCost < neighbourNode.gCost)
                {
                    neighbourNode.cameFromNode = currentNode;
                    neighbourNode.gCost = tentativeGCost;
                    neighbourNode.hCost = _CalculateDistanceCost(neighbourNode, endNode);
                    neighbourNode.CalculateFCost();

                    if (!m_openList.Contains(neighbourNode))
                    {
                        m_openList.Add(neighbourNode);
                    }
                }
            }
        }

        return null;
    }

    private List<LevelGridNode> _GenerateNeighbourList(LevelGridNode currentNode)
    {
        List<LevelGridNode> neighbourList = new List<LevelGridNode>();
        LevelGrid grid = currentNode.parentGrid;

        if (currentNode.gridPos.x - 1 >= 0)
            neighbourList.Add(grid.gridNodes[(int)currentNode.gridPos.x - 1, (int)currentNode.gridPos.y]);

        if (currentNode.gridPos.x + 1 < grid.size.x)
            neighbourList.Add(grid.gridNodes[(int)currentNode.gridPos.x + 1, (int)currentNode.gridPos.y]);

        if (currentNode.gridPos.y - 1 >= 0)
            neighbourList.Add(grid.gridNodes[(int)currentNode.gridPos.x, (int)currentNode.gridPos.y - 1]);

        if (currentNode.gridPos.y + 1 < grid.size.y)
            neighbourList.Add(grid.gridNodes[(int)currentNode.gridPos.x, (int)currentNode.gridPos.y + 1]);

        return neighbourList;
    }

    private int _CalculateDistanceCost(LevelGridNode a, LevelGridNode b)
    {
        int xDistance = Mathf.Abs((int)a.gridPos.x - (int)b.gridPos.x);
        int yDistance = Mathf.Abs((int)a.gridPos.y - (int)b.gridPos.y);
        int total = Mathf.Abs(xDistance + yDistance);
        return MOVE_STRAIGHT_COST * total;
    }

    private LevelGridNode _CalculateLowestFCostNode(List<LevelGridNode> pathNodeList)
    {
        LevelGridNode lowestFCostNode = pathNodeList[0];
        for (int i = 1; i < pathNodeList.Count; i++)
        {
            if (pathNodeList[i].fCost < lowestFCostNode.fCost)
            {
                lowestFCostNode = pathNodeList[i];
            }
        }
        return lowestFCostNode;
    }

    private List<LevelGridNode> _CalculatePath(LevelGridNode endNode)
    {
        List<LevelGridNode> path = new List<LevelGridNode>();
        path.Add(endNode);
        LevelGridNode currentNode = endNode;
        while (currentNode.cameFromNode != null)
        {
            path.Add(currentNode.cameFromNode);
            currentNode = currentNode.cameFromNode;
        }
        path.Reverse();
        return path;
    }
}
