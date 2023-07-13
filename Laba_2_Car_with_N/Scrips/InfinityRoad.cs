using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinityRoad : MonoBehaviour
{

    private float _lethRoad;
    [SerializeField]private GameObject _Player;
    private float _distantion;
    [SerializeField] private bool _wasSpawn = false;

    void Start()
    {
        _lethRoad = transform.localScale.x * 10f;
        if(_Player == null)
        {
            _Player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    
    void Update()
    {
        _distantion =   gameObject.transform.position.x - _Player.transform.position.x;

        //Debug.Log(_distantion);

        if (_distantion < -2*_lethRoad/2f-1f)
        {
            SpawnRoad();
            
        }

    }
   
    

    

    public void SpawnRoad()
    {
        Vector3 _spawnPosition = new Vector3(gameObject.transform.position.x + 2*_lethRoad + _lethRoad/2, gameObject.transform.position.y, gameObject.transform.position.z);
        Instantiate(gameObject,_spawnPosition, Quaternion.identity);
        DestroyRoad();


    }

    public void DestroyRoad()
    {
        Destroy(gameObject);
    }

}
