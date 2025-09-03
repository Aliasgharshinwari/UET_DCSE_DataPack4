using UnityEngine;

public class Enemy : MonoBehaviour{
    
    void OnCollisionEnter(Collision other){
        var rendrer = gameObject.GetComponent<MeshRenderer>();
        rendrer.material.color = Color.yellow;
        InvokeRepeating(nameof(DieEffect),1f,0.5f);
    }

     void DieEffect(){
        Destroy(gameObject);
        EnemyManager.instance.showMessage();
     }
}
