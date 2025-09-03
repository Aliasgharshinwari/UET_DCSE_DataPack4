using System.Collections.Generic;
using UnityEngine;

public class FollowerEnemy : MonoBehaviour
{
    [SerializeField] public string playerTag; // Tag will be selected in the custom inspector
    private GameObject player;
    private float distFromPlayer;
    public int AIRange = 10;
    private bool stop = false;
    public GameController gameController;
    public List<Vector3> circlePoints;
    public LineRenderer lr;
    

    void Start()
    {
        GetComponent<MeshRenderer>().material.color = Color.red;
        gameController = GameObject.FindObjectOfType<GameController>();
        if (!string.IsNullOrEmpty(playerTag))
        {
            player = GameObject.FindGameObjectWithTag(playerTag);
        }
        else
        {
            Debug.LogError("Player tag is not set!");
        }
    }

    void Update(){
        drawCircle();
        distFromPlayer = Vector3.Distance(transform.position, player.transform.position);


//        Debug.Log(distFromPlayer);
        if (distFromPlayer < AIRange && !stop){
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 1f * Time.deltaTime);
        }
    }
    void OnCollisionEnter(Collision collision){

        if (collision.gameObject.CompareTag(playerTag)){
            gameController.gameOver();
        }
    }

    public void StopEnemy(){
        stop = true;
    }

    public void drawCircle(){

        for (int x = 0; x < 10; x++){
            for (int y = 0; y < 10; y++)
            {
                
            }
        }
//        lr.SetPositions(circlePoints);
    }
}
