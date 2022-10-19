using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectKey : MonoBehaviour
{
    public Transform keyFinalTransform;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Key"))
        {
            other.gameObject.transform.position = keyFinalTransform.position;
            other.gameObject.transform.rotation = keyFinalTransform.rotation;
        }
    }
}
