using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OEL
{
    public class PlayerControllerOEL : MonoBehaviour
    {
        [SerializeField]
        private Animator playerAnimator;

        [SerializeField]
        private float speed = 1f;

        [SerializeField]
        private float rotationSpeed = 10f; // Determines how smooth the rotation is

        private Vector3 targetDirection;   // The direction the player is moving
        private Quaternion targetRotation; // The target rotation for the player
        public delegate void PunchDelegate();
        public delegate void KickDelegate();
        PunchDelegate kickDel;
        PunchDelegate punchDel;
        private bool isMoving = false;

        void Start()
        {
            // Assign the delegate to the Punch method
            punchDel = Punch;
            kickDel = Kick;

            Debug.Log(punchDel.Method);
            if (playerAnimator == null)
                playerAnimator = GetComponent<Animator>();

            targetDirection = Vector3.forward; // Default direction
        }

        void Update()
        {
            if (Input.GetKey(KeyCode.UpArrow) ||
                Input.GetKey(KeyCode.DownArrow) ||
                Input.GetKey(KeyCode.LeftArrow) ||
                Input.GetKey(KeyCode.RightArrow)
            ){
                playerAnimator.SetBool("Move", true);
                float h = Input.GetAxis("Horizontal");
                float v = Input.GetAxis("Vertical");

                playerAnimator.SetFloat("Horizontal", h);
                playerAnimator.SetFloat("Vertical", v);
                transform.Translate(new Vector3(h,0,v) * Time.deltaTime * speed);
            }
            
            //playerAnimator.SetBool("Move", false);
            /*
            playerAnimator.SetBool("Punching", false);
            playerAnimator.SetBool("Kicking", false);

            if (Input.GetKey(KeyCode.W))
                MoveCharacter(Vector3.forward);

            if (Input.GetKey(KeyCode.S))
                MoveCharacter(Vector3.back);

            if (Input.GetKey(KeyCode.A))
                MoveCharacter(Vector3.left);

            if (Input.GetKey(KeyCode.D))
                MoveCharacter(Vector3.right);

            if (Input.GetButton("up")){
                Debug.Log("UP PRESSED");
            }
            //Debug.Log(Input.GetMouseButton(0));
            // Use GetKeyDown to call the delegate once per key press
            if (Input.GetKeyDown(KeyCode.Q) && Input.GetMouseButton(0))
                punchDel?.Invoke();


            // Use GetKeyDown to call the delegate once per key press
            if (Input.GetKeyDown(KeyCode.E) && Input.GetMouseButton(0))
                kickDel?.Invoke();

            // Smoothly rotate the character to the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

            if (isMoving)
                // Move the character in the target direction
                transform.Translate(targetDirection * speed * Time.deltaTime, Space.World);
            */
        }

        public void MoveCharacter(Vector3 direction)
        {
            Debug.Log("MoveCharacter");
            // Set the target direction
            targetDirection = direction;

            // Calculate the target rotation based on the direction
            targetRotation = Quaternion.LookRotation(targetDirection);

            // Move the character in the target direction
            isMoving = true;
            playerAnimator.SetBool("Move", true);
        }

        public void StopCharacter()
        {
            isMoving = false;
            playerAnimator.SetBool("Move", false);
        }

        public void Punch()
        {
            playerAnimator.SetBool("Punching", true);
            Debug.Log("Punch"); // Check the Unity Console for this log message
        }
        public void Kick()
        {
            playerAnimator.SetBool("Kicking", true);
            Debug.Log("Kick"); // Check the Unity Console for this log message
        }

        public void OnMoveForward()
        {
            MoveCharacter(Vector3.forward);
        }

        public void OnMoveBackward()
        {
            MoveCharacter(Vector3.back);
        }

        public void OnMoveLeft()
        {
            MoveCharacter(Vector3.left);
        }

        public void OnMoveRight()
        {
            MoveCharacter(Vector3.right);
        }

        public void OnPunch()
        {
            punchDel?.Invoke();
        }

        public void OnKick()
        {
            kickDel?.Invoke();
        }

    }
}
