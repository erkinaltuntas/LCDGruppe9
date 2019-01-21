/*************************************************************************** 
* ChangeSceneAuto
* Anwendung: Wechselt nach einer bestimmten Zeit in die nächste Szene über.
*------------------- 
* Zuletzt bearbeitet von: Victor Xu
* Datum der letzten Bearbeitung: 21.01.2019
* Grund für letzte Bearbeitung: Erstellung
**************************************************************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// Springt nach vier Sekunden in die nächste Szene über.
/// </summary>
public class ChangeSceneAuto : MonoBehaviour {

    // Use this for initialization
    /// <summary>
    /// Diese Methode wird bei der Initialisierung ausgeführt.
    /// Starte die Coroutine WaitNextScene.
    /// </summary>
    void Start () {
        StartCoroutine(WaitNextScene(4.0f));
    }

    /// <summary>
    /// Warte eine bestimmte Anzahl an Sekunden (in dem Fall vier Sekunden) und geht dann in die nächste Szene über.
    /// </summary>
    /// <param name="waitTime">Anzahl an Sekunden die gewartet werden soll.</param>
    /// <returns>WaitforScondes, Sekunden die gewartet werden, bis es im Code weiter geht.</returns>
    private IEnumerator WaitNextScene(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
