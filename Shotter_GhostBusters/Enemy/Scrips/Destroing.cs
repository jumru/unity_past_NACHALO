using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroing : MonoBehaviour
{
    public float _time;
    void Start()
    {
        Destroy(gameObject, _time);
    }

    
}
