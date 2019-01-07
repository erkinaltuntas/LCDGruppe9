/*************************************************************************** 
* TutorialPlayer
* Anwendung: Erstellen des Tutorial Spielers
* ------------------- 
* Zuletzt bearbeitet von: Erkin Altuntas
* Datum der letzten Bearbeitung: 30.12.2018
* Grund für letzte Bearbeitung: Erstellung 
**************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPlayer : MonoBehaviour {
    public static TutorialPlayer tutorialPlayer;
    public string playerName;
    public int season;

    // Das Geld kann manuell im Inspektor angepasst werde
    public double money;


    //für Kredit
    public int timeLoan = 0;
    public bool creditShown;


    // Use this for initialization
    void Start()
    {
        tutorialPlayer = this;
        creditShown = false;

        playerName = "TutorialPlayer";
    }

    // Update is called once per frame
    void Update()
    {

    }

}

