using UnityEngine;

public class BulletScript : MonoBehaviour
{
    //PONER ANIMACION DE EXPLOSION DE BALA
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Wall"){
            Destroy(gameObject);
        }
        
    }
}
