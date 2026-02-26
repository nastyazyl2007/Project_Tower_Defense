using System;
using System.Collections;
using UnityEngine;

public class Wave_spawn : MonoBehaviour
{
    public int enemy_number;      
    public int wave_number;      
    public GameObject enemy_type;
    public float spawn_enemy_interval;     
    public float time_between_waves;       
    public Transform spawn_point;
    public Transform[] way_point;
    public float time_before_first_wave;  

    private int enemies_spawned_in_current_wave = 0;
    private int current_wave_number = 0;
    private bool is_spawning_wave = false;

    void Start()
    {
        Invoke("StartNextWave", time_before_first_wave);
    }

    void StartNextWave()
    {

        current_wave_number++;
        enemies_spawned_in_current_wave = 0;  
        is_spawning_wave = true;

        Debug.Log($"Начинается волна {current_wave_number}/{wave_number}");

        InvokeRepeating("SpawnEnemyInCurrentWave", 0f, spawn_enemy_interval);
    }

    void SpawnEnemyInCurrentWave()
    {
        if (enemies_spawned_in_current_wave >= enemy_number)
        {
            CancelInvoke("SpawnEnemyInCurrentWave");
            is_spawning_wave = false;
            if (current_wave_number < wave_number)
            {
                Invoke("StartNextWave", time_between_waves);
            }
            return;
        }

        enemies_spawned_in_current_wave++;
        GameObject enemy =Instantiate(enemy_type, spawn_point.position, Quaternion.identity);
        enemy.GetComponent<Move_from_point_to_point>().point = way_point;

        Debug.Log($"Волна {current_wave_number}: создан враг {enemies_spawned_in_current_wave}/{enemy_number}");
    }
}
