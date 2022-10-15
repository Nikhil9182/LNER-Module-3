using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertManager : MonoBehaviour
{
    public GameObject breakGlass;
    public GameObject pressAlert;
    public GameObject phone;
    public GameObject fireLocation;
    public GameObject fireType;

    public GameObject selectExtUI;
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
        phone.SetActive(true);
    }

    public void OnPhoneSelect()
    {
        phone.SetActive(false);
        fireLocation.SetActive(true);
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
