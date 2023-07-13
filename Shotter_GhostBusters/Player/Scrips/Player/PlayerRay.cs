using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRay : MonoBehaviour
{
   [HideInInspector]public Vector3 _transform;
   [HideInInspector]public bool _castHit;
   [HideInInspector]public float _distans;
   [SerializeField]private LayerMask layerMask;
    public GameObject _RayCasyOBJ;


    void LateUpdate()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * 50f, Color.yellow);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit,layerMask)) 
        {
            _RayCasyOBJ.transform.position = hit.point;
            _transform = hit.point;
            _castHit = true;
            _distans = hit.distance;
            
        }
        else
        {
            _castHit = false;
        }
    }
}
