using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAT_Cursor : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;



    void LateUpdate()
    {
        Ray ray =  Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(transform.position, ray.direction*50f,  Color.yellow);
        

        RaycastHit hit;
        if (Time.timeScale == 1f)
        {
            if (Physics.Raycast(ray, out hit, layerMask))
            {
                transform.LookAt(hit.point);
            }
            else
            {
                transform.LookAt(ray.direction * 1000f);
            }
        }
    }
}
