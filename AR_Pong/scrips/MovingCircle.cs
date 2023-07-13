using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCircle : MonoBehaviour
{
    private Rigidbody _rigidBody;

    public float _speed;
    public float _speedRotation = 0f;
    private float _rotationY;

   
   
 
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _rotationY = transform.rotation.y;
    }



    void FixedUpdate()
    {
        
        _rigidBody.MovePosition(_rigidBody.position + transform.forward * _speed * Time.fixedDeltaTime);
        // _rigidBody.transform.eulerAngles = new Vector3(0f, _speedRotation, 0.0f);
        _rotationY += _speedRotation;
        transform.eulerAngles = new Vector3(0f, _rotationY, 0.0f);

    }
}


    
