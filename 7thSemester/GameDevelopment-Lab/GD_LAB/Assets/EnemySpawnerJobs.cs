using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using Unity.Burst;
using UnityEngine;

public class EnemySpawnerJobs : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate = 1f;

    private NativeArray<Vector2> points;
    private List<GameObject> spawnedEnemies = new List<GameObject>();

    private Bounds bounds;

    void Start()
    {
        bounds = gameObject.GetComponent<MeshRenderer>().bounds;

        // Calculate the number of points within the bounds and initialize the array
        int pointCount = ((int)(bounds.max.x - bounds.min.x) - 1) * ((int)(bounds.max.z - bounds.min.z) - 1);
        points = new NativeArray<Vector2>(pointCount, Allocator.Persistent);

        // Set the spawn rate
        spawnRate = 1 / spawnRate;

        // Schedule repeating spawning
        InvokeRepeating(nameof(SpawnOnCells), 1f, spawnRate);
    }

    void SpawnOnCells()
    {
        // Job to populate grid points within bounds
        var pointGenerationJob = new PointGenerationJob
        {
            boundsMin = new Vector2(bounds.min.x, bounds.min.z),
            boundsMax = new Vector2(bounds.max.x, bounds.max.z),
            points = points
        };
        JobHandle pointHandle = pointGenerationJob.Schedule(points.Length, 64);
        
        // Complete job and proceed with enemy spawning
        pointHandle.Complete();

        // Select a random point
        Vector2 randomPoint = points[Random.Range(0, points.Length)];
        Vector3 spawnPos = new Vector3(randomPoint.x, 0f, randomPoint.y);

        // Spawn the enemy on the main thread
        var enemySpawned = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        spawnedEnemies.Add(enemySpawned);
    }

    private void OnDestroy()
    {
        // Dispose of the native array when the script is destroyed
        if (points.IsCreated)
        {
            points.Dispose();
        }
    }

//    [BurstCompile]
    struct PointGenerationJob : IJobParallelFor
    {
        public Vector2 boundsMin;
        public Vector2 boundsMax;
        public NativeArray<Vector2> points;

        public void Execute(int index)
        {
            int width = (int)(boundsMax.x - boundsMin.x) - 1;
            int x = index % width + (int)boundsMin.x + 1;
            int z = index / width + (int)boundsMin.y + 1;

            points[index] = new Vector2(x, z);
        }
    }
}
