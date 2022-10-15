using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AlertManager : MonoBehaviour
{
    public GameObject breakGlass;
    public GameObject pressAlert;
    public GameObject phone;
    public GameObject Keypad;
    public GameObject dialError;
    public GameObject fireLocation;
    public GameObject fireType;

    public GameObject selectExtUI;

    private Material alarmMat;
    public void OnAlarmHover(GameObject alarm)
    {
        alarmMat = alarm.GetComponent<MeshRenderer>().material;
        alarm.GetComponent<MeshRenderer>().material.color = Color.green;
    }

    public void OnAlarmUnhover(GameObject alarm)
    {
        alarm.GetComponent<MeshRenderer>().material.color = alarmMat.color;
    }
    public void OnGlassSelect()
    {
        GameManager.instance.canAlert = true;
        breakGlass.SetActive(false);
        pressAlert.SetActive(true);

        this.gameObject.GetComponent<AudioSource>().Play();

        Destroy(this.gameObject);

        //to-do Add Glass break animation
    }

    public void OnAlertSelect()
    {
        if (GameManager.instance.canAlert == true)
        {
            GameManager.instance.alertPressed = true;
            pressAlert.SetActive(false);

            GameManager.instance.alarmTime = GameManager.instance.totalTime;

            this.gameObject.GetComponent<AudioSource>().Play();
            //to-do set alarm music
        }
    }

    public void OnPhoneHover()
    {
        dialError.SetActive(false);
        phone.SetActive(true);
    }

    public void OnPhoneSelect()
    {
        phone.SetActive(false);
    }

    public void OnNumberSelect(TextMeshProUGUI textGO)
    {
        GameManager.instance.dialedNumber += textGO.text;
    }

    public void OnCallDialed()
    {
        if(GameManager.instance.dialedNumber == "911")
        {
            Keypad.SetActive(false);
            dialError.SetActive(false);
            fireLocation.SetActive(true);
        }
        else
        {
            dialError.SetActive(true);
        }
    }
    public void OnLnerAcademySelect()
    {
        Debug.Log("presses");
        fireLocation.SetActive(false);
        fireType.SetActive(true);
    }

    public void PlaceSelectionError()
    {
        fireLocation.SetActive(false);
        fireType.SetActive(true);
    }
    public void OnElectricTypeSelect()
    {
        fireType.SetActive(false);
    }

    public void OnFightSelect()
    {
        selectExtUI.SetActive(true);
        GameManager.instance.totalTime = 0;
    }

}
