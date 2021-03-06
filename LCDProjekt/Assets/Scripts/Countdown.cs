﻿/*************************************************************************** 
* Countdown
* Anwendung: Zur Anzeige des Timers
*------------------- 
* Zuletzt bearbeitet von: Cedric Meyer-Piening
* Datum der letzten Bearbeitung: 15.01.2019
* Grund fuer letzte Bearbeitung: Kommentare
* **************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using TMPro;

/// <summary>
/// Zeigt den Timer an und bepflanzt die leeren Felder nach Ablauf.
/// </summary>
public class Countdown : MonoBehaviour
{
    int timeLeft = 90; //Seconds Overall
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
    /// <summary>
    /// Initialisierung der benoetigten Objekte
    /// </summary>
    void Start()
    {
        
        field1 = GameObject.Find("Field 1");
        field2 = GameObject.Find("Field 2");
        field3 = GameObject.Find("Field 3");
        field4 = GameObject.Find("Field 4");

        weather = GameObject.Find("Weather");
    }

    /// <summary>
    /// Zeigt den Timer an und bepflanzt nach Ablauf der Zeit die leeren Felder.
    /// </summary>
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
                field1.GetComponent<Field>().fieldIsChecked = true;
            }
            if (field2.GetComponent<Field>().plantName == "")
            {
                field2.GetComponent<Field>().plantName = "Empty";
                field2.GetComponent<SpriteRenderer>().sprite = empty;
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

    /// <summary>
    /// Startet den Timer.
    /// </summary>
    public void StartCountdown()
    {
        if (b == 0)
        {
            StartCoroutine("LoseTime");
            Time.timeScale = 1; // Um sicher zu gehen, dass die Zeitskalierung stimmt
            b++;
        }
    }
    /// <summary>
    /// Zählt runter.
    /// </summary>
    /// <returns></returns>
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