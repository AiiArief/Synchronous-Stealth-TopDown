using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum IsInVisionArea
{
    OutOfArea,
    SuspiciousArea,
    AlertArea
}

public class VisionLook : MonoBehaviour
{
    EntityCharacterNPC3DBot m_bot;
    bool m_hasBeenSetup = false;

    Dictionary<Entity, IsInVisionArea> m_isInVisionList = new Dictionary<Entity, IsInVisionArea>();
    public Dictionary<Entity, IsInVisionArea> isInVisionList { get { return m_isInVisionList; } }

    [SerializeField] MeshRenderer m_alertMeshRenderer;

    [SerializeField] float m_coneAngle = 45.0f;
    [SerializeField] float m_alertDistance = 5.0f;
    [SerializeField] float m_suspiciousDistance = 5.0f;

    Mesh m_visionLookMesh;
    Mesh m_visionLookMeshAlert;

    public Entity alertTargetEntity { get; private set; }
    public Vector3 lastTargetPos { get; private set; }
    EntityCharacterPlayer m_mainPlayer;

    public void SetupVisionLookWaitInput(EntityCharacterNPC3DBot bot)
    {
        if (!m_hasBeenSetup)
        {
            m_hasBeenSetup = true;

            m_bot = bot;

            m_visionLookMesh = new Mesh();
            GetComponent<MeshFilter>().mesh = m_visionLookMesh;

            m_visionLookMeshAlert = new Mesh();
            m_alertMeshRenderer.GetComponent<MeshFilter>().mesh = m_visionLookMeshAlert;

            m_mainPlayer = GameManager.Instance.playerManager.GetMainPlayer();
        }
    }

    public void HandleVisionLookWaitInput()
    {
        _HandleVisionLookMesh();
    }

    public void HandleVisionLookAfterInput()
    {
        _HandleIsInVisionArea();
    }

    public bool CheckAllIsInVisionAreTheSame(IsInVisionArea checkIsInVisionArea)
    {
        if (m_isInVisionList.Count == 0)
            return true;

        foreach (KeyValuePair<Entity, IsInVisionArea> entry in m_isInVisionList)
        {
            if (entry.Value != checkIsInVisionArea)
                return false;
        }

        return true;
    }

    private void _HandleIsInVisionArea()
    {
        var player = GameManager.Instance.playerManager.GetMainPlayer();
        Vector3 targetPos = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        IsInVisionArea isInVisionArea = _GenerateIsInVision(targetPos);
        if (!m_isInVisionList.ContainsKey(player))
            m_isInVisionList.Add(player, isInVisionArea);
        else
            m_isInVisionList[player] = isInVisionArea;

        if (isInVisionArea != IsInVisionArea.OutOfArea)
        {
            if (alertTargetEntity == null)
                alertTargetEntity = player;
            else
                alertTargetEntity = (Vector3.Distance(player.transform.position, transform.position) < Vector3.Distance(alertTargetEntity.transform.position, transform.position)) ? player : alertTargetEntity;

            lastTargetPos = alertTargetEntity.transform.position;
        }
    }

    private void _HandleVisionLookMesh()
    {
        if (!_CheckPlayerIsCloseEnough())
        {
            m_visionLookMesh.Clear();
            return;
        }

        int rayCount = 360 / 5;
        float[] rayAngleClamp = { m_bot.transform.eulerAngles.y - m_coneAngle / 2, m_bot.transform.eulerAngles.y + m_coneAngle / 2 };
        rayAngleClamp[0] = (rayAngleClamp[0] < 0) ? 360.0f + rayAngleClamp[0] : rayAngleClamp[0];
        float angleIncrease = 360 / rayCount;
        int rayCountAlert = (360 / 5) / (360 / (int)m_coneAngle);

        float viewDistance = m_alertDistance + m_suspiciousDistance;
        Vector3 localOrigin = new Vector3(0.0f, -transform.localPosition.y + 0.1f, 0.0f);
        float viewDistanceAlert = m_alertDistance;
        Vector3 localOriginAlert = new Vector3(0.0f, -transform.localPosition.y + 0.05f, 0.0f);

        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];
        Vector3[] verticesAlert = new Vector3[rayCountAlert + 1 + 1];
        Vector2[] uvAlert = new Vector2[verticesAlert.Length];
        int[] trianglesAlert = new int[rayCountAlert * 3];

        vertices[0] = localOrigin;
        uv[0] = new Vector2(vertices[0].x, vertices[0].z);
        verticesAlert[0] = localOriginAlert;
        uvAlert[0] = new Vector2(verticesAlert[0].x, verticesAlert[0].z);

        float currentAngle = 0;
        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex;
            bool isInAngle = (rayAngleClamp[0] > rayAngleClamp[1]) ?
                !(currentAngle >= rayAngleClamp[1] && currentAngle <= rayAngleClamp[0]) :
                currentAngle >= rayAngleClamp[0] && currentAngle <= rayAngleClamp[1];
            if (isInAngle)
            {
                RaycastHit[] hits = Physics.RaycastAll(transform.position, _GenerateVectorFromAngle(currentAngle), viewDistance, Physics.AllLayers, QueryTriggerInteraction.Ignore);
                
                vertex = transform.InverseTransformPoint(transform.position + localOrigin + _GenerateVectorFromAngle(currentAngle) * viewDistance);
                if (hits.Length > 0)
                {
                    Array.Sort(hits, delegate (RaycastHit hit1, RaycastHit hit2) { return hit1.distance.CompareTo(hit2.distance); });
                    foreach (RaycastHit hit in hits)
                    {
                        if (hit.collider.GetComponent<TagVisionLook>())
                        {
                            var raycastHitPoint = transform.InverseTransformPoint(hit.point);
                            vertex = new Vector3(raycastHitPoint.x, localOrigin.y, raycastHitPoint.z);
                            break;
                        }
                    }
                }
            }
            else
            {
                vertex = transform.InverseTransformPoint(transform.position + localOrigin + _GenerateVectorFromAngle(currentAngle, 1.5f));
            }

