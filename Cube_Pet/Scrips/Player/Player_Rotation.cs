using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Rotation : MonoBehaviour
{
    public float _speedCamera = 1f;
    private float CamX = 0f; private float CamY = 0f;


    private void LateUpdate()
    {
        Rotation_Player(Input.GetAxisRaw("Mouse Y"), Input.GetAxisRaw("Mouse X"), _speedCamera);
    }


    private void Rotation_Player(float x, float y, float speed)
    {


        CamX -= x * speed;
        CamX = Mathf.Clamp(CamX, -70, 70);
        CamY += y * speed;
        transform.eulerAngles = new Vector3(CamX, CamY, 0.0f);

    }
}
