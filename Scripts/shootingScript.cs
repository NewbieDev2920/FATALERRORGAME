using UnityEngine;
using System.Collections.Generic;
using System;
using JetBrains.Annotations;

public class shootingScript : MonoBehaviour
{
    [SerializeField]// 0: Pistol, 1: Shotgun, 2: Knife, 3: Rifle
    float[] cooldownTimes;
    private Cooldown cooldown = new Cooldown();
    public GameObject knifeSlash;
    public float bulletSeparationShotgun;
    private Weapon equippedWeapon = Weapon.NONE;
    public Transform barrel;
    public GameObject bulletPrefab;
    [SerializeField]
    private GameObject shotgunBulletPrefab;
    public float bulletVel = 20f;
    [SerializeField]
    private Camera cam;
    Rigidbody2D rb;
    private Vector2 dir;
    
    [SerializeField]
    private GameObject healthManager;

    [SerializeField]
    private float shotgunAngleVariation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        cooldown.setCooldownTime(cooldownTimes[0]);
        knifeSlash.SetActive(false);
        dir = new Vector2(0,0);
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!cooldown.IsCoolingDown){
            knifeSlash.SetActive(false);
        }

        if(Input.GetKey(KeyCode.Mouse0) && !cooldown.IsCoolingDown && equippedWeapon == Weapon.RIFLE){
            Shoot();
            cooldown.StartCooldown();
        }

        if(Input.GetButtonDown("Fire1") && !cooldown.IsCoolingDown && equippedWeapon != Weapon.RIFLE){
            Shoot();
            
            cooldown.StartCooldown();
            
        }
        
    }
    void Shoot(){

        if(equippedWeapon == Weapon.PISTOL){
            dir.y = cam.ScreenToWorldPoint(Input.mousePosition).y - rb.position.y;
            dir.x = cam.ScreenToWorldPoint(Input.mousePosition).x - rb.position.x;
            dir.Normalize();
            GameObject bullet = Instantiate(bulletPrefab, barrel.position, barrel.rotation);
            bullet.GetComponent<bulletScript>().startMovement(dir, bulletVel);
        }else if(equippedWeapon == Weapon.RIFLE){
            dir.y = cam.ScreenToWorldPoint(Input.mousePosition).y - rb.position.y;
            dir.x = cam.ScreenToWorldPoint(Input.mousePosition).x - rb.position.x;
            dir.Normalize();
            GameObject bullet = Instantiate(bulletPrefab, barrel.position, barrel.rotation);
            bullet.GetComponent<bulletScript>().startMovement(dir, bulletVel);
        }
        else if(equippedWeapon == Weapon.SHOTGUN){
            for(int i = 0; i < 5; i++){
                dir.y = cam.ScreenToWorldPoint(Input.mousePosition).y - rb.position.y;
                dir.x = cam.ScreenToWorldPoint(Input.mousePosition).x - rb.position.x;
                dir.Normalize();
                Vector3 bulletVariation;
                if(barrel.rotation.eulerAngles.z >= 45 && barrel.rotation.eulerAngles.z <= 135 || barrel.rotation.eulerAngles.z >= 45+180 && barrel.rotation.eulerAngles.z <= 135+180){
                    bulletVariation = new Vector3(0,i*bulletSeparationShotgun -bulletSeparationShotgun,0);
                }
                else{
                    bulletVariation = new Vector3(i*bulletSeparationShotgun -bulletSeparationShotgun,0,0);
                }
                
                GameObject bullet = Instantiate(shotgunBulletPrefab, barrel.position + bulletVariation, barrel.rotation);
                bullet.GetComponent<shotgunBullet>().startMovement(dir, bulletVel);
            }
            
        }
        else if(equippedWeapon == Weapon.KNIFE){
            knifeSlash.SetActive(true);

        }else if(equippedWeapon == Weapon.NONE){
            Debug.Log("you dont have a weapon");
        }
        
    }

     public void EquipWeapon(Weapon w){
        if(w == Weapon.MEDKIT){
            healthManager.GetComponent<HealthManager>().playerHealed(40);
            return;
        }
        equippedWeapon = w;
            if(equippedWeapon == Weapon.PISTOL){
                cooldown.setCooldownTime(cooldownTimes[0]);
            }
            else if(equippedWeapon == Weapon.SHOTGUN){
                cooldown.setCooldownTime(cooldownTimes[1]);
            }
            else if(equippedWeapon == Weapon.KNIFE){
                cooldown.setCooldownTime(cooldownTimes[2]);
            }
            else if(equippedWeapon == Weapon.RIFLE){
                cooldown.setCooldownTime(cooldownTimes[3]);
            }
            
    }

        public void takeDamage(float dmgPoints){
        healthManager.GetComponent<HealthManager>().playerHurted(dmgPoints);
    }

    

    
}

public enum Weapon{
    KNIFE,
    PISTOL,
    RIFLE,
    SHOTGUN,
    NONE,
    MEDKIT

}
