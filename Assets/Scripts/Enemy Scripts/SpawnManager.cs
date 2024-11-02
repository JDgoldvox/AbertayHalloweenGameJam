using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private EnemySpawner spawnerPrefab;
    [SerializeField] private float minSpawnDistance;
    [SerializeField] private float maxSpawnDistance;
    [SerializeField] private float spawnPoolSize;
    private GameObject _player;
    
    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 spawnPoolPosition;
            // Temp Spawn Logic
            do
            {
                spawnPoolPosition = (Random.onUnitSphere) * maxSpawnDistance;
            } while ((_player.transform.position - spawnPoolPosition).sqrMagnitude <= minSpawnDistance * minSpawnDistance);

            spawnPoolPosition.y = 1;

            for (int i = 0; i < spawnPoolSize; i++)
            {
                Vector3 spawnPosition = (Random.onUnitSphere * 3) + spawnPoolPosition;
                spawnPosition.y = spawnPoolPosition.y;
                Instantiate(spawnerPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }
}
