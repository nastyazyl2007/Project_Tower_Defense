using UnityEngine;

public class Tower_place : MonoBehaviour
{

    [SerializeField] public GameObject tower;
    public bool empty = true;
    public Vector3 offset;
    public GameObject current_tower;

    void Start()
    {
        if (tower == null)
        {
            Debug.LogError("Prefab башни не назначен в инспекторе!");
        }
        else
        {
            Debug.Log("Prefab башни назначен: " + tower.name);
        }
    }
    void OnMouseDown()
    {
        if (empty)
        {
            current_tower = GameObject.Instantiate(tower, transform.position + offset, Quaternion.identity) as GameObject;
            empty = false;
        }
    }
}
