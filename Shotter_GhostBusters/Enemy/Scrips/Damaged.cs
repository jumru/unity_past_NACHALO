using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damaged : MonoBehaviour
{
    [SerializeField] private GameObject _deathOBJ;
    [SerializeField] private Count_Done _count_done;
    private GameObject obj;
    public int _donePoints;

    private void Awake()
    {
        BaseEnemy._enemys += 1;
    }

    void Start()
    {
        if (_count_done == null)
        {
            
            _count_done = GameObject.FindGameObjectWithTag("Ghost_Counts").GetComponent<Count_Done>();
        }
        
        
    }
    public void damaged()
    {
        if (_deathOBJ != null)
        {
            Instantiate(_deathOBJ, gameObject.transform.position, Quaternion.identity);
        }
        _count_done._done += _donePoints;
        _count_done.ImageUpdate();
        Destroy(gameObject);
    }
}
