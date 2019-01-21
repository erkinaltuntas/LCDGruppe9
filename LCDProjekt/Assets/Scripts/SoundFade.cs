/*************************************************************************** 
* SoundFade
* Anwendung: SoundFade am Ende des Spiels
*------------------- 
* Zuletzt bearbeitet von: Thomas Wieschermann
* Datum der letzten Bearbeitung: 17.01.2019
* Grund für letzte Bearbeitung: Kommentare/Code Pflege
**************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

/// <summary>
/// Ermöglicht das Abklingen des InGame-Sounds am Ende des Spiels
/// </summary>
public class SoundFade : MonoBehaviour {
    
    /// <summary>
    /// Solange die Lautstärke groesser als null ist, wird 
    /// pro Durchlaufen der Schleife die <c>AudioListener.volume</c> um den 
    /// festen Wert 0.004 verringert. Die Methode läuft solange bis
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
    /// StartCoroutine und Update erlauben es zusammen hier FadeOut einmal pro 
    /// in-Game frame aufzurufen.
    /// </summary>
    void Start () {
        StartCoroutine(FadeOut());

    }

    /// <summary>
    /// StartCoroutine und Update erlauben es zusammen hier FadeOut einmal pro 
    /// in-Game frame aufzurufen.
    /// </summary>
    void Update () {
    }
}
