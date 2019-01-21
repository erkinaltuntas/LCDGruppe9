/*************************************************************************** 
* Backgroundmusic
* Anwendung: Zur Anzeige des Timers
*------------------- 
* Zuletzt bearbeitet von: Erkin Altuntas
* Datum der letzten Bearbeitung: 20.01.2019
* Grund für letzte Bearbeitung: Kommentare
* **************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Musik wird über alle verschiedenen "Scenes" gespeichert und 
/// an- und ausschaltbar gemacht.
/// </summary>
public class Backgroundmusic : MonoBehaviour {
    static Backgroundmusic instance = null;


    /// <summary>
    /// Speichert die Musik und die Einstellung ueber die Level hinweg.
    /// </summary>
    private void Awake()
    {
        
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


    /// <summary>
    /// Button wird zugewiesen, damit dieser onClick Musik an/ausschaltet.
    /// </summary>
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
