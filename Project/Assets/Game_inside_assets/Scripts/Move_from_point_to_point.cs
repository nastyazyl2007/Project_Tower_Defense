using UnityEngine;
using System.Collections;

public class Move_from_point_to_point : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] public Transform[] point;
    int current_waypoint_index = 0;

    void Update()
    {
        if (current_waypoint_index < point.Length) {
            transform.position = Vector3.MoveTowards(transform.position, point[current_waypoint_index].position,Time.deltaTime * speed);
            if (Vector3.Distance(transform.position, point[current_waypoint_index].position) < 0.1f) current_waypoint_index++;
        }
    }
}
