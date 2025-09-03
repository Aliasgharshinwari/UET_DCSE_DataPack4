using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace LabOEL
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Animator playerAnimator;
        [SerializeField] private HealthSystem playerHealth;
        [SerializeField] private float speed = 1f;
        [SerializeField] private float rotationSpeed = 10f; // Smooth rotation factor

        // UI Buttons
        public Button upBtn, downBtn, leftBtn, rightBtn, stopBtn;
        private Vector3 targetDirection = Vector3.forward; // Default movement direction
        private Quaternion targetRotation;
        private bool isMoving = false;
        // Delegates for punch & kick actions
        public delegate void PunchDelegate();
        public delegate void KickDelegate();
        private PunchDelegate punchDel;
        private KickDelegate kickDel;
        public Collider punchCollider;
        public Collider kickCollider;
        public float punchActiveTime = 0.2f;
        private void Start()
        {
            // Assign punch and kick actions to delegates
            punchDel = Punch;
            kickDel = Kick;

            if (playerAnimator == null)
                playerAnimator = GetComponent<Animator>();

            if (playerHealth == null)
                playerHealth = GetComponent<HealthSystem>();

            // Setup UI Button event listeners
            SetupButton(upBtn, Vector3.forward);
            SetupButton(downBtn, Vector3.back);
            SetupButton(leftBtn, Vector3.left);
            SetupButton(rightBtn, Vector3.right);
            stopBtn.onClick.AddListener(StopCharacter);
        }

        private void Update()
        {
            if (playerHealth.isDead() )
            {
                playerAnimator.SetBool("isDead", true);
                return;
            }
            // Reset animations
            playerAnimator.SetBool("Punching", false);
            playerAnimator.SetBool("Kicking", false);

            // Keyboard movement (optional)
            if (Input.GetKey(KeyCode.W)) MoveCharacter(Vector3.forward);
            if (Input.GetKey(KeyCode.S)) MoveCharacter(Vector3.back);
            if (Input.GetKey(KeyCode.A)) MoveCharacter(Vector3.left);
            if (Input.GetKey(KeyCode.D)) MoveCharacter(Vector3.right);

            // Punch & Kick actions
            if (Input.GetKeyDown(KeyCode.Q) && Input.GetMouseButton(0)) punchDel?.Invoke();
            if (Input.GetKeyDown(KeyCode.E) && Input.GetMouseButton(0)) kickDel?.Invoke();

            // Smoothly rotate the player towards movement direction
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

            // Move player if moving
            if (isMoving)
                transform.Translate(targetDirection * speed * Time.deltaTime, Space.World);
        }

        private void SetupButton(Button button, Vector3 direction)
        {
            button.onClick.AddListener(() => MoveCharacter(direction));
        }

        public void MoveCharacter(Vector3 direction)
        {
            Debug.Log("MoveCharacter");
            targetDirection = direction;
            targetRotation = Quaternion.LookRotation(targetDirection);
            isMoving = true;
            playerAnimator.SetBool("Move", true);
        }

        public void StopCharacter()
        {
            isMoving = false;
            playerAnimator.SetBool("Move", false);
            Debug.Log("StopCharacter");
        }

        public void Punch()
        {
            playerAnimator.SetBool("Punching", true);
            Debug.Log("Punch");
        }

        public void Kick()
        {
            playerAnimator.SetBool("Kicking", true);
            Debug.Log("Kick");
        }
         void OnTriggerEnter(Collider other){
                playerHealth.SubtractHealth(10);
        }

        

        // This method will be called by the animation event to enable the punch collider
        public void EnablePunchCollider()
        {
            if (punchCollider != null)
            {
                punchCollider.enabled = true; // Enable the collider during the punch
            }
            Debug.Log("punchCollider");

            StartCoroutine(DisableColliderAfterDelay(0));
        }
        // This method will be called by the animation event to enable the punch collider
        public void EnableKickCollider()
        {
            if (kickCollider != null)
            {
                kickCollider.enabled = true; // Enable the collider during the punch
            }
            Debug.Log("kickCollider");

            StartCoroutine(DisableColliderAfterDelay(1));
        }

       // This method will be called by the animation event to disable the punch collider after the punch
        // Coroutine to disable the collider after a delay
        private IEnumerator DisableColliderAfterDelay(int colNo)
        {
            yield return new WaitForSeconds(punchActiveTime); // Wait for the specified time
            if (colNo == 0)
            {
                punchCollider.enabled = false; // Disable the collider after the delay
            }
            else{
                kickCollider.enabled = false; // Disable the collider after the delay
                
            }
        }
    }
}
