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

    public void OnGlassSelect()
    {
        GameManager.instance.canAlert = true;
        breakGlass.SetActive(false);
        pressAlert.SetActive(true);

        //to-do Add Glass break animation
    }

    public void OnAlertSelect()
    {
        if (GameManager.instance.canAlert == true)
        {
            GameManager.instance.alertPressed = true;
            pressAlert.SetActive(false);
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

    public void OnFireTypeSelect()
    {
        fireType.SetActive(false);
    }


}
