using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private EnemySpawner spawnerPrefab;
    [SerializeField] private float minSpawnDistance;
    [SerializeField] private float maxSpawnDistance;
    [SerializeField] private float spawnPoolSize;
    [SerializeField] private float spawnPoolNumber;
    [SerializeField] private float spawnTime;
    [SerializeField] private Transform plane;
    private GameObject _player;
    private float _nextWaveTimer;
    private float _waveNumber;
    
    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _waveNumber = 1;
        _nextWaveTimer = spawnTime;
    }

    private void Start()
    {
        SpawnEnemyWave();
    }

    // Update is called once per frame
    void Update()
    {
        // Record elapsed time
        _nextWaveTimer -= Time.deltaTime;
        
        // Automatic Spawning
        if (_nextWaveTimer <= 0)
        {
            for (int i = 0; i < spawnPoolNumber; i++)
            {
                SpawnEnemyWave();
            }
            
            // Increment wave number
            _waveNumber++;
            
            // Reset wave timer
            _nextWaveTimer = spawnTime;
            
            // Increase spawn pool size
            if (_waveNumber % 1 == 0)
            {
                spawnPoolSize += 0;
            }
            
            // Increase number of spawn pools
            if (_waveNumber % 3 == 0)
            {
                spawnPoolNumber += 1;
            }
        }
        
        // Manual Spawning Button
        if (Input.GetKeyDown(KeyCode.O))
        {
            Vector3 spawnPoolPosition;
            // Temp Spawn Logic
            do
            {
                spawnPoolPosition = plane.transform.position + (Random.onUnitSphere) * maxSpawnDistance;
                spawnPoolPosition.y = plane.transform.position.y + 1;
            } while ((_player.transform.position - spawnPoolPosition).sqrMagnitude <= minSpawnDistance * minSpawnDistance);

            for (int i = 0; i < spawnPoolSize; i++)
            {
                Vector3 spawnPosition = (Random.onUnitSphere * 3) + spawnPoolPosition;
                spawnPosition.y = spawnPoolPosition.y;
                Instantiate(spawnerPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }

    void SpawnEnemyWave()
    {
        Vector3 spawnPoolPosition;
        
        do
        {
            spawnPoolPosition = plane.transform.position + (Random.onUnitSphere) * maxSpawnDistance;
            spawnPoolPosition.y = plane.transform.position.y + 1;
        } while ((_player.transform.position - spawnPoolPosition).sqrMagnitude <= minSpawnDistance * minSpawnDistance);

        for (int i = 0; i < spawnPoolSize; i++)
        {
            Vector3 spawnPosition = (Random.onUnitSphere * 3) + spawnPoolPosition;
            spawnPosition.y = spawnPoolPosition.y;
            Instantiate(spawnerPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
