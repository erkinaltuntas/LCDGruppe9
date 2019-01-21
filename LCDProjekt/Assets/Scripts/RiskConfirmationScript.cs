/*************************************************************************** 
* RiskConfirmationScript
* Anwendung: Zur Abfrage der Zustimmung des Spielers ueber seine Risikoklasse
*------------------- 
* Zuletzt bearbeitet von: Cedric Meyer-Piening
* Datum der letzten Bearbeitung: 21.01.2019
* Grund fuer letzte Bearbeitung: Kommentare
**************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Prueft die Zustimmung oder Ablehnung der Risikoklassifizierung des Spielers.
/// </summary>
public class RiskConfirmationScript : MonoBehaviour {
    public Button confirmButton, rejectButton;
    public Player player;
	
    /// <summary>
    /// Weisst den Buttons die Aufgaben zu und initialisiert den Player.
    /// </summary>
	void Start () {
        // weise Buttons die Aufgaben onClick zu
        confirmButton.GetComponentInChildren<Button>().onClick.AddListener(TaskOnConfirm);
        rejectButton.GetComponentInChildren<Button>().onClick.AddListener(TaskOnReject);

        // Spieler identifizieren
        player = Player.player;
    }

    /// <summary>
    /// Riskoklasse wird bestaetigt
    /// </summary>
    void TaskOnConfirm()
    {
        player.riskConfirmed = true;

    }

    /// <summary>
    /// Risikoklasse wird nicht bestaetigt.
    /// </summary>
    void TaskOnReject()
    {
        player.riskConfirmed = false;
    }
}
