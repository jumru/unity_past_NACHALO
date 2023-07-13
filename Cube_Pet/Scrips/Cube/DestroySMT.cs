using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySMT : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out DESTROING_CUBE _DESTROING_CUBE))
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out DESTROING_CUBE _DESTROING_CUBE))
        {
            Destroy(other.gameObject);
        }
    }
}
