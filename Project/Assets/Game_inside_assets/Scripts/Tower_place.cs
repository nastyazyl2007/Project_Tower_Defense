using Unity.VisualScripting;
using UnityEngine;

public class Tower_place : MonoBehaviour
{
    [SerializeField] public GameObject[] towers;
    [SerializeField] public Vector3 offset;
    public GameObject current_tower;
    [SerializeField]  public int current_tower_number;
    public bool empty = true;

    private void Start()
    {
        if (towers != null)
        {
            Debug.Log("Все префабы башен добавлены!");
        }
        else
        {
            Debug.Log("Префабы башен не добавлены!!!");
        }
    }
    private void OnMouseDown()
    {
        if (empty)
        {
            current_tower = GameObject.Instantiate(towers[current_tower_number], transform.position + offset, Quaternion.identity) as GameObject;
            empty = false;
        }
    }
}