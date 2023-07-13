using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonOBJ : MonoBehaviour
{
    private Placement _Placement;

    [SerializeField]private GameObject _ChooseOBJ;
    void Start()
    {
        _Placement = FindObjectOfType<Placement>();
    }

    public void ChooseOBJSpawing()
    {
        _Placement.SpawingOBJ = _ChooseOBJ;
        _Placement._ChooseObject = true;
    }
}
