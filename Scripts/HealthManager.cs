using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField]
   private Image healthBar;
   private float currentHealth;

   void Start(){
        currentHealth = 100;
   }

   public void playerHurted(float damage){
        currentHealth -= damage;
        healthBar.fillAmount = currentHealth / 100; 
   }

   public void playerHealed(float health){
        currentHealth += health;
        currentHealth = Mathf.Clamp(currentHealth,0,100);
        healthBar.fillAmount = currentHealth /100;
        
   }
}
