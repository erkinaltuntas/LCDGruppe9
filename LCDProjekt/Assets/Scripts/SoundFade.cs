using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFade : MonoBehaviour {
    


   

    public static IEnumerator FadeOut()
    {
        float startVolume = AudioListener.volume;

        while (AudioListener.volume > 0)
        {
            AudioListener.volume -= 0.004f; 

            yield return null;
        }

        AudioListener.volume = 0;
    }
    

    // Use this for initialization
    void Start () {
        StartCoroutine(FadeOut());

    }
	
	// Update is called once per frame
	void Update () {
    }
}
