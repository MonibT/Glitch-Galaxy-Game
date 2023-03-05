using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletprefab;
    public AudioSource GunSound;

    // Update is called once per frame
    void Update()
    {
       if (Input.GetButtonDown("Fire1"))
        {
            Shoot();

        }

       void Shoot()
        {
            GunSound.Play();
            Instantiate(bulletprefab, firePoint.position, firePoint.rotation);
        }
    }
}
