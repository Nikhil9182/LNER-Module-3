using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExtinguishFire : MonoBehaviour
{
    private bool canExt;
    public GameObject Fire;

    public GameObject ReportUI;

    //Alarm, phone, mask, fire, score, total 
    public GameObject reportText;

    public void Update()
    {
        if (canExt && GameManager.instance.pinRemoved && OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0.8f && GameManager.instance.extinguisherSize > 0)
        {
            GameManager.instance.extinguisherSize -= Time.deltaTime;
            if(GameManager.instance.particles.CompareTag("CO2"))
                ReduceFire(0.0028f);
            else if (GameManager.instance.particles.CompareTag("Dry"))
                ReduceFire(0.002f);
        }
        else if (GameManager.instance.extinguisherSize <= 0 || Fire.transform.GetChild(0).localScale.x <= 0)
        {
            Fire.GetComponent<AudioSource>().Stop();

            GameManager.instance.fireTime = GameManager.instance.totalTime;
         
            DisplayReport();
            ReportUI.SetActive(true);

            this.gameObject.SetActive(false);
        }
        else
        {
            DisplayReport();
            ReportUI.SetActive(false);
        }
    }

    void ReduceFire(float val)
    {
        for(int i =0; i<12;i++)
        {
            if(Fire.transform.GetChild(i).localScale.x > 0)
            {
                Fire.transform.GetChild(i).localScale -= new Vector3(val, val, val);
            }
            else
            {

                //add report UI change
/*                successfulExt.SetActive(true);
*/
                Fire.GetComponent<AudioSource>().Stop();

                GameManager.instance.fireTime = GameManager.instance.totalTime;
            }
        }
    }

    void DisplayReport()
    {

        reportText.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "00:" + ((int)GameManager.instance.alarmTime).ToString();
        reportText.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "00:" + ((int)GameManager.instance.phoneTime).ToString();
        reportText.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "00:" + ((int)GameManager.instance.maskTime).ToString();
        reportText.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "00:" + ((int)GameManager.instance.fireTime).ToString();

        
    }
    public void ExtenguishingFire()
    {
        canExt = true;
    }

    public void OnUnhoverFire()
    {
        canExt = false;
    }
}
