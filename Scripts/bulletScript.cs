using UnityEngine;

public class bulletScript : MonoBehaviour
{
    //PONER ANIMACION DE EXPLOSION DE BALA
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "wall"){
            Destroy(gameObject);
        }
        
    }
}
