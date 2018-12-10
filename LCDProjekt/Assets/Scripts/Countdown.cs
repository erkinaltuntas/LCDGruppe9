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
    public int timeLeft = 60; //Seconds Overall
    public TextMeshProUGUI countdown; //UI Text Object
    void Start()
    {
        StartCoroutine("LoseTime");
        Time.timeScale = 1; // Um sicher zu gehen, dass die Zeitskalierung stimmt
    }
    void Update()
    {
        countdown.text = ("" + timeLeft); // Zeit im Canvas anzeigen
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