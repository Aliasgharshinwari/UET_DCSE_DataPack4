using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LectureNew7 : MonoBehaviour
{
    RaycastHit hit;
    public Text ScoreText;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("HighScore", 0);
        //Invoke(nameof(gamePause), 5f);    
    }

    void Update(){

        ScoreText.text = "Score: " + score;
        if (Input.GetMouseButton(0)){ //Total 7
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction);
            if (Physics.Raycast(ray, out hit)){
               
            Debug.Log($"RAY{hit.transform.name}");
                if (hit.transform.gameObject.CompareTag("Enemy")){
                    Destroy(hit.transform.gameObject);
                    score++;
                }

            }
 
        }
    }

    void gamePause(){
        PlayerPrefs.SetInt("HighScore", score);
        Time.timeScale = 0;
        Debug.Log("Game Paused");
    }

    void gameUnPause(){
        Time.timeScale = 1;
        Debug.Log("Game Un Paused");
    }
}
