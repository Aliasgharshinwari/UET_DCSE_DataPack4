using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewLecture8 : MonoBehaviour
{
    void Start(){
        
    }
   public void BtnPressed(){
    //SceneManager.LoadScene(1);
    AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
    if (!asyncOperation.isDone)
    {
        Debug.Log("progess " + asyncOperation.progress);
        
    }
    //Scene scene = SceneManager.GetActiveScene();
    //Debug.Log(scene.buildIndex);
   }
}
