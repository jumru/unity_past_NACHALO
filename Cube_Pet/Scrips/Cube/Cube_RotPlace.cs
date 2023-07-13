using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_RotPlace : MonoBehaviour
{
    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        
    }

    private void FixedUpdate()
    {
        _rigidbody.angularVelocity = Vector3.up;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _rigidbody.angularVelocity = Vector3.zero;
        }
    }
}
