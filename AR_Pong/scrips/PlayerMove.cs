using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody _rigidBody;
    [SerializeField] private Joystick _joystick;
    public float _speed;
    [SerializeField] private float _MaxOYPosition = 3f;
    [SerializeField] private float _MinOYPosition = -3f;
    [SerializeField] private GameObject _plane;
    
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();

    }

    private void FixedUpdate()
    {

        _rigidBody.position = new Vector3(_rigidBody.position.x,
       Mathf.Clamp(_rigidBody.transform.position.y, _plane.transform.position.y +_MinOYPosition,
       _plane.transform.position.y + _MaxOYPosition),
            _plane.transform.position.z);
        
        
        _rigidBody.MovePosition(_rigidBody.position +Vector3.up * _joystick.Vertical * _speed*Time.fixedDeltaTime);
    }
}
