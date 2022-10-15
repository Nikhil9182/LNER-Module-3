using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool canAlert;
    public bool alertPressed;

    [HideInInspector]
    public string dialedNumber;

    public bool pinRemoved;

    public GameObject particles;

    public int fireSize = 100;
    public float extinguisherSize;

    public float totalTime;
    public float alarmTime;
    public float phoneTime;
    public float maskTime;
    public float fireTime;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void Update()
    {
        if(pinRemoved && OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0.8f && extinguisherSize > 0)
        {
            particles.GetComponent<ParticleSystem>().Play();
            extinguisherSize -= Time.deltaTime;
        }
        else
        {
            particles.GetComponent<ParticleSystem>().Stop();
        }
    }
}
