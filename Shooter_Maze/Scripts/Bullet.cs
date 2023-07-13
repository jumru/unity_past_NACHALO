using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed;
    private float time = 5f;

    void Update()
    {
       
        transform.position += transform.forward * Speed * Time.deltaTime;

        if (time <= 0f) { Destroy(gameObject); }
        else { time -= Time.deltaTime; }
    }

    private void OnTriggerEnter(Collider other)
    {
       //if (other.gameObject.TryGetComponent(out ZDOROVIE zd))
       // {
       //     Destroy(gameObject);
       // }
     
       if (other.tag != "enemy")
        {
            Destroy(gameObject);
        }
            
        
        
    }

}
