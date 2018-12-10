/*************************************************************************** 
* SoundScript
* Anwendung: Zuweisung von Sound fuer alle Buttons
*------------------- 
* Zuletzt bearbeitet von: Erkin Altuntas
* Datum der letzten Bearbeitung: 10.12.2018
* Grund für letzte Bearbeitung: Kommentare/Code Pflege
**************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour {
    
    public AudioSource audSource;

    //Sounds
    public AudioClip hoverSound;
    public AudioClip clickSound;

    // hoverSound wird abgespielt, wenn Maus ueber einen Button geht
    public void playHoverSound()
    {
        audSource.PlayOneShot(hoverSound);
    }

    // clickSound wird abgespielt, wenn Maus auf einen Button drueckt
    public void playClickSound()
    {
        audSource.PlayOneShot(clickSound);
    }
}
