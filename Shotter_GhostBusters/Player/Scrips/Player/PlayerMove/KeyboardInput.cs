using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    [SerializeField] private PhysicsMovement _movement;
    [SerializeField] private PhysicsJump _jump;
    

    private void Start()
    {
        if (_movement == null) _movement = GetComponent<PhysicsMovement>();
        if (_jump == null) _jump = GetComponent<PhysicsJump>();
    }
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.GetAxisRaw(Axes.Jump) > 0)
        {
            _jump.Jump();
        }

        float horizontal = Input.GetAxis(Axes.Horizontal);
        float vertical = Input.GetAxis(Axes.Vertical);



        Vector3 Position = (transform.forward * vertical) + (transform.right * horizontal);
        _movement.Move(Position, Time.fixedDeltaTime);
    }
}




