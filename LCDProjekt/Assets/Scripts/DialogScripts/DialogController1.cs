/*************************************************************************** 
* DialogController1
* Anwendung: Zur Steuerung des Dialogs in der Einfuehrungsstory
* (erste Sprechblase)
* ------------------- 
* Zuletzt bearbeitet von: Erkin Altuntas
* Datum der letzten Bearbeitung: 10.12.2018
* Grund für letzte Bearbeitung: Kommentare/Code Pflege
**************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController1 : MonoBehaviour {
    // Schnelligkeit der Anzeige des Textes
    public float delay = 0.005f;
    // Text der ersten Sprechblase
    private string fullText1 = "Hallo, mein Liebling." + Environment.NewLine + Environment.NewLine +
        "Wir möchten dir schon etwas früher als du vielleicht erwartet hättest etwas vererben." + Environment.NewLine + Environment.NewLine +
        "Großvater und ich werden immer älter… und die Arbeit nicht leichter..";
    private string currentText = "";


    // Use this for initialization
    void Start() {
        StartCoroutine(ShowText());
    }

    // Zeigt den Dialog Buchstabe fuer Buchstaben
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
