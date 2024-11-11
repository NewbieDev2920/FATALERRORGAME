using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private Weapon item;
    private void OnTriggerStay2D(Collider2D collision){
        if(Input.GetKey(KeyCode.C)){
            collision.gameObject.GetComponent<shootingScript>().EquipWeapon(item);
            Destroy(gameObject);
        }
        
    }
}
