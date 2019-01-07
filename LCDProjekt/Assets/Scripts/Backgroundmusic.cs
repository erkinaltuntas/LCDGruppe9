/*************************************************************************** 
* Backgroundmusic
* Anwendung: Zur Anzeige des Timers
*------------------- 
* Zuletzt bearbeitet von: Erkin Altuntas
* Datum der letzten Bearbeitung: 30.12.2018
* Grund für letzte Bearbeitung: Erstellung
* **************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backgroundmusic : MonoBehaviour {
    static Backgroundmusic instance = null;



    private void Awake()
    {
        // Speichert die Musik und die Einstellung ueber die Level hinweg
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }


    // Wird Button zugewiesen, damit dieser onClick Musik an/ausschaltet
    public void ToggleSound()
    {
        if(PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            PlayerPrefs.SetInt("Muted", 1);
            
        }
        else
        {
            PlayerPrefs.SetInt("Muted", 0);
            
        }
    }

}
