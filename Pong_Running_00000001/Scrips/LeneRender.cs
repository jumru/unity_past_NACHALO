using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeneRender : MonoBehaviour
{
    private LineRenderer _lineRenderer;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }


    public void SetLinePoint2(Vector2 _position2)
    {
        _lineRenderer.SetPosition(1, _position2);
    }

    public void ResetLinePoint2()
    {
        _lineRenderer.SetPosition(1, Vector2.zero);
    }

}
