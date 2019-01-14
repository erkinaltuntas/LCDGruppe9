/*************************************************************************** 
* Weather
* Anwendung: Zur Defintion des Wetters sowie der Steuerung, ob sie von 
* Duerre oder Frost betroffen sind
*------------------- 
* Zuletzt bearbeitet von: Thomas Wieschermann
* Datum der letzten Bearbeitung: 20.12.2018
* Grund für letzte Bearbeitung: Wetteranpassung
**************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weather : MonoBehaviour {
    public string seasonName;
    public int seasonNumber;
    public double frostProb;
    public double droughtProb;
    public static bool frost = false;
    public static bool drought = false;

    public int random1, random2;

    // Use this for initialization
    void Start () {

        random1 = Random.Range(0, 10);
        random2 = Random.Range(0, 10);
        frost = isFrost();
        drought = isDrought();

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
