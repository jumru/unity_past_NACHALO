using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private SurfaceSlider _surfaceSlider;
    [SerializeField] private float _speed;

    private void Start()
    {
        if (_rigidbody == null) _rigidbody = GetComponent<Rigidbody>();
        if (_surfaceSlider == null) _surfaceSlider = GetComponent<SurfaceSlider>();
      
    }

    public void Move(Vector3 direction, float time)
    {
        Vector3 directionAlongSurface = _surfaceSlider.Project(direction.normalized);
        Vector3 offset = directionAlongSurface * (_speed * time);

        _rigidbody.MovePosition(_rigidbody.position + offset);
    }
}
