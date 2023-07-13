using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Rotation : MonoBehaviour
{
    public float _speedCamera = 1f;
    private float CamX = 0f; private float CamY = 0f;


    private void LateUpdate()
    {
        if (Time.timeScale == 1f) {
            if (Input.mousePosition.x < 20)
            { 
                Rotation_Player(-1f, 0f, _speedCamera);
            }
            if (Input.mousePosition.x > Screen.width - 20) 
            {
                Rotation_Player(1f, 0f, _speedCamera); 
            } 
            if ( Input.mousePosition.y < 20)
            {
                Rotation_Player(0f, -1f, _speedCamera);
            }
            if(Input.mousePosition.y > Screen.height - 20 ) 
            {
                Rotation_Player(0f, 1f, _speedCamera);
            } 
        }
    }


    private void Rotation_Player(float y, float x, float speed)
    {


        CamX -= x * speed;
        CamX = Mathf.Clamp(CamX, -70, 20);
        CamY += y * speed;
        transform.eulerAngles = new Vector3(CamX, CamY, 0.0f);

    }
}
