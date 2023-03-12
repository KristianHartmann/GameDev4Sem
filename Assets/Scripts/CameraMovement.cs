using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
 
    public float speed = 10.0f;

    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var transform1 = transform;
        transform1.position = transform1.position + new Vector3(horizontal, 0, vertical) * (speed * Time.deltaTime);
    }

}
