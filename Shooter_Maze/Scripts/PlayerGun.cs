using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    
    public GameObject bullet;
    public float ShootRate = 0.0001f;
    float shootTimer = 0f;
    public Transform ShootPoint;


    private void Start()
    {
        

    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.F) && shootTimer >= ShootRate || Input.GetAxisRaw("Fire1")>0 && shootTimer >= ShootRate)
        {
            shootTimer = 0f;
            Shoot();
        }

        
        shootTimer += Time.deltaTime;
        
    }

    private void Shoot()
    {
        GameObject pulia = Instantiate(bullet, ShootPoint.position, ShootPoint.rotation);
        Destroy(pulia, 3f);
    }
}
