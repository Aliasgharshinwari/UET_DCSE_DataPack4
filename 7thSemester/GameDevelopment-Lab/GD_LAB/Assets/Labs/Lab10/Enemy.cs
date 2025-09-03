using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Lab10
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField]
        private Transform target;
        NavMeshAgent agent;
        Animator animator;
        HealthSystem enemyHealth;
        bool reached = false;
        bool actionExecuted = false; // Flag to ensure "reached" logic executes only once
                                
        [SerializeField]
        private int punchDamage = 10;

        // Reference to the hand collider
        [SerializeField]
        private Collider leftHandCollider; // Assign this in the Inspector to the hand's collider
        [SerializeField]
        private Collider rightHandCollider; // Assign this in the Inspector to the hand's collider
        [SerializeField]
        private float punchActiveTime = 0.2f;
        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
            agent = GetComponent<NavMeshAgent>();
            if (target == null)
                target = GameObject.FindGameObjectWithTag("Player").transform;
            
            if (enemyHealth == null)
                enemyHealth = GetComponent<HealthSystem>();

        }

        // Update is called once per frame
        void Update()
        {
            if (target == null)
                return;
            
            if (enemyHealth.isDead() )
            {
                animator.SetBool("isDead", true);
                return;
            }
            float distance = Vector3.Distance(transform.position, target.position);

            if (distance < 5 && distance > 0.75f)
            {
                animator.SetBool("Walk", true);
                animator.SetBool("Punch", false);
                agent.SetDestination(target.position);
                reached = false; // Reset reached if player moves away
                actionExecuted = false; // Reset flag to allow re-execution
            }
            else if (distance < 0.75f && !reached)
            {
                reached = true; // Mark as reached
            }

            if (reached && !actionExecuted)
            {
                actionExecuted = true;
                animator.SetBool("Walk", false);
                if (target.GetComponent<HealthSystem>().isDead())
                {
                    animator.SetBool("Punch", false);
                    agent.SetDestination(transform.position);
                    
                }
                else
                {
                    animator.SetBool("Punch", true);
                    agent.SetDestination(transform.position);
                    
                }
            }
        }
        void OnTriggerEnter(Collider other){
            if (other.gameObject.CompareTag("PlayerCollider"))
            {
                enemyHealth.SubtractHealth(100);
                Debug.Log("ENEMY HURT");
                
            }
        }

        // This method will be called by the animation event to enable the punch collider
        public void EnableLeftPunchCollider()
        {
            if (leftHandCollider != null)
            {
                leftHandCollider.enabled = true; // Enable the collider during the punch
            }
            Debug.Log("EnableLeftPunchCollider");

            StartCoroutine(DisablePunchColliderAfterDelay(0));
        }


        // This method will be called by the animation event to enable the punch collider
        public void EnableRightPunchCollider()
        {
            if (rightHandCollider != null)
            {
                rightHandCollider.enabled = true; // Enable the collider during the punch
            }
            Debug.Log("EnableRightPunchCollider");
            StartCoroutine(DisablePunchColliderAfterDelay(1));
        }

        // This method will be called by the animation event to disable the punch collider after the punch
        // Coroutine to disable the collider after a delay
        private IEnumerator DisablePunchColliderAfterDelay(int handCollider)
        {
            yield return new WaitForSeconds(punchActiveTime); // Wait for the specified time
            if (handCollider == 0)
            {
                leftHandCollider.enabled = false; // Disable the collider after the delay
            }
            else{
                rightHandCollider.enabled = false; // Disable the collider after the delay
                
            }
        }
    }
}
