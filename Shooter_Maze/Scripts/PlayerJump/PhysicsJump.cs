using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsJump : MonoBehaviour
{
    [Header("Высота")]
    [SerializeField] private float _heigt;
    [SerializeField] private Collider _collider;
    [Header("В принципе сам подвяжет")]
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private SurfaceSlider _surfaceSlider;
    private Vector3 _normal;
    [SerializeField] private LayerMask _layerMask;
    
    private Vector3 _RayPountDown;


    //[SerializeField] private float _length;
    //[SerializeField] private float _duration;


    private void Start()
    {
        if (_rigidbody == null) _rigidbody = GetComponent<Rigidbody>();
        if (_surfaceSlider == null) _surfaceSlider = GetComponent<SurfaceSlider>();
        _RayPountDown = -Vector3.up * _collider.bounds.size.y/2;
       

    }
    private void Update()
    {
        Debug.DrawRay(transform.position, -_normal*2, Color.green);
    }

    public void Jump()
    {
       
        Ray ray = new Ray(transform.position, -_normal);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, -_RayPountDown.y+0.2f, _layerMask))
        {

            Vector3 Velocity = _normal * Mathf.Sqrt(2 * _heigt * -Physics.gravity.y);
            _rigidbody.velocity = Velocity;
        }
        else
        {
 
        }

        
    }
    private void OnCollisionStay(Collision collision)
    {
        _normal = collision.contacts[0].normal;
    }
}
