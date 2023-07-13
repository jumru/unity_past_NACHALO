using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D _rigitBody2D;
    [SerializeField]private float _speed;
    private Vector2 _beginPosition;
    private Vector2 _endPosition;
    [SerializeField]private LeneRender _lineRender;


    void Start()
    {
        _rigitBody2D = GetComponent<Rigidbody2D>();
        if (_lineRender == null) { _lineRender = GetComponentInChildren<LeneRender>(); }
        _lineRender.enabled = false;
        
    }

    
    void Update()
    {
        SetPlayerMove();

    }

    private void SetPlayerMove()
    {
        Vector2 _Force;
        _Force = _beginPosition - _endPosition;

        if (Input.touchCount > 0)
        {
            Touch _touch = Input.GetTouch(0);
            Vector2 _touchPosition = Camera.main.ScreenToWorldPoint(_touch.position);

            if (_touch.phase == TouchPhase.Began)
            {
                _beginPosition = _touchPosition;
                _rigitBody2D.simulated = false;
                _rigitBody2D.velocity = Vector2.zero;
                _lineRender.enabled = true;
            }

            if (_touch.phase == TouchPhase.Moved)
            {
                _endPosition = _touchPosition;
                _lineRender.SetLinePoint2(_Force * _speed*5f);
            }
            if (_touch.phase == TouchPhase.Ended)
            {
                _lineRender.ResetLinePoint2();
                _lineRender.enabled = false;
                _rigitBody2D.simulated = true;
                _rigitBody2D.AddForce(_Force * _speed, ForceMode2D.Impulse);
            }
        }
    }


}
