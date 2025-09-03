using UnityEngine;
using UnityEngine.SceneManagement; 
public class GameControllerOEL : MonoBehaviour
{
    public static GameControllerOEL Instance { get; private set; } // Singleton instance
    public GameObject gameOverUI; // Assign a UI panel for Game Over
    private void Awake(){
        if (Instance == null){
            Instance = this;
        }
        else{
            Destroy(gameObject);
            return;
        }
    }

    public void GameOver(){
        if (gameOverUI != null)
            gameOverUI.SetActive(true); // Show Game Over UI
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
