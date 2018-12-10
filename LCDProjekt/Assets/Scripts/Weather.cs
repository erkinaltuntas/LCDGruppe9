/*************************************************************************** 
* Weather
* Anwendung: Zur Defintion des Wetters sowie der Steuerung, ob sie von 
* Duerre oder Frost betroffen sind
*------------------- 
* Zuletzt bearbeitet von: Erkin Altuntas
* Datum der letzten Bearbeitung: 10.12.2018
* Grund für letzte Bearbeitung: Kommentare/Code Pflege
**************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weather : MonoBehaviour {
    public string seasonName;
    public double frostProb;
    public double droughtProb;

    public int random1, random2;

    // Use this for initialization
    void Start () {
        seasonName = "Frühling";

        random1 = Random.Range(0, 11);
        random2 = Random.Range(0, 11);
    }

    public bool isFrost()
    {
        if (random1 <= this.frostProb * 10)
        {
            return true;
        }
        return false;
    }

    public bool isDrought()
    {
        if (random2 <= this.droughtProb * 10)
        {
            return true;
        }
        return false;
    }
}
