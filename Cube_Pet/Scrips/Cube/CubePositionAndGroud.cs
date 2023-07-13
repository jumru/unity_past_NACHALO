using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePositionAndGroud : MonoBehaviour
{
    public float _heigtConst = 1f;
    private float _baseY;
    private Rigidbody _rigidbody;
    [SerializeField] private LayerMask _layerMask;
    

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        CheckAttack();
    }

    void CheckAttack()
    {
        Vector3 CheckHeigt = new Vector3(transform.position.x, transform.position.y - _heigtConst, transform.position.z);
        Ray ray = new Ray(transform.position, CheckHeigt);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, _heigtConst , _layerMask))
        {
            
            Vector3 positionOY = new Vector3(_rigidbody.transform.position.x, _rigidbody.transform.position.y+1f, _rigidbody.transform.position.z);
            _rigidbody.MovePosition(positionOY);
            
        }
        else
        {
            
        }
    }

    

}
