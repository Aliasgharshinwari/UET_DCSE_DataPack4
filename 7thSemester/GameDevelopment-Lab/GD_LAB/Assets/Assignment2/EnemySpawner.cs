using UnityEngine;

namespace Assignment2{
    
public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 1f;
    public Vector3 planeSize = new Vector3(5, 0, 5); 

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        // Generate random position within plane bounds
        float x = Random.Range(-planeSize.x / 2, planeSize.x / 2);
        float z = Random.Range(-planeSize.z / 2, planeSize.z / 2);
        Vector3 spawnPosition = new Vector3(x, 0.5f, z); // Slightly above the plane

        // Instantiate the enemy and destroy it after 2 seconds
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        Destroy(enemy, 2f);
    }
}

}