using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public GameObject welcomeWindow;
    public GameObject pinchTutorial;
    public GameObject directTutorial;
    public GameObject teleportTutorial;
    public GameObject StartLevel;

    public GameObject fireScene;

    private AudioSource canvasPopSound;

    void Start()
    {
        canvasPopSound = GetComponent<AudioSource>();
        StartCoroutine(setWelcomeWindow());
    }

    IEnumerator setWelcomeWindow()
    {
        welcomeWindow.SetActive(true);
        canvasPopSound.Play();
        yield return new WaitForSeconds(10f);
        welcomeWindow.SetActive(false);
        pinchTutorial.SetActive(true);
        canvasPopSound.Play();
    }


    public void OnPinchSelect()
    {
        Debug.Log("Pinch pressed");
        pinchTutorial.SetActive(false);
        directTutorial.SetActive(true);
        canvasPopSound.Play();
    }

    public void OnDirectSelect()
    {
        directTutorial.SetActive(false);
        teleportTutorial.SetActive(true);
        canvasPopSound.Play();
    }

    public void OnTeleportSelect()
    {
        teleportTutorial.SetActive(false);
        StartLevel.SetActive(true);
        canvasPopSound.Play();
    }

    public void OnStartSelect()
    {
        StartLevel.SetActive(false);
        fireScene.SetActive(true);
    }
}
