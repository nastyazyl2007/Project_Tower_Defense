using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    public float minX, maxX, minZ, maxZ;

    [Header("Mouse Movement Settings")]
    public float sensitivity = 5f;
    public float keyboardSpeed = 5f;

    private Vector3 last_mouse_position;
    private Transform cameraTransform;

    void Start()
    {
        cameraTransform = transform;
    }

    void Update()
    {
        KeyboardMovement();
        MouseMovement();
    }

    void KeyboardMovement()
    {
        Vector3 movement = GetKeyboardInput();
        if (movement != Vector3.zero)
        {
            Vector3 newPosition = cameraTransform.position + movement;

            if (IsWithinBounds(newPosition))
            {
                cameraTransform.position = newPosition;
            }
        }
    }

    void MouseMovement()
    {
        if (Input.GetMouseButtonDown(2))
        {
            last_mouse_position = Input.mousePosition;
        }

        if (Input.GetMouseButton(2))
        {
            Vector3 delta = Input.mousePosition - last_mouse_position;

            float moveX = -delta.x * sensitivity * Time.deltaTime;
            float moveZ = -delta.y * sensitivity * Time.deltaTime;

            Vector3 newPosition = cameraTransform.position + new Vector3(moveX, 0, moveZ);

            if (IsWithinBounds(newPosition))
            {
                cameraTransform.Translate(moveX, 0, moveZ, Space.World);
            }

            last_mouse_position = Input.mousePosition;
        }
    }

    bool IsWithinBounds(Vector3 position)
    {
        return position.x >= minX && position.x <= maxX &&
               position.z >= minZ && position.z <= maxZ;
    }

    Vector3 GetKeyboardInput()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        return new Vector3(moveX, 0, moveZ) * keyboardSpeed * Time.deltaTime;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;

        Vector3 center = new Vector3((minX + maxX) / 2, transform.position.y, (minZ + maxZ) / 2);
        Vector3 size = new Vector3(maxX - minX, 1, maxZ - minZ);

        Gizmos.DrawWireCube(center, size);

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(new Vector3(minX, transform.position.y, minZ), 0.1f);
        Gizmos.DrawSphere(new Vector3(maxX, transform.position.y, minZ), 0.1f);
        Gizmos.DrawSphere(new Vector3(minX, transform.position.y, maxZ), 0.1f);
        Gizmos.DrawSphere(new Vector3(maxX, transform.position.y, maxZ), 0.1f);
    }
}