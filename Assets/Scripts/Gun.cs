using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed = 1f;
    [SerializeField] private Transform gunOffset;
    [SerializeField] private Counter ammoCounter;
    private bool Reloading = false;
    public int currentTotalAmmo = 42;
    public int currentAmmo = 7;
    public int magazineSize = 7;
    public int reloadTime = 2;
    void Update()
    {
        if(InputManager.Fire){
            Fire();
        }
        if(!Reloading){
            if(InputManager.Reload){
                if(currentTotalAmmo > 0 && currentAmmo < magazineSize){
                    Reloading = true;
                    Invoke("Reload", reloadTime);
                }
            }
        }
    }

    void FixedUpdate(){
        ammoCounter.SetValue(currentAmmo, magazineSize, "Ammo:", currentTotalAmmo);
    }

    private void Fire(){
        if(!Reloading){
            if(currentAmmo > 0){
                GameObject bullet = Instantiate(bulletPrefab, gunOffset.position, transform.rotation * Quaternion.Euler(0, 0, 90));
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.velocity = transform.right * bulletSpeed;
                currentAmmo--;
                GetComponentInChildren<Light2D>().intensity = 1;
                Invoke("LightOff", 0.05f);
            }
        }
    }

    private void Reload(){
        int ammoNeeded = magazineSize - currentAmmo;
        if(currentTotalAmmo >= ammoNeeded){
            currentTotalAmmo = currentTotalAmmo - ammoNeeded;
            currentAmmo = magazineSize;
        } else {
            currentAmmo += currentTotalAmmo;
            currentTotalAmmo = 0;
        }
        Reloading = false;
    }

    private void LightOff(){
        GetComponentInChildren<Light2D>().intensity = 0;
    }
}
