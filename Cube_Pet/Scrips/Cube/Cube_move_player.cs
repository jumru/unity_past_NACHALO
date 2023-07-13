using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_move_player : MonoBehaviour
{
    private bool _withMaster = false;
    private Rigidbody _rigidbody;
    public GameObject _Player;
    public float _speed;
    

    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _speed = _speed / 100;
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (_withMaster == true)
        {
            RotationToMaster();
            MovewithMaster(Time.fixedDeltaTime);
        }
        else
        {
           
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.tag == "Player")
        {
            _Player = collision.gameObject;
            _withMaster = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.constraints = RigidbodyConstraints.None;

        }
    }

    private void MovewithMaster(float time)
    {
        //Vector3 positionOY = new Vector3(_rigidbody.transform.position.x, _Player.transform.position.y, _rigidbody.transform.position.z);
        //_rigidbody.MovePosition(positionOY);
        if (Vector3.Distance(_rigidbody.position, _Player.transform.position) > 5f)
        {
            _rigidbody.position = Vector3.Lerp(transform.position, _Player.transform.position, _speed);  
        }

        if (Vector3.Distance(_rigidbody.position, _Player.transform.position) < 2.5f)
        {
            Vector3 _transformBack;
            _transformBack = -transform.forward;
            _rigidbody.position = Vector3.Lerp(_rigidbody.position, _rigidbody.position + _transformBack, _speed*10);
        }

    }

    private void RotationToMaster()
    {
        if (_Player != null)
        {
            _rigidbody.transform.LookAt(_Player.transform);
            // transform.LookAt(_Player.transform);
        }
    }

    public void SwitchWithMaster(int i)
    {
        if (i == 1) _withMaster = true;
        if (i == 0) _withMaster = false;
    } 

}
