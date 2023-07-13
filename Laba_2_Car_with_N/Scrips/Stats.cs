using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    //public float _Speed;
    public float _Trenie;
    public float _N_Max;
    public float _N_inSecond;
    public float _Mass;


    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.mass = _Mass;
         if(_Mass == 0 || _Mass < 0)
        {
            _Mass = 1;
        }


    }



}