            vertices[vertexIndex] = vertex;
            uv[vertexIndex] = new Vector2(vertices[vertexIndex].x, vertices[vertexIndex].z);

            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }

            vertexIndex++;
            currentAngle += angleIncrease;
        }

        currentAngle = rayAngleClamp[0];
        vertexIndex = 1;
        triangleIndex = 0;
        for (int i=0; i<= rayCountAlert; i++)
        {
            Vector3 vertexAlert;
            RaycastHit[] hitsAlert = Physics.RaycastAll(transform.position, _GenerateVectorFromAngle(currentAngle), viewDistanceAlert, Physics.AllLayers, QueryTriggerInteraction.Ignore);
            vertexAlert = transform.InverseTransformPoint(transform.position + localOriginAlert + _GenerateVectorFromAngle(currentAngle) * viewDistanceAlert);
            if (hitsAlert.Length > 0)
            {
                Array.Sort(hitsAlert, delegate (RaycastHit hit1, RaycastHit hit2) { return hit1.distance.CompareTo(hit2.distance); });
                foreach (RaycastHit hit in hitsAlert)
                {
                    if (hit.collider.GetComponent<TagVisionLook>())
                    {
                        var raycastHitPoint = transform.InverseTransformPoint(hit.point);
                        vertexAlert = new Vector3(raycastHitPoint.x, localOriginAlert.y, raycastHitPoint.z);
                        break;
                    }
                }
            }

            verticesAlert[vertexIndex] = vertexAlert;
            uvAlert[vertexIndex] = new Vector2(verticesAlert[vertexIndex].x, verticesAlert[vertexIndex].z);

            if (i > 0)
            {
                trianglesAlert[triangleIndex + 0] = 0;
                trianglesAlert[triangleIndex + 1] = vertexIndex - 1;
                trianglesAlert[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }

            vertexIndex++;
            currentAngle += angleIncrease;
        }

        m_visionLookMesh.vertices = vertices;
        m_visionLookMesh.uv = uv;
        m_visionLookMesh.triangles = triangles;
        m_visionLookMesh.bounds = new Bounds(transform.position, Vector3.one * 1000f);
        m_visionLookMeshAlert.vertices = verticesAlert;
        m_visionLookMeshAlert.uv = uvAlert;
        m_visionLookMeshAlert.triangles = trianglesAlert;
        m_visionLookMeshAlert.bounds = new Bounds(transform.position, Vector3.one * 1000f);

        float alertLevelPercent = 1.0f * m_bot.currentAlertLevel / m_bot.maxAlertLevel;
        Color meshColor = (m_bot.alertState == AlertStateEnum.Idle) ? new Color(1, 1, 1, 0.5f) :
            new Color(1, Color.yellow.g - alertLevelPercent , Color.yellow.b - alertLevelPercent, 0.5f);

        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material.SetColor("_EmissionColor", meshColor);
        m_alertMeshRenderer.material.color = meshColor;
    }

    private IsInVisionArea _GenerateIsInVision(Vector3 targetPos)
    {
        Vector3 targetDir = targetPos - transform.position;
        float maxVisionDistance = m_alertDistance + m_suspiciousDistance;

        bool isInCone = Vector3.Angle(targetDir, transform.forward) < m_coneAngle / 2 && targetDir.magnitude < maxVisionDistance;
        if (isInCone)
        {
            bool isClose = targetDir.magnitude < m_alertDistance;

            bool isVisible = true;
            RaycastHit[] hits = Physics.RaycastAll(transform.position, targetDir, Vector3.Distance(transform.position, targetPos), Physics.AllLayers, QueryTriggerInteraction.Ignore);
            if (hits.Length > 0)
            {
                Array.Sort(hits, delegate (RaycastHit hit1, RaycastHit hit2) { return hit1.distance.CompareTo(hit2.distance); });
                foreach (RaycastHit hit in hits)
                {
                    if (hit.collider.GetComponent<TagGridCollider>() || hit.collider.GetComponent<TagVisionLook>())
                    {
                        isVisible = false;
                        break;
                    }
                }
            }

            return (isVisible) ? ((isClose) ? IsInVisionArea.AlertArea : IsInVisionArea.SuspiciousArea) : IsInVisionArea.OutOfArea;
        }

        return (targetDir.magnitude <= 1.5f) ? IsInVisionArea.SuspiciousArea : IsInVisionArea.OutOfArea;
    }

    private Vector3 _GenerateVectorFromAngle(float angle, float zDistance = 1.0f)
    {
        return Quaternion.AngleAxis(angle, Vector3.up) * new Vector3(0.0f, 0.0f, zDistance);
    }

    private bool _CheckPlayerIsCloseEnough()
    {
        float viewDistance = m_alertDistance + m_suspiciousDistance;
        float cameraRadius = 20.0f / 2; // temporary, size camera / 2 palingan
        float distance = Vector3.Distance(m_mainPlayer.transform.position, m_bot.transform.position);

        return distance - viewDistance - cameraRadius <= 0.0f;
    }
}
