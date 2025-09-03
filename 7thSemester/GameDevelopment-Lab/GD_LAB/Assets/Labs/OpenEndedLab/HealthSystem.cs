using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    private int MaxHealth = 100;
    [SerializeField]
    public int currentHealth = 0;
    public Slider healthSlider;

    void Awake(){
        currentHealth = MaxHealth;
        healthSlider.maxValue = MaxHealth;
        healthSlider.value = currentHealth;
    }

    public void SubtractHealth(int amount){
        currentHealth -= amount;
        if (currentHealth <= 0){
            Die();
            healthSlider.value = 0;
        }
        healthSlider.value = currentHealth;
    }

    void Die(){
        GameControllerOEL.Instance.GameOver();
        Debug.Log("DIED");
    }

    public bool isDead(){
        if (currentHealth <= 0){
            return true;
        }
        else{
            return false;
        }
    }
}
