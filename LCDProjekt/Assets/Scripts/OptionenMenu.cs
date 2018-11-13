using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionenMenu : MonoBehaviour {

    public AudioMixer audioMixer;
    

    public void setVolume(float lautstaerke)
    {
        audioMixer.SetFloat("lautstaerke", lautstaerke);
        
    }
}
