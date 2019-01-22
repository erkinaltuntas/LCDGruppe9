/*************************************************************************** 
* SoundFade
* Anwendung: SoundFade am Ende des Spiels und Einblendung des unsichtbaren
* End-Buttons, zur Beendigung des Spiels
*------------------- 
* Zuletzt bearbeitet von: Victor Xu
* Datum der letzten Bearbeitung: 22.01.2019
* Grund fuer letzte Bearbeitung: Ergaenzende Funktionen hinzugefuegt
**************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

/// <summary>
/// Ermoeglicht das Abklingen des InGame-Sounds am Ende des Spiels.
/// Blendet den End-Button, welcher das Spiel beendet ein.
/// </summary>
public class SoundFade : MonoBehaviour {

    public GameObject endButton;
    public GameObject clickToEnd;
    
    /// <summary>
    /// Solange die Lautstaerke groesser als null ist, wird 
    /// pro Durchlaufen der Schleife die <c>AudioListener.volume</c> um den 
    /// festen Wert 0.004 verringert. Die Methode laeuft solange bis
    /// <c>Audiolistener.volume</c> den Wert null erreicht hat.
    /// </summary>
    /// <returns></returns>
    public static IEnumerator FadeOut()
    {
        float startVolume = AudioListener.volume;

        while (AudioListener.volume > 0)
        {
            AudioListener.volume -= 0.00105f; 

            yield return null;
        }

        AudioListener.volume = 0;
    }


    /// <summary>
    /// Nach einer bestimmten Anzahl an Sekunden (waitTime), wird der End-Button aktiviert, 
    /// welcher das Spiel beendet und der passende Text wird eingeblendet.
    /// </summary>
    /// <param name="waitTime">Sekunden die gewartet werden soll.</param>
    /// <returns>Sekunden die gewartet wird</returns>
    private IEnumerator EndGame(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            endButton.SetActive(true);
            clickToEnd.SetActive(true);
        }
    }



    /// <summary>
    /// Diese Methode wird bei der Initialisierung aufgerufen.
    /// Startet die Coroutine Fadeout() und EndGame().
    /// </summary>
    void Start () {
        StartCoroutine(FadeOut());
        StartCoroutine(EndGame(14.0f));

    }
    
    void Update () {
    }
}
