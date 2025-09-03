using UnityEngine;

public class EnemyManager : MonoBehaviour{
    public static EnemyManager instance;
    public string[] deathMessages;

    void Awake(){
        if (instance == null)
            instance = this;        
        else
            Destroy(gameObject);
   }

    public void showMessage(){
        int index = Random.Range(0,deathMessages.Length);
        Debug.Log(deathMessages[index]);
    }
}
