using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _spawnBullet;
    [SerializeField] private Count_Done _count_done;
    [SerializeField] private float _timeFire;
    private float _timeReloadFire;
    void Start()
    {
        if (_count_done == null)
        {
            _count_done = new Count_Done();
            _count_done._done = 1000000;
        }
    }

    
    void Update()
    {
        if (Time.timeScale == 1f)
        if (Input.GetAxisRaw(Axes.Fire1) != 0 && _timeReloadFire <= 0f)
        {
            if (_count_done._done > 0)
            {
                Vector3 _posVec = new Vector3(_spawnBullet.position.x, _spawnBullet.position.y, _spawnBullet.position.z);
                Instantiate(_bullet, _posVec, transform.rotation);
                _count_done._done -= 1;
                _count_done.ImageUpdate();
                _timeReloadFire = _timeFire;
            }
        }
         if (_timeReloadFire > 0) 
        {
            _timeReloadFire -= Time.deltaTime;
        }


    }
}
