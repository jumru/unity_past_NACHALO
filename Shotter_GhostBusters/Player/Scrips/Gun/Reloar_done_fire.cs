using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reloar_done_fire : MonoBehaviour
{
    [SerializeField] private Count_Done _count_Done;
    private int _maxDone;
    public float _timeDoneBullet;
    private float _timeReload;
    void Start()
    {
        if (_count_Done != null) 
        {
            _maxDone = _count_Done._done;
        }
    }

    
    void Update()
    {
        if (_count_Done._done < _maxDone)
        {
            if (_timeReload <= 0f)
            {
                _count_Done._done += 1;
                _count_Done.ImageUpdate();
                _timeReload = _timeDoneBullet;
            }
        }

        if (_timeReload > 0f)
        {
            _timeReload -= Time.deltaTime;
        }


    }
}
