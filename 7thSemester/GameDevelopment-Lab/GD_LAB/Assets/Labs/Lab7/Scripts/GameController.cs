using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    RaycastHit hit;
    public Text ScoreText;
    public Text HighScoreText;
    public Text CountDownText;
    public int Counter = 3;
    public GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
        InvokeRepeating(nameof(CountDown),0f, 1f);              
        HighScoreText.text = "HighScore: " + ScoreManager.HighScore;
    }

    void Update(){

        ScoreText.text = "Score: " + ScoreManager.score;
        if (Input.GetMouseButton(0)){ //Total 7
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction);
            if (Physics.Raycast(ray, out hit)){
               
            //Debug.Log($"RAY{hit.transform.name}");
                if (hit.transform.gameObject.CompareTag("Enemy")){
                    hit.transform.GetComponent<FollowerEnemy>().StopEnemy();
                    Destroy(hit.transform.GetComponent<Rigidbody>());
                    Destroy(hit.transform.GetComponent<BoxCollider>());
                    Destroy(hit.transform.gameObject, 1f);
                    ScoreManager.score++;
                }
            }
        }
    }
    public void gameOver(){
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
        ScoreManager.SetHighScore();
    }

    public void gameUnPause(){
        Time.timeScale = 1;
    }
    public void CountDown(){
        CountDownText.text = Counter.ToString();
        Counter--;
        if (Counter < 0){
            CancelInvoke(nameof(CountDown));
            CountDownComplete();
        }
    }
    public void CountDownComplete(){
        CountDownText.gameObject.SetActive(false);
    }

    public void RestartGame(){
        Time.timeScale = 1;
        ScoreManager.Reset();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ExitGame(){
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
