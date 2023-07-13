using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Chance_Text_mass : MonoBehaviour
{
    private Text _text;
    [SerializeField] private Rigidbody _rigidbody;
    void Start()
        
    {
        _text = GetComponent<Text>();
        if (_rigidbody == null)
        { _rigidbody = GetComponentInParent<Rigidbody>(); }

        Invoke(nameof(Text_mass),0.5f);
    }

    void Text_mass()
    {
        _text.text = _rigidbody.mass.ToString()+"кг";
    }
    private void Update()
    {
        
    }

}
