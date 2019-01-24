/*************************************************************************** 
* ChangeSceneAuto
* Anwendung: Wechselt nach einer bestimmten Zeit in die naechste Szene ueber.
*------------------- 
* Zuletzt bearbeitet von: Victor Xu
* Datum der letzten Bearbeitung: 21.01.2019
* Grund fuer letzte Bearbeitung: Erstellung
**************************************************************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// Springt nach vier Sekunden in die naechste Szene ueber.
/// </summary>
public class ChangeSceneAuto : MonoBehaviour {

    /// <summary>
    /// Diese Methode wird bei der Initialisierung ausgefuehrt.
    /// Starte die Coroutine WaitNextScene.
    /// </summary>
    void Start () {
        StartCoroutine(WaitNextScene(4.0f));
    }

    /// <summary>
    /// Warte eine bestimmte Anzahl an Sekunden (in dem Fall vier Sekunden) und geht dann in die naechste Szene ueber.
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
