/*************************************************************************** 
* MusicScript
* Anwendung: Zur Anzeige des Timers
*------------------- 
* Zuletzt bearbeitet von: Erkin Altuntas
* Datum der letzten Bearbeitung: 30.12.2018
* Grund fuer letzte Bearbeitung: Erstellung
* **************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Es werden die Musikeinstellungen aktualisiert.
/// </summary>
public class MusicScript : MonoBehaviour {
    private Backgroundmusic backgroundmusic;
    public Button musicToggleButton;
    public Sprite musicOnSprite;
    public Sprite musicOffSprite;

	/// <summary>
    /// Ruft die Methode UpdateIconAndVolume auf.
    /// </summary>
	void Start () {
        backgroundmusic = GameObject.FindObjectOfType<Backgroundmusic>();
        UpdateIconAndVolume();
	}

    /// <summary>
    /// Aktualisiert die PlayerPrefs und pausiert die Musik.
    /// </summary>
    public void PauseMusic()
    {
        // PlayerPrefs aktualisieren
        backgroundmusic.ToggleSound();
        UpdateIconAndVolume();
    }
    
    /// <summary>
    /// Passt die Musikeinstellungen und die Anzeige an.
    /// </summary>
    void UpdateIconAndVolume()
    {
        // Passe das Sprite und das Volumen an
        if(PlayerPrefs.GetInt("Muted",0) == 0)
        {
            AudioListener.volume = 1;
            musicToggleButton.GetComponent<Image>().sprite = musicOnSprite;
        }
        else
        {
            AudioListener.volume = 0;
            musicToggleButton.GetComponent<Image>().sprite = musicOffSprite;
        }
    }
}
