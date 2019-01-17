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

/// <summary>
/// Gibt den Text in einer Sprechblase Buchstabe für Buchstabe aus.
/// </summary>
/// <remarks>Es wirkt so als würde man gerade den Text tippen.</remarks>
public class DialogController1 : MonoBehaviour {

    public GameObject speechbubble;
    public string fullText1;

    // Schnelligkeit der Anzeige des Textes
    public float delay = 0.005f;
    // Text der ersten Sprechblase
    
    private string currentText = "";


    // Use this for initialization
    /// <summary>
    /// Die Start Methode wird bei der Initialisierung aufgerufen.
    /// Der DialogController wird gleich die Variable dialogController gesetzt.
    /// fullText1 wird gleich den Text gesetzt, welcher ausgegeben werden soll.
    /// Die Coroutine ShowText() wird gestartet.
    /// </summary>
    void Start() {

        DialogController dialogController = speechbubble.GetComponent<DialogController>();
        fullText1 = "Ach hallo " + dialogController.playerName + "." + Environment.NewLine + Environment.NewLine +
        "Wir möchten dir schon etwas früher als du vielleicht erwartet hättest etwas vererben. " + Environment.NewLine + Environment.NewLine +
        "Großvater und ich werden immer älter… und die Arbeit nicht leichter... ";
        StartCoroutine(ShowText());

    }


    // Zeigt den Dialog Buchstabe fuer Buchstaben
    /// <summary>
    /// Gibt den Text Buchstabe für Buchstabe aus.
    /// </summary>
    /// <returns>Gibt eine zeitliche Verzögerung zurück.</returns>
    /// <remarks>Es wirkt so als würde man gerade den Text tippen.</remarks>
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
