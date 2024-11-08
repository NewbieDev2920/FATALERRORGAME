using UnityEngine;

public class shootingScript : MonoBehaviour
{
    public float bulletSeparationShotgun;
    public float bulletAngleShotgun;
    private Weapon equippedWeapon = Weapon.Pistol;
    public Transform barrel;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            Shoot();
        }
        if(Input.GetButtonDown("Fire2")){
            if(equippedWeapon == Weapon.Pistol){
                equippedWeapon = Weapon.Shotgun;
            }
            else{
                equippedWeapon = Weapon.Pistol;
            }
            
        }
    }

    void Shoot(){
        if(equippedWeapon == Weapon.Pistol){
            GameObject bullet = Instantiate(bulletPrefab, barrel.position, barrel.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(barrel.up * bulletForce, ForceMode2D.Impulse);
        }else if(equippedWeapon == Weapon.Rifle){

        }
        else if(equippedWeapon == Weapon.Shotgun){
            for(int i = 0; i < 3; i++){
                GameObject bullet = Instantiate(bulletPrefab, (barrel.position) + new Vector3((i * bulletSeparationShotgun) - bulletSeparationShotgun ,0,0), barrel.rotation);
                bullet.transform.Rotate(0,0,i* bulletAngleShotgun - bulletAngleShotgun);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(bullet.transform.up * bulletForce, ForceMode2D.Impulse);
            }
            
        }
        else if(equippedWeapon == Weapon.Knife){

        }
        
    }
}

enum Weapon{
    Knife,
    Pistol,
    Rifle,
    Shotgun
}
