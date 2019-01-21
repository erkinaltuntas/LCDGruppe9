/*************************************************************************** 
* TutorialPlayer
* Anwendung: Erstellen des Tutorial Spielers
* ------------------- 
* Zuletzt bearbeitet von: Cedric Meyer-Piening
* Datum der letzten Bearbeitung: 14.01.2019
* Grund für letzte Bearbeitung: Erstellung 
**************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Erstellung des Players für das Tutorial.
/// </summary>
public class TutorialPlayer : MonoBehaviour {
    public static TutorialPlayer tutorialPlayer;
    public string playerName;
    public int season;
    // Das Geld kann manuell im Inspektor angepasst werde
    public double money;
    //für Kredit
    public int timeLoan = 0;
    public bool creditShown;

    /// <summary>
    /// Initialisierung des TutorialPlayers
    /// </summary>
    void Start()
    {
        tutorialPlayer = this;
        creditShown = false;

        playerName = "TutorialPlayer";
    }

}

