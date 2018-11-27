using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController1 : MonoBehaviour {
    public float delay = 0.005f;
    private string fullText1 = "Hallo, mein Liebling." + Environment.NewLine + Environment.NewLine +
        "Wir möchten dir schon etwas früher als du vielleicht erwartet hättest etwas vererben." + Environment.NewLine + Environment.NewLine +
        "Großvater und ich werden immer älter… und die Arbeit nicht leichter..";
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
