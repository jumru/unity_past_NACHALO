using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody _rigidBody;
    private Stats _stats;


    [Header("Смотреть просто для себя")]
    [SerializeField] private float _speed_in_kmch;
    [SerializeField] private float _speed;
    [SerializeField] private float _defaultSpeed;
    [SerializeField] private float _N_moment = 0f;
    [SerializeField] private float _N_inSecond;
    private float _maxSpeed;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _stats = GetComponent<Stats>();
    }
    void Start()
    {
        
        _N_inSecond = _stats._N_inSecond;

        
    }

    
    

    private void FixedUpdate()
    {
        _speed_in_kmch = _speed * 3.6f;
        Base_Stats._speed_in_kmch = _speed_in_kmch;
        Base_Stats._N_moment = _N_moment;
        moving(1f,0,Time.fixedDeltaTime);

        if(Input.GetAxis(Axes.Vertical) > 0f) 
        { Move_Velocity(Time.fixedDeltaTime);}


        if (Input.GetAxis(Axes.Vertical) < 0f)
        { Move_Stoping(Time.fixedDeltaTime); }

        if (Input.GetAxis(Axes.Horizontal) != 0f)
        { moving(0, Input.GetAxis(Axes.Horizontal), Time.fixedDeltaTime); }

        //Debug.Log(Input.GetAxis(Axes.Vertical));

    }


    private void moving(float x,float y,float time)
    {
        Vector3 MovePosition_x = transform.right;
        Vector3 MovePosition_y = -transform.forward;
        //Vector3 MovePosition_y = transform.up;

        _rigidBody.MovePosition(_rigidBody.position + MovePosition_x* x * _speed * time);
        _rigidBody.MovePosition(_rigidBody.position + MovePosition_y * y * _speed * time);


    }

    


    private void Move_Velocity(float time)
    {

        if (_N_moment < _stats._N_Max)
        {
            _N_moment += _N_inSecond * time;
            _speed = Mathf.Sqrt((Mathf.Pow(_defaultSpeed, 2)) + ((2 * _N_moment * time) / _stats._Mass));
            _defaultSpeed = _speed;

        }
        
        
    }

    private void Move_Stoping(float time)
    {
        if(_speed > 0)
        {
            _speed = _defaultSpeed - _stats._Trenie * -Physics.gravity.y * time;
            _N_moment -= _N_inSecond * time;


        }
        if (_speed < 0) 
        { 
            _speed = 0f;
            _N_moment = 0f;
        }

        _defaultSpeed = _speed;

    }


   
}
