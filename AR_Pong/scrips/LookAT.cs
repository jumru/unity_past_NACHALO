using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAT : MonoBehaviour
{
    
    [SerializeField] private GameObject _camera;
   [SerializeField] private GameObject _target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    void Update()
    {
        _target.transform.position = _camera.transform.position * -1f;
        transform.LookAt(_target.transform);
    }
}
