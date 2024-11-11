using UnityEngine;

public class trainingShooter : MonoBehaviour
{

    [SerializeField]
    private GameObject bulletPrefab;
    private Cooldown cooldown = new Cooldown();
    private Vector2 dir;
    private Transform tr;

    void Start(){
        tr = gameObject.GetComponent<Transform>();
        dir = new Vector2(0, -1);
        cooldown.setCooldownTime(2f);
    }
    // Update is called once per frame
    void Update()
    {
        if(!cooldown.IsCoolingDown){
            GameObject bullet = Instantiate(bulletPrefab, tr.position, tr.rotation);
            bullet.GetComponent<bulletScript>().startMovement(dir, 20f);
            cooldown.StartCooldown();
        }
    }
}
