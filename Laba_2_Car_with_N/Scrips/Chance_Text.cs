using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Chance_Text : MonoBehaviour
{
    private Text _text;
    [SerializeField] private bool _S;
   [SerializeField] private bool _N;
    void Start()
    {
        _text = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_S == true) { _N = false; }

        if (_S == true)
        {
            _text.text = Base_Stats._speed_in_kmch.ToString("F2");
        }
        else
            if (_N == true)
        {
            _text.text = Base_Stats._N_moment.ToString("F0");
        }
    }
}
