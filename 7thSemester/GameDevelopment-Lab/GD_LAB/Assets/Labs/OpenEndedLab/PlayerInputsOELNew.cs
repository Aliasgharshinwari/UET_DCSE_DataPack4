using UnityEngine;
using UnityEngine.UI;

namespace LabOEL
{
    public class PlayerInputsOELNew : MonoBehaviour
    {
        public Lab9.PlayerController playerController;
        public Button upBtn, downBtn, leftBtn, rightBtn, stopBtn;
        
        private Vector3 moveDirection = Vector3.zero;
        private bool isMoving = false;

        void Start()
        {
            if (playerController == null)
                playerController = GetComponent<Lab9.PlayerController>();

            // Assign button click events
            upBtn.onClick.AddListener(() => MoveCharacter(Vector3.forward));
            downBtn.onClick.AddListener(() => MoveCharacter(Vector3.back));
            leftBtn.onClick.AddListener(() => MoveCharacter(Vector3.left));
            rightBtn.onClick.AddListener(() => MoveCharacter(Vector3.right));

            // Stop button stops movement immediately
            stopBtn.onClick.AddListener(StopCharacter);
        }

        void Update()
        {
            if (isMoving)
                playerController.MoveCharacter(moveDirection);
        }


        private void MoveCharacter(Vector3 direction)
        {
            moveDirection = direction;
            isMoving = true;
        }

        private void StopCharacter()
        {
            playerController.StopCharacter();
           
        }
    }
}
