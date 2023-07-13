using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GhostMove : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private float _speed;
    [SerializeField] private float _maxDistance;
    private Vector3 _pointMoving;
    [SerializeField] float _maxX;
    [SerializeField] float _maxY;
    [SerializeField] float _maxZ;
    private Vector3 _spawnpoint;
    private Vector3 _randomPoints;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _spawnpoint = transform.position;
        _randomPoints = _spawnpoint;
        _pointMoving = _spawnpoint;
    }

    private void FixedUpdate()
    {
       // Debug.Log(Vector3.Distance(gameObject.transform.position, _pointMoving));
        if (Vector3.Distance(gameObject.transform.position, _pointMoving) < 1.5f)
        {
            Vector3 RandomPoints = Random.insideUnitSphere * _maxDistance;
            _randomPoints = _spawnpoint + RandomPoints;
            if (_randomPoints.x > _spawnpoint.x +_maxX) { _randomPoints.x = _spawnpoint.x +_maxX; }
            if (_randomPoints.x < _spawnpoint.x -_maxX) { _randomPoints.x = _spawnpoint.x - _maxX; }
            if (_randomPoints.y > _spawnpoint.y+_maxY) { _randomPoints.y = _spawnpoint.y + _maxY; }
            if (_randomPoints.y < _spawnpoint.y-_maxY) { _randomPoints.y = _spawnpoint.y - _maxY; }
            if (_randomPoints.z > _spawnpoint.z+_maxZ) { _randomPoints.z = _spawnpoint.z+_maxZ; }
            if (_randomPoints.z < _spawnpoint.z-_maxZ) { _randomPoints.z = _spawnpoint.z - _maxZ; }
            _pointMoving = _randomPoints;
        }


        _rb.MovePosition(Vector3.MoveTowards(_rb.transform.position, _pointMoving, _speed * Time.fixedDeltaTime));
        transform.LookAt(_pointMoving);

    }

    //private void OnTriggerStay(Collider other)
    //{
    //    _pointMoving = transform.position;
    //}

    private void OnTriggerEnter(Collider other)
    {
        _pointMoving = transform.position;
    }
}
