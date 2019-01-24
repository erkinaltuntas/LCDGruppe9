/*************************************************************************** 
* ButtonScript
* Anwendung: Zur Steuerung der Button-Sounds
*------------------- 
* Zuletzt bearbeitet von: Cedric Meyer-Piening
* Datum der letzten Bearbeitung: 21.01.2019
* Grund für letzte Bearbeitung: Kommentare
* **************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Steuert Buttons
/// </summary>
[RequireComponent(typeof(Button))]
public class ButtonScript : MonoBehaviour {
    public AudioClip sound;
    private Button button { get { return GetComponent<Button>(); } }
    private AudioSource source { get { return GetComponent<AudioSource>(); } }
	
    /// <summary>
    /// Steuert Button-Sounds.
    /// </summary>
	void Start () {
        gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.playOnAwake = false;

        //wenn Button clicked
        button.onClick.AddListener(() => playSound());
	}
	
    /// <summary>
    /// Spielt den Sound des Buttons beim Anklicken.
    /// Sounds werden im Inspector zugewiesen.
    /// </summary>
    void playSound()
    {
        source.PlayOneShot(sound);
    }
}
