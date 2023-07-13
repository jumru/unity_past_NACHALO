using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField]private float _speed;
    [SerializeField] private float _speedRotation;
   private Vector3 _tranform;
    [SerializeField] private float _timeFly; 

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.angularVelocity = Vector3.up * _speedRotation;
        _tranform = transform.forward;
    }

    private void FixedUpdate()
    {
        
        _rb.position =   (_rb.position+ _tranform*_speed*Time.fixedDeltaTime);

        if (_timeFly <= 0f)
        {
            Destroy(gameObject);
        }
        _timeFly -= Time.fixedDeltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Damaged _damaged))
        {
            other.GetComponent<Damaged>().damaged();
        }

        Destroy(gameObject);
    }
}
