using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Lab9
{
    
    public class GameController : MonoBehaviour
    {
        public Button playButton;
        public GameObject mainPanel, gameCompletePanel, gameOverPanel;
        public Animator mainMenuAnimator;
        void Awake(){
            playButton.onClick.AddListener(()=> OnPlayPressed());
            mainMenuAnimator = mainPanel.GetComponent<Animator>();
        }

        void Start()
        {
            Time.timeScale = 0;
            mainMenuAnimator.SetBool("CloseMenu",false);   
        }

        void OnPlayPressed(){
            Time.timeScale = 1;
            mainMenuAnimator.SetBool("CloseMenu",true);
        }
        public void GameComplete(){
            Time.timeScale = 0;
            gameCompletePanel.SetActive(true);
        }
        public void GameOver(){
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }
    }
}