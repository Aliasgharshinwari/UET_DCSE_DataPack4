using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lab9
{
    public class GameOverCube : MonoBehaviour
    {

        public GameController gameController;
        void Start(){
            gameController = FindObjectOfType<GameController>();
        }

        void OnTriggerEnter(Collider other){
            if (other.gameObject.CompareTag("Ball")){
                gameController.GameOver();
            }
        }

    }
}
