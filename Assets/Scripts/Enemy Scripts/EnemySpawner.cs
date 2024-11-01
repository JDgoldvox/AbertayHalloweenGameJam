using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyBase[] enemyPrefabs;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length - 1)], transform.position, Quaternion.identity);
        
        Destroy(gameObject);
    }
}
