using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private GameObject _ball;
    private Ball _ballScripts;
    [SerializeField] int _points;
    void Start()
    {
        if (_ball == null)
        {
             _ball = FindObjectOfType<Ball>().gameObject;
        }
        _ballScripts = _ball.GetComponent<Ball>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == _ball)
        {
            _ballScripts.Reset(_points);
        }
    }
}
