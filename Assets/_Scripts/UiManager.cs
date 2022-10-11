using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public UICanvasController cameraFollow;

    public GameObject welcomeWindow;
    public GameObject pinchTutorial;
    public GameObject directTutorial;
    public GameObject teleportTutorial;
    public GameObject StartLevel;

    public GameObject calledForSafety;
    public GameObject selectCloth;
    public GameObject GetBackToFire;
    public GameObject Precautions;

    public GameObject fireScene;

    private AudioSource canvasPopSound;

    void Start()
    {
        cameraFollow._canvasTransform = welcomeWindow.transform;
        canvasPopSound = GetComponent<AudioSource>();
        StartCoroutine(setWelcomeWindow());
    }

    IEnumerator setWelcomeWindow()
    {
        welcomeWindow.SetActive(true);
        canvasPopSound.Play();
        yield return new WaitForSeconds(10f);
        welcomeWindow.SetActive(false);
        cameraFollow._canvasTransform = pinchTutorial.transform;
        pinchTutorial.SetActive(true);
        canvasPopSound.Play();
    }


    public void OnPinchSelect()
    {
        Debug.Log("Pinch pressed");
        pinchTutorial.SetActive(false);
        cameraFollow._canvasTransform = directTutorial.transform;

        directTutorial.SetActive(true);
        canvasPopSound.Play();
    }

    public void OnDirectSelect()
    {
        directTutorial.SetActive(false);
        cameraFollow._canvasTransform = teleportTutorial.transform;

        teleportTutorial.SetActive(true);
        canvasPopSound.Play();
    }

    public void OnTeleportSelect()
    {
        teleportTutorial.SetActive(false);
        cameraFollow._canvasTransform = StartLevel.transform;

        StartLevel.SetActive(true);
        canvasPopSound.Play();
    }

    public void OnStartSelect()
    {
        StartLevel.SetActive(false);
        fireScene.SetActive(true);
    }

    public void OnElectricFireSelect()
    {
        cameraFollow._canvasTransform = calledForSafety.transform;
        calledForSafety.SetActive(true);
        StartCoroutine(hideUI(calledForSafety));
        selectCloth.SetActive(true);
    }
    public void OnClothSelect()
    {
        cameraFollow._canvasTransform = GetBackToFire.transform;

        selectCloth.SetActive(false);
        GetBackToFire.SetActive(true);
        Precautions.SetActive(true);
        StartCoroutine(hideUI(GetBackToFire));
    }

    IEnumerator hideUI(GameObject UI)
    {
        yield return new WaitForSeconds(5f);
        UI.SetActive(false);
    }
}
