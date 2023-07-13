using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float _horizontalMove;
    private float _verticalMove;
    public float _speedMove = 1f;
    


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.freezeRotation = true;
    }

    
    void Update()
    {
        _horizontalMove = Input.GetAxis("Horizontal");
        _verticalMove = Input.GetAxis("Vertical");

    }

    private void FixedUpdate()
    {

        if (_horizontalMove != 0 || _verticalMove != 0)
        {
            Move_Player(_horizontalMove, _verticalMove, Time.fixedDeltaTime);
        }
    }

   
    private void Move_Player(float x, float z, float time)
    {
        
        Vector3 Position = (transform.forward *z) + (transform.right*x);
         _rigidbody.MovePosition(_rigidbody.position + Position * _speedMove * time);
        
    }

    
}
 