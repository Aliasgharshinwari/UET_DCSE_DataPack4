using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lab7{    
public class EnemySpawner : MonoBehaviour
{
    [Tooltip("Object Prefab to spawn")]
    public GameObject enemyPrefab;

    [Tooltip("Number of objects spawn per second")]
    public float spawnRate = 1f;

    [Tooltip("Delay before 1st initial Spawn")]
    public float initialSpawnDelay = 1f;

    private GameObject player;

    public List<Vector2> points;
    private  Bounds bounds;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        float spawnFreq = 1/spawnRate;
        InvokeRepeating(nameof(SpawnOnCells),initialSpawnDelay,spawnFreq);
        Bounds bounds = gameObject.GetComponent<MeshRenderer>().bounds;
    }

    void SpawnEnemyOnBounds()
    {
        float x = Random.Range(bounds.min.x + 0.5f, bounds.max.x- 0.5f);
        float z = Random.Range(bounds.min.z + 0.5f, bounds.max.z- 0.5f);
        Vector3 spawnPos = new Vector3(x,1f,z);
        var enemySpawned = Instantiate(enemyPrefab, 
                                        spawnPos,Quaternion.identity);
    }

    void SpawnOnCells(){
        Bounds bounds = gameObject.GetComponent<MeshRenderer>().bounds;
        //Get Points
        for (int x = (int)bounds.min.x + 1; x < (int)bounds.max.x; x++){
            for (int z = (int)bounds.min.z + 1; z < (int)bounds.max.z; z++){
                if (Vector3.Distance(new Vector3(x, 0f, z), player.gameObject.transform.position) > 4){
                    points.Add(new Vector2(x,z));
                }
            }
        }

        //Vector3 spawnPos = points.OrderBy(x => Random.value).FirstOrDefault();
        int i = Random.Range(0,points.Count);
        Vector2 spawnPos = points[i];
        
        var enemySpawned = Instantiate(enemyPrefab, 
                            new Vector3(spawnPos.x, 0.5f,spawnPos.y),
                            Quaternion.identity);

    }

    void OnDrawGizmos(){

         for (int i = 0; i < points.Count; i++) {
            Vector3 cellPosition =  new Vector3(points[i].x, 0f,points[i].y);

            if (Vector3.Distance(cellPosition, player.gameObject.transform.position) > 4){
                Gizmos.DrawSphere(cellPosition, 0.25f); 
                Gizmos.DrawWireCube(cellPosition, Vector3.one);                       
            }
         }
    }
}

}