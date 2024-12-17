using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed = 1f;
    [SerializeField] private Transform gunOffset;
    void Update()
    {
        if(InputManager.Fire){
            Fire();
        }
    }

    private void Fire(){
        Vector3 bulletPosition = new Vector3(gunOffset.position.x, gunOffset.position.y, transform.position.z);
        GameObject bullet = Instantiate(bulletPrefab, bulletPosition, transform.rotation * Quaternion.Euler(0, 0, 90));
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * bulletSpeed;
    }
}
