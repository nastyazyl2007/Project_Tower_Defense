using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorSpawner : MonoBehaviour
{
    [SerializeField] private GameObject warriorPrefab;
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private int maxWarriorsPerTower = 4;
    [SerializeField] private List<SpawnPoint> spawnPoints = new List<SpawnPoint>();

    private Dictionary<Tower_place, int> currentNumberOfSpawnedWarriors = new Dictionary<Tower_place, int>();

    [Serializable]
    public struct SpawnPoint
    {
        public Transform spawnLocation;
        public Transform towerLocation;
    }

    private void Start()
    {
        currentNumberOfSpawnedWarriors.Clear();
    }

    private void Update()
    {
        foreach (var point in spawnPoints)
        {
            if (point.spawnLocation == null || point.towerLocation == null)
                continue;

            Tower_place tower = point.towerLocation.GetComponent<Tower_place>();

            if (CanSpawnFromTower(tower))
            {
                StartCoroutine(SpawnWarrior(point, tower));
                break;
            }
        }
    }

    private bool CanSpawnFromTower(Tower_place tower)
    {
        if (tower == null || tower.empty)
            return false;

        int currentCount = currentNumberOfSpawnedWarriors.ContainsKey(tower) ? currentNumberOfSpawnedWarriors[tower] : 0;

        return currentCount < maxWarriorsPerTower;
    }

    private IEnumerator SpawnWarrior(SpawnPoint point, Tower_place tower)
    {
        yield return new WaitForSeconds(spawnInterval);

        if (!CanSpawnFromTower(tower))
            yield break;

        if (!currentNumberOfSpawnedWarriors.ContainsKey(tower))
            currentNumberOfSpawnedWarriors[tower] = 0;

        currentNumberOfSpawnedWarriors[tower]++;

        GameObject warrior = Instantiate(warriorPrefab, point.spawnLocation.position, Quaternion.identity);
    }
}