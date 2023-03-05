using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject Enemybulletprefab;


    public Transform player;
    public Rigidbody2D rb;
    private void Start()
    {
       rb =  GetComponent<Rigidbody2D>();
    }

 


    public void Attack()
    {
        Shoot();

        void Shoot()
        {
            Instantiate(Enemybulletprefab, firePoint.position, firePoint.rotation);
        }
    }


    
}
