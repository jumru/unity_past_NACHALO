using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformEnemyMoving : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField]private GameObject _player;
    public float _speed;
    [SerializeField]private bool _targetOX;
    public float _TargetPositionOX;
    [SerializeField] private bool _targetOY;
    public float _TargetPositionOY;

    [SerializeField] private float _MaxOYPosition = 3f;
    [SerializeField] private float _MinOYPosition = -3f;
    [SerializeField] private float _MaxOXPosition = 8.3f;
    [SerializeField] private float _MinOXPosition = -8.3f;


    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        if (_player == null) { _player = FindObjectOfType<PlayerMove>().gameObject; }


        _speed = _speed / 100;
    }

    private void FixedUpdate()
    {
        if (_targetOX == true)
        {
            if (_player.transform.position.x > _TargetPositionOX)
            {
                MovingPlayer();
            }
        }
        if (_targetOY == true)
        {
            if (_player.transform.position.x > _TargetPositionOY)
            {
                MovingPlayer();
            }
        }

    }

   private void MovingPlayer()
    {

        float _limiteOX = Mathf.Clamp(_rigidbody2D.transform.position.x, _MinOXPosition, _MaxOXPosition);
        float _limiteOY = Mathf.Clamp(_rigidbody2D.transform.position.y, _MinOYPosition, _MaxOYPosition);
        Vector2 _limitePosition;
        _limitePosition = new Vector2(_limiteOX, _limiteOY);

        _rigidbody2D.MovePosition(Vector2.Lerp(_limitePosition, _player.transform.position,_speed));

        



    }

}
