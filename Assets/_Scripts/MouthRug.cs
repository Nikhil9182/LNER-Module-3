using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthRug : MonoBehaviour
{
    public Transform mainCamera;

    private bool canLerp;
    private Vector3 velocity = Vector3.zero;
    public float lerpTime;

    void FixedUpdate()
    {
        if(canLerp)
        {
            this.transform.position = Vector3.SmoothDamp(this.transform.position, mainCamera.position, ref velocity, lerpTime);
        }
    }

    public void OnClothSelect()
    {
        canLerp = true;
        
    }

}
