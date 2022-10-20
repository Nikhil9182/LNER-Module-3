using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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

    public GameObject pickTheExt;
    public GameObject grabPin;

    private AudioSource canvasPopSound;

    private bool pickExtActive;

    private bool timeStarted;
    
    void Start()
    {
        cameraFollow._unmovableCanvasTransform = welcomeWindow.transform;
        canvasPopSound = GetComponent<AudioSource>();
        StartCoroutine(setWelcomeWindow());
    }

    private void Update()
    {
        if(timeStarted)
        {
            GameManager.instance.totalTime += Time.deltaTime;
        }
        if(!pickExtActive && pickTheExt.active)
        {
            pickExtActive = true;
            StartCoroutine(pickUpExtActive());
        }
    }

    IEnumerator pickUpExtActive()
    {
        yield return new WaitForSeconds(5f);
        pickTheExt.SetActive(false);
        grabPin.SetActive(true);

    }
    IEnumerator setWelcomeWindow()
    {
        welcomeWindow.SetActive(true);
        canvasPopSound.Play();
        yield return new WaitForSeconds(10f);
        welcomeWindow.SetActive(false);
        cameraFollow._unmovableCanvasTransform = pinchTutorial.transform;
        pinchTutorial.SetActive(true);
        canvasPopSound.Play();
    }


    public void OnPinchSelect()
    {
        Debug.Log("Pinch pressed");
        pinchTutorial.SetActive(false);
        cameraFollow._unmovableCanvasTransform = directTutorial.transform;

        directTutorial.SetActive(true);
        canvasPopSound.Play();
    }

    public void OnDirectSelect()
    {
        directTutorial.SetActive(false);
        cameraFollow._unmovableCanvasTransform = teleportTutorial.transform;

        teleportTutorial.SetActive(true);
        canvasPopSound.Play();
    }

    public void OnTeleportSelect()
    {
        teleportTutorial.SetActive(false);
        cameraFollow._unmovableCanvasTransform = StartLevel.transform;

        StartLevel.SetActive(true);
        canvasPopSound.Play();
    }

    public void OnStartSelect()
    {
        StartLevel.SetActive(false);
        fireScene.SetActive(true);
        timeStarted = true;
    }

    public void OnElectricFireSelect()
    {
        calledForSafety.SetActive(true);

        GameManager.instance.phoneTime = GameManager.instance.totalTime;

        StartCoroutine(hideUI(calledForSafety));
    }
    public void OnClothSelect()
    {
        selectCloth.SetActive(false);
        GetBackToFire.SetActive(true);

        GameManager.instance.maskTime = GameManager.instance.totalTime;

        StartCoroutine(hideUI(GetBackToFire));
    }

    public void OnFireLocation()
    {
        if(GameManager.instance.inClothPlace == true)
            Precautions.SetActive(true);
    }
    IEnumerator hideUI(GameObject UI)
    {
        yield return new WaitForSeconds(5f);
        UI.SetActive(false);
    }

    public void DisplayReport(GameObject reportText)
    {
        
        reportText.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "0" + ((int)GameManager.instance.alarmTime / 60).ToString() + ":" + ((int)GameManager.instance.alarmTime % 60).ToString();
        reportText.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "0" + ((int)GameManager.instance.phoneTime / 60).ToString() + ":" + ((int)GameManager.instance.phoneTime % 60).ToString();
        reportText.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "0" + ((int)GameManager.instance.maskTime / 60).ToString() + ":" + ((int)GameManager.instance.maskTime % 60).ToString();
        reportText.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = "0" + ((int)GameManager.instance.totalTime / 60).ToString() + ":" + ((int)GameManager.instance.totalTime % 60).ToString(); //for evac
    }

    public void OnResetClick()
    {
        SceneManager.LoadScene(0);
    }
    public void OnExitClick()
    {
        Application.Quit();
    }
}
