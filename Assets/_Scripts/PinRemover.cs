using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinRemover : MonoBehaviour
{

    public GameObject grabPin;
    public GameObject sprayExt;
    public GameObject baseFire;

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Pin"))
        {
            if(OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) > 0.4f)
            {
                other.gameObject.transform.parent = null;
                other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                GameManager.instance.pinRemoved = true;

                grabPin.SetActive(false);
                sprayExt.SetActive(true);
                gameObject.GetComponent<AudioSource>().Play();
                StartCoroutine(setSparyUnactive());
            }
        }
    }

    IEnumerator setSparyUnactive()
    {
        yield return new WaitForSeconds(5f);
        sprayExt.SetActive(false);
        baseFire.SetActive(true);
        StartCoroutine(setBaseFireUnactive());
    }
    IEnumerator setBaseFireUnactive()
    {
        yield return new WaitForSeconds(5f);
        baseFire.SetActive(false);
    }
}
