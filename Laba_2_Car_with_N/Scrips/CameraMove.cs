using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]private GameObject _Player;
    [SerializeField] private float _deltaPlayer;
    [SerializeField] private float _speedCam;

    private Vector3 _positionPlayer;

    void Start()
    {
        _deltaPlayer = transform.position.x;
        if (_Player == null)
        {
            _Player = GameObject.FindGameObjectWithTag("Player");
        }
    }

   

    private void FixedUpdate()
    {
        _positionPlayer = new Vector3(_Player.transform.position.x + _deltaPlayer, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, _positionPlayer, _speedCam);
    }
}
