using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetsAttack : MonoBehaviour
{
    private PlayerRay _playerRay;
    private Cube_move_player _cubeMovePlayer;
    private Rigidbody _rigidbody;
    [SerializeField] private float _maxDistenceAttack = 20f;
    [SerializeField] private LayerMask _layerMask;
    //[SerializeField] private float _timeReload;
    //[SerializeField]private AnimationCurve _jumpCubeCurve;
    //[SerializeField]private float _jumpHeight;
    //[SerializeField]private float _jumpLeigth;
    [SerializeField] private bool _attack;
    private float _heigt;
    private CubePositionAndGroud _cubePositionAndGroud;
    private Vector3 _newpos;
    private bool _onNewpos = true;

    void Start()
    {
        if (_cubeMovePlayer == null) { _cubeMovePlayer = GetComponent<Cube_move_player>(); }
        if (_playerRay == null) { _playerRay = FindObjectOfType<PlayerRay>(); }
        _rigidbody = GetComponent<Rigidbody>();
        _cubePositionAndGroud = GetComponent<CubePositionAndGroud>();
    }


    void Update()
    {

    }

    private void FixedUpdate()
    {
        //CheckAttack();
        if (Input.GetAxisRaw(Axes.Fire2) > 0 && _playerRay._castHit == true && _playerRay._distans <= _maxDistenceAttack && _attack == true)
        {

            JumpAttack(_playerRay._transform, Time.fixedDeltaTime);
        }
        if (_onNewpos == false)
        {
            _rigidbody.transform.LookAt(_newpos);
            Vector3 _transformForward;
            _transformForward = transform.forward;
            _rigidbody.position = Vector3.Lerp(_rigidbody.position, _rigidbody.position + _transformForward,  0.3f );
        }
         if (_newpos == _rigidbody.position) { _onNewpos = true; _cubeMovePlayer.SwitchWithMaster(1); }

    }


    void JumpAttack(Vector3 position, float time)
    {
        _cubeMovePlayer.SwitchWithMaster(0);
        Vector3 Velocity = Vector3.up * Mathf.Sqrt(_playerRay._distans * -Physics.gravity.y);
        float checkHeigt = (Velocity.y * Velocity.y) / (4 * -Physics.gravity.y);
        if (checkHeigt >= 4f) {
            _rigidbody.velocity = Velocity; }
        else
        {
            Velocity = Vector3.up * Mathf.Sqrt(2 * 2.1f * -Physics.gravity.y);
            _rigidbody.velocity = Velocity;
        }
        
        _newpos = position;
        _onNewpos = false;
    }

    //    void CheckAttack()   
    //    {Vector3 CheckHeigt = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
    //    Ray ray = new Ray(transform.position, CheckHeigt);
    //    RaycastHit hit;
    //        if (Physics.Raycast(ray, out hit, _cubePositionAndGroud._heigtConst + 0.5f, _layerMask))
    //        {

    //            _attack = true;
    //        }
    //        else
    //{
    //    _attack = false;
    //}
    //    }

    private void OnCollisionEnter(Collision collision)
    {
        _onNewpos = true;
        
    }
    private void OnCollisionStay(Collision collision)
    {
        _attack = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        _attack = false;
    }

    void TimeReload()
    {

    }

}

