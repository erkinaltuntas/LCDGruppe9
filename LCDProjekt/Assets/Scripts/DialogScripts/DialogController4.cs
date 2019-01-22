/*************************************************************************** 
* DialogController4
* Anwendung: Zur Steuerung des Dialogs in der Einfuehrungsstory
* (vierte Sprechblase)
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
public class DialogController4 : MonoBehaviour {
    public float delay = 0.005f;
    private string fullText1 = "Pass gut auf! " + Environment.NewLine + Environment.NewLine + "Ich zeige Dir mal wie das Ganze funktioniert... ";
    private string currentText = "";
    
    /// <summary>
    /// Die Start Methode wird bei der Initialisierung aufgerufen.
    /// Die Coroutine ShowText() wird gestartet.
    /// </summary>
    void Start() {
        StartCoroutine(ShowText());
    }

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
