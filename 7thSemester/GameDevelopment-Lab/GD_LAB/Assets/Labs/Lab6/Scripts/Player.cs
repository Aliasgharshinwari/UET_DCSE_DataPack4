using UnityEngine;
namespace Lab6{
    public class Player : MonoBehaviour{
        RaycastHit hit;
        public GameObject bulletPrefab;
        GameObject bulletContainer;
        public Transform spawnPoint;
        public float movSpd = 1;

        // Update is called once per frame
        void Update(){
            float h = Input.GetAxis("Horizontal")*movSpd*Time.deltaTime;
            float v = Input.GetAxis("Vertical")*movSpd*Time.deltaTime;

            transform.Translate(new Vector3(h, 0, v));

            if (Physics.Raycast(spawnPoint.position, 
                Vector3.forward, out hit, Mathf.Infinity)){
                Debug.DrawRay(spawnPoint.position, 
                                Vector3.forward * hit.distance, 
                                Color.red);
            }

            if (Input.GetKeyDown(KeyCode.F)){
                bulletContainer = Instantiate(bulletPrefab, 
                                            spawnPoint.position, 
                                            spawnPoint.rotation);
                Rigidbody bullet_rb = bulletContainer.GetComponent<Rigidbody>();
                bullet_rb.AddForce(transform.forward * 10000f);
            }
        }
    }
}