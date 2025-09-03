using UnityEngine;
namespace Lab7{
    public class Player : MonoBehaviour{
        public float movSpd = 1;

        void Start(){
            GetComponent<MeshRenderer>().material.color = Color.blue;
        }
        // Update is called once per frame
        void Update(){
            float h = Input.GetAxis("Horizontal")*movSpd*Time.deltaTime;
            float v = Input.GetAxis("Vertical")*movSpd*Time.deltaTime;
            transform.Translate(new Vector3(h, 0, v));
        }
    }
}