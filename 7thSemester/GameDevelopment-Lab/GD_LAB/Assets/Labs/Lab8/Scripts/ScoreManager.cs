using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour{
    public static int score;
    public static int HighScore;
    public const string HighScoreKey = "HighScoreKey";
    void Awake(){
        DontDestroyOnLoad(this);
        score = 0;
        HighScore = PlayerPrefs.GetInt(HighScoreKey);
        Debug.Log("HighScore " +  HighScore);
    }

    public static void SetHighScore(){
        int CurrentHighScore = PlayerPrefs.GetInt(HighScoreKey, 0);
        if (CurrentHighScore < score){
            PlayerPrefs.SetInt(HighScoreKey, score);
            Debug.Log("Score Set to " +  score);
        }
    }

    public static void Reset(){
        score = 0;
        HighScore = PlayerPrefs.GetInt(HighScoreKey, 0);
    }
}
