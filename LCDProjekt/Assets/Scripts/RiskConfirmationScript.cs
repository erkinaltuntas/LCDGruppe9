/*************************************************************************** 
* RiskConfirmationScript
* Anwendung: Zur Abfrage der Zustimmung des Spielers über seine Risikoklasse
*------------------- 
* Zuletzt bearbeitet von: Erkin Altuntas
* Datum der letzten Bearbeitung: 14.12.2018
* Grund für letzte Bearbeitung: Erstellung
**************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RiskConfirmationScript : MonoBehaviour {
    public Button confirmButton, rejectButton;
    public Player player;
	// Use this for initialization
	void Start () {
        // weise Buttons die Aufgaben onClick zu
        confirmButton.GetComponentInChildren<Button>().onClick.AddListener(TaskOnConfirm);
        rejectButton.GetComponentInChildren<Button>().onClick.AddListener(TaskOnReject);

        // Spieler identifizieren
        player = Player.player;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    // Riskoklasse bestätigt
    void TaskOnConfirm()
    {
        player.riskConfirmed = true;

    }

    // Risikoklasse nicht bestätigt
    void TaskOnReject()
    {
        player.riskConfirmed = false;
    }
}
