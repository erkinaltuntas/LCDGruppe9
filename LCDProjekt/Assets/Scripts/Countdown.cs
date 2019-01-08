/*************************************************************************** 
* Countdown
* Anwendung: Zur Anzeige des Timers
*------------------- 
* Zuletzt bearbeitet von: Erkin Altuntas
* Datum der letzten Bearbeitung: 30.12.2018
* Grund für letzte Bearbeitung: Timer für Tutorial deaktiviert.
* **************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using TMPro;

public class Countdown : MonoBehaviour
{
    int timeLeft = 60; //Seconds Overall
    public TextMeshProUGUI countdown; //UI Text Object
    public Sprite empty;
    GameObject field1;
    GameObject field2;
    GameObject field3;
    GameObject field4;
    public Plant emptyPlant;
    public GameObject SelectionPanel, WeatherPanel;
    GameObject weather;
    int a = 0;
    int b = 0;

    void Start()
    {
        
        field1 = GameObject.Find("Field 1");
        field2 = GameObject.Find("Field 2");
        field3 = GameObject.Find("Field 3");
        field4 = GameObject.Find("Field 4");

        weather = GameObject.Find("Weather");
    }
    void Update()
    {
        if (timeLeft > 10)
        {
            countdown.text = (timeLeft + " Sek."); // Zeit im Canvas anzeigen
        }
        else
        {
            countdown.text = ("<color=red>" + timeLeft +"<color=white>"+" Sek."); // Zeit im Canvas in rot anzeigen
        }
        
        if(timeLeft == 0 && a == 0 && !(weather.GetComponent<Weather>().seasonNumber == 0))
        {
            SelectionPanel.SetActive(false);
            WeatherPanel.SetActive(false);


            timeLeft =0;
            a = 1;
            if (field1.GetComponent<Field>().plantName == "")
            {
                field1.GetComponent<Field>().plantName = "Empty";
                field1.GetComponent<SpriteRenderer>().sprite = empty;
                field1.GetComponent<Field>().plant = emptyPlant;
                print("feld1");
                field1.GetComponent<Field>().fieldIsChecked = true;
            }
            if (field2.GetComponent<Field>().plantName == "")
            {
                field2.GetComponent<Field>().plantName = "Empty";
                field2.GetComponent<SpriteRenderer>().sprite = empty;
                print("feld2");
                field2.GetComponent<Field>().plant = emptyPlant;
                field2.GetComponent<Field>().fieldIsChecked = true;
            }
            if (field3.GetComponent<Field>().plantName == "")
            {
                field3.GetComponent<Field>().plantName = "Empty";
                field3.GetComponent<SpriteRenderer>().sprite = empty;
                field3.GetComponent<Field>().plant = emptyPlant;
                field3.GetComponent<Field>().fieldIsChecked = true;
            }
            if (field4.GetComponent<Field>().plantName == "")
            {
                field4.GetComponent<Field>().plantName = "Empty";
                field4.GetComponent<SpriteRenderer>().sprite = empty;
                field4.GetComponent<Field>().plant = emptyPlant;
                field4.GetComponent<Field>().fieldIsChecked = true;
            }
        }
        if (field1.GetComponent<Field>().plantName != "" && field2.GetComponent<Field>().plantName != "" && field3.GetComponent<Field>().plantName != ""
            && field4.GetComponent<Field>().plantName != "")
        {
            timeLeft = 0;
            countdown.text = (timeLeft + " Sek.");
        }

    }

    public void StartCountdown()
    {
        if (b == 0)
        {
            StartCoroutine("LoseTime");
            Time.timeScale = 1; // Um sicher zu gehen, dass die Zeitskalierung stimmt
            b++;
        }
    }

    // Countdown bis dieser abgelaufen ist
    IEnumerator LoseTime()
    {
        while (timeLeft>0)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
        
    }
}