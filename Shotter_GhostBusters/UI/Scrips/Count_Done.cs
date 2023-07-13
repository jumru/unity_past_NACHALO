using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Count_Done : MonoBehaviour
{
    [SerializeField]private Image[] _image;
    public int _done;
    void Start()
    {
        foreach (Image unit in _image)
        {
            unit.enabled = false;
        }
        ImageUpdate();
    }


    private void Update()
    {
        if (_done > _image.Length)
        {
            _done = _image.Length;
        }

        if(_done < 0)
        {
            _done = 0;
        }



    }
    public void ImageUpdate()
    {
        for (int i = 0; i< _image.Length;i++) 
        {
        if (i+1 <= _done)
            {
                _image[i].enabled = true;
            }
            else { _image[i].enabled = false; }
        }
        


    }


}
