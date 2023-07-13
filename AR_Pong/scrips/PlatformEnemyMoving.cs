using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformEnemyMoving : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField]private GameObject _ball;
    public float _speed;
    [SerializeField]private bool _targetOX;
    public float _TargetPositionOX;
    [SerializeField] private bool _targetOY;
    public float _TargetPositionOY;

    [SerializeField] private float _MaxOYPosition = 3f;
    [SerializeField] private float _MinOYPosition = -3f;
    [SerializeField] private float _MaxOXPosition = 8.3f;
    [SerializeField] private float _MinOXPosition = -8.3f;
    [SerializeField] private GameObject _plane;


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        if (_ball == null) { _ball = FindObjectOfType<Ball>().gameObject; }


        _speed = _speed / 100;
    }

    private void FixedUpdate()
    {
        if (_targetOX == true)
        {
            if (_ball.transform.position.x > _TargetPositionOX)
            {
                MovingPlayer();
            }
        }
        if (_targetOY == true)
        {
            if (_ball.transform.position.x > _plane.transform.position.x)
            {
                MovingPlayer();
            }
        }

    }

   private void MovingPlayer()
    {

        float _limiteOX = Mathf.Clamp(_rigidbody.transform.position.x, _rigidbody.transform.position.x+_MinOXPosition,
            _rigidbody.transform.position.x+_MaxOXPosition);

        float _limiteOY = Mathf.Clamp(_rigidbody.transform.position.y,
            _plane.transform.position.y +_MinOYPosition, _plane.transform.position.y +_MaxOYPosition);

        Vector3 _limitePosition;
        _limitePosition = new Vector3(_limiteOX, _limiteOY, _plane.transform.position.z);

        _rigidbody.MovePosition(Vector3.Lerp(_limitePosition, _ball.transform.position,_speed));

        



    }

}
