/*************************************************************************** 
* Weather
* Anwendung: Zur Defintion des Wetters sowie der Steuerung, ob sie von 
* Duerre oder Frost betroffen sind
*------------------- 
* Zuletzt bearbeitet von: Cedric Meyer-Piening
* Datum der letzten Bearbeitung: 10.12.2018
* Grund für letzte Bearbeitung: Neu erstellt
* **************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using TMPro;

public class Countdown : MonoBehaviour
{
    int timeLeft = 6; //Seconds Overall
    public TextMeshProUGUI countdown; //UI Text Object
    public Sprite empty;
    GameObject field1;
    GameObject field2;
    GameObject field3;
    GameObject field4;
    GameObject weatherButton, harvestPanel, helpButton;

    void Start()
    {
        StartCoroutine("LoseTime");
        Time.timeScale = 1; // Um sicher zu gehen, dass die Zeitskalierung stimmt
        field1 = GameObject.Find("Field 1");
        field2 = GameObject.Find("Field 2");
        field3 = GameObject.Find("Field 3");
        field4 = GameObject.Find("Field 4");
        weatherButton = GameObject.Find("WeatherButton");
        helpButton = GameObject.Find("HelpButton");
        harvestPanel = GameObject.Find("HarvestPanel");
    }
    void Update()
    {
        countdown.text = ("" + timeLeft); // Zeit im Canvas anzeigen
        if(timeLeft == 0)
        {
            timeLeft=0;
            if (field1.GetComponent<Field>().plantName == "")
            {
                field1.GetComponent<Field>().plantName = "Empty";
                field1.GetComponent<SpriteRenderer>().sprite = empty;
                print("feld1");
                field1.GetComponent<Field>().fieldIsChecked = true;
            }
            if (field2.GetComponent<Field>().plantName == "")
            {
                field2.GetComponent<Field>().plantName = "Empty";
                field2.GetComponent<SpriteRenderer>().sprite = empty;
                print("feld2");
                field2.GetComponent<Field>().fieldIsChecked = true;
            }
            if (field3.GetComponent<Field>().plantName == "")
            {
                field3.GetComponent<Field>().plantName = "Empty";
                field3.GetComponent<SpriteRenderer>().sprite = empty;
                field3.GetComponent<Field>().fieldIsChecked = true;
            }
            if (field4.GetComponent<Field>().plantName == "")
            {
                field4.GetComponent<Field>().plantName = "Empty";
                field4.GetComponent<SpriteRenderer>().sprite = empty;
                field4.GetComponent<Field>().fieldIsChecked = true;
            }
            harvestPanel.SetActive(true);
            helpButton.SetActive(false);
            weatherButton.SetActive(false);
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