using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    private Transform m_mainCameraTransform;

    private void Start()
    {
        m_mainCameraTransform = Camera.main.transform;
    }

    private void LateUpdate()
    {
        transform.LookAt(
            transform.position + m_mainCameraTransform.rotation * Vector3.forward, 
            m_mainCameraTransform.rotation * Vector3.up);
    }
    

}
