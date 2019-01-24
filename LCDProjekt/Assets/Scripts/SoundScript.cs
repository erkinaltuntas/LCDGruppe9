/*************************************************************************** 
* SoundScript
* Anwendung: Zuweisung von Sound fuer alle Buttons
*------------------- 
* Zuletzt bearbeitet von: Thomas Wieschermann
* Datum der letzten Bearbeitung: 17.01.2019
* Grund fuer letzte Bearbeitung: Kommentare/Code Pflege
**************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Zuweisung der Sounddateien fuer alle Buttons im Spiel.
/// Genauere Beschreibungen innerhalb der Klasse.
/// </summary>
public class SoundScript : MonoBehaviour {
    
    public AudioSource audSource;

    //Sounds
    public AudioClip hoverSound;
    public AudioClip clickSound;

    /// <summary>
    /// <c>hoverSound</c> wird abgespielt, wenn der Spieler die Maus ueber einen Button fuehrt.
    /// </summary>
    public void playHoverSound()
    {
        audSource.PlayOneShot(hoverSound);
    }

    /// <summary>
    /// <c>clickSound</c> wird abgespielt, wenn der Spieler mit der linken Maustaste auf einen Button drueckt
    /// </summary>
    public void playClickSound()
    {
        audSource.PlayOneShot(clickSound);
    }
}
