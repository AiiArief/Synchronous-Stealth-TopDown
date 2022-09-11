using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SimpleMovement : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera m_vcam;

    [SerializeField] float m_speed = 10.0f;
    [SerializeField] float m_scrollSensitivity = 3.0f;

    [SerializeField] string m_horizontalInputAxis = "Horizontal #0";
    [SerializeField] string m_verticalInputAxis = "Vertical #0";
    [SerializeField] string m_shootScreenshotButton = "Shoot #0";
    [SerializeField] string m_enableRotationButton = "Move Modifier #0";

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        m_vcam.enabled = Input.GetButton(m_enableRotationButton);

        m_speed += Input.mouseScrollDelta.y * m_scrollSensitivity;

        rb.rotation = Camera.main.transform.rotation;
        rb.velocity = transform.forward * Input.GetAxis(m_verticalInputAxis) * m_speed * Time.deltaTime + transform.right * Input.GetAxis(m_horizontalInputAxis) * m_speed * Time.deltaTime;

        if(Input.GetButtonDown(m_shootScreenshotButton))
            UnityEngine.ScreenCapture.CaptureScreenshot("last_win.png");
    }
}
