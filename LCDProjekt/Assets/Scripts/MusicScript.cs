using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicScript : MonoBehaviour {
    private Backgroundmusic backgroundmusic;
    public Button musicToggleButton;
    public Sprite musicOnSprite;
    public Sprite musicOffSprite;

	// Use this for initialization
	void Start () {
        backgroundmusic = GameObject.FindObjectOfType<Backgroundmusic>();
        UpdateIconAndVolume();
	}

    public void PauseMusic()
    {
        // PlayerPrefs aktualisieren
        backgroundmusic.ToggleSound();
        UpdateIconAndVolume();
    }
    
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
