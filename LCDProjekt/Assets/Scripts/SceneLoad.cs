/*************************************************************************** 
* SceneLoad
* Anwendung: Zur Steuerung der Szenenuebergaenge
* ------------------- 
* Zuletzt bearbeitet von: Erkin Altuntas
* Datum der letzten Bearbeitung: 10.12.2018
* Grund für letzte Bearbeitung: Kommentare/Code Pflege
**************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Die Klasse beinhaltet zwei Methoden, die mit den Szenen interagieren.
/// </summary>
public class SceneLoad : MonoBehaviour {

    // Geht in die nächste Szene über
    /// <summary>
    /// Lädt die nächste Szene
    /// </summary>
    public void loadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Beendet das Spiel
    /// <summary>
    /// Beendet das Spiel.
    /// </summary>
    public void quitGame()
    {
        Application.Quit();
    }
}
