using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Camera_Movement : MonoBehaviour
{
    public Transform camera_position;
    public float sensitivity; 

    private Vector3 last_mouse_position;

    void Update()
    {
        moveCamera();
    }

    private void moveCamera()
    {
        if (Input.GetMouseButtonDown(2))
        {
            last_mouse_position = Input.mousePosition;
        }

        if (Input.GetMouseButton(2))
        {
            Vector3 delta = Input.mousePosition - last_mouse_position;
            camera_position.Translate(-delta.x * sensitivity * Time.deltaTime,0, -delta.y * sensitivity * Time.deltaTime);
            last_mouse_position = Input.mousePosition;
        }
    }
}