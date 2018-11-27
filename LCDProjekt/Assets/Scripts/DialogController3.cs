using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController3 : MonoBehaviour {
    public float delay = 0.005f;
    private string fullText1 = "Großvater und ich werden in eine betreute Wohngemeinschaft für Senioren ziehen." + Environment.NewLine + Environment.NewLine + 
        "Es hat sehr lange gedauert, ihn zu überreden. Aber jetzt ist es Zeit." + Environment.NewLine + Environment.NewLine +
        "Wir werden dich jedoch in einem Jahr besuchen, um unsere alte Farm noch einmal begutachten zu können.. ";
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
