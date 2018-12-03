using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundScript : MonoBehaviour {


    //zum Abspielen der Sounds
    public AudioSource objectSound;

    //Sounds
    public AudioClip hoverSound;
    public AudioClip clickSound;

    //spielt hoverSound wenn über Button gegangen wird
    public void playHoverSound()
    {
        objectSound.PlayOneShot(hoverSound);
    }

    //spielt clickSound wenn auf Button gedrückt wird
    public void playClickSound()
    {
        objectSound.PlayOneShot(clickSound);
    }
}
