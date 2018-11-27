using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController4 : MonoBehaviour {
    public float delay = 0.005f;
    private string fullText1 = "Pass gut auf!" + Environment.NewLine + Environment.NewLine + "Ich zeige dir mal wie das Ganze funktioniert....";
    private string currentText = "";
    
    // Use this for initialization
    void Start() {
        StartCoroutine(ShowText());
    }

    private IEnumerator ShowText()
    {
        for(int i=0; i<fullText1.Length; i++)
        {
            currentText = fullText1.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }

    }


}
