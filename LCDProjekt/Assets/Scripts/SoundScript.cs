using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour {
    //speichert Sounds
    public AudioSource audSource;

    //Sounds
    public AudioClip hoverSound;
    public AudioClip clickSound;

    public void playHoverSound()
    {
        audSource.PlayOneShot(hoverSound);
    }

    public void playClickSound()
    {
        audSource.PlayOneShot(clickSound);
    }
}
