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
            this.transform.rotation = Quaternion.Euler(new Vector3(180f, 0f, 0f));
            this.transform.position = Vector3.SmoothDamp(this.transform.position, new Vector3(mainCamera.position.x, mainCamera.position.y, mainCamera.position.z), ref velocity, lerpTime);
        }
    }

    public void OnClothSelect()
    {
        canLerp = true;
        StartCoroutine(disableCloth());
    }

    IEnumerator disableCloth()
    {
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
    }
}
