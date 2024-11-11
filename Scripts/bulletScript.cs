using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.UIElements;

public class bulletScript : MonoBehaviour
{
    [SerializeField]
    private float dmgPoints;
    private Vector2 direction = new Vector2(0,0);
    Transform tr;
    private float speed = 0;
    //PONER ANIMACION DE EXPLOSION DE BALA

    void Awake(){
        tr = gameObject.GetComponent<Transform>();
    }
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "wall"){
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag == "Player"){
            Debug.Log("Golpeado!");
            collision.gameObject.GetComponent<shootingScript>().takeDamage(dmgPoints);
            Destroy(gameObject);
        }
        
    }

    void FixedUpdate(){
       
    }

    public void startMovement(Vector2 d, float s){
        direction = d;
        speed = s;
    }

    public void move(){
         tr.position += new Vector3(direction.x, direction.y, 0) * speed * Time.fixedDeltaTime;
    }
}
