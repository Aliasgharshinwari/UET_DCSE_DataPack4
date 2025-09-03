using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class EnemySpawner : MonoBehaviour
{
    [Tooltip("Object Prefab to spawn")]
    public GameObject enemyPrefab;

    [Tooltip("Number of objects spawn per second")]
    public float spawnRate = 1f;

    [Tooltip("Delay before 1st initial Spawn")]
    public float initialSpawnDelay = 1f;

    public List<Vector2> points;
    // Start is called before the first frame update
    void Start()
    {
        float spawnFreq = 1/spawnRate;
        //InvokeRepeating(nameof(SpawnEnemyOnBounds),1f,spawnFreq);
        InvokeRepeating(nameof(SpawnOnCells),1f,spawnFreq);
    }

    void SpawnEnemyOnBounds()
    {
        Bounds bounds = gameObject.GetComponent<MeshRenderer>().bounds;
        float x = Random.Range(bounds.min.x + 0.5f, bounds.max.x- 0.5f);
        float z = Random.Range(bounds.min.z + 0.5f, bounds.max.z- 0.5f);
        Vector3 spawnPos = new Vector3(x,0f,z);
        var enemySpawned = Instantiate(enemyPrefab, 
                                        spawnPos,Quaternion.identity);
    }

    void SpawnOnCells(){
        Bounds bounds = gameObject.GetComponent<MeshRenderer>().bounds;
        //Get Points
        for (int x = (int)bounds.min.x + 1; x < (int)bounds.max.x; x++){
            for (int z = (int)bounds.min.z + 1; z < (int)bounds.max.z; z++){
                points.Add(new Vector2(x,z));
            }
        }

        //Vector3 spawnPos = points.OrderBy(x => Random.value).FirstOrDefault();
        int i = Random.Range(0,points.Count);
        Vector2 spawnPos = points[i];
        
        var enemySpawned = Instantiate(enemyPrefab, 
                            new Vector3(spawnPos.x, 0f,spawnPos.y),
                            Quaternion.identity);

    }

    void OnDrawGizmos(){

         for (int i = 0; i < points.Count; i++) {
             Gizmos.DrawSphere(new Vector3(points[i].x, 0f,points[i].y) , 
                                0.25f); 
            Gizmos.DrawWireCube(new Vector3(points[i].x, 0f,points[i].y), 
                                Vector3.one);       
         }
    }
}
