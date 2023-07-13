using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationColliding : MonoBehaviour
{
   
    [SerializeField]private long _timeVibration;

    private void Start()
    {
        Vibration.Init();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vibration.Vibrate(_timeVibration);
        //Vibration.VibratePop();
        // Vibration.VibratePeek();
    }
   
}
