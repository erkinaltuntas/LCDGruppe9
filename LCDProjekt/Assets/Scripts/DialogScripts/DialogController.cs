﻿/*************************************************************************** 
* DialogController
* Anwendung: Zur Steuerung des Dialogs in der Einfuehrungsstory
* (erste Sprechblase)
* ------------------- 
* Zuletzt bearbeitet von: Erkin Altuntas
* Datum der letzten Bearbeitung: 14.12.2018
* Grund für letzte Bearbeitung: Erstellung
**************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Gibt den Text in einer Sprechblase Buchstabe für Buchstabe aus.
/// Fragt nach dem Namen des Spielers und speichert den eingegebenen Namen.
/// </summary>
/// <remarks>Es wirkt so als würde man gerade den Text tippen.</remarks>
public class DialogController : MonoBehaviour
{
    // Schnelligkeit der Anzeige des Textes
    public float delay = 0.005f;
    // Text der ersten Sprechblase
    private string fullText1 = "Hallo mein Kind." + Environment.NewLine + Environment.NewLine + "Wie war nochmal Dein Name? ";
    private string currentText = "";

    public InputField inputName;
    public string playerName;

    public GameObject speechBubble1, speechBubble2;
    public GameObject confirmButton, nextButton2;
    
    /// <summary>
    /// Die Start Methode wird bei der Initialisierung aufgerufen.
    /// TaskOnConfirm wird dem confirmButton zugeordnet.
    /// Die Coroutine ShowText() wird gestartet.
    /// </summary>
    void Start()
    {
        StartCoroutine(ShowText());
        playerName = PlayerPrefs.GetString("PlayerName");
        confirmButton.GetComponentInChildren<Button>().onClick.AddListener(TaskOnConfirm);
    }

    // Zeigt den Dialog Buchstabe fuer Buchstaben
    /// <summary>
    /// Gibt den Text Buchstabe für Buchstabe aus.
    /// </summary>
    /// <returns>Gibt eine zeitliche Verzögerung zurück.</returns>
    /// <remarks>Es wirkt so als würde man gerade den Text tippen.</remarks>
    private IEnumerator ShowText()
    {
        for (int i = 0; i < fullText1.Length; i++)
        {
            currentText = fullText1.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }

    }

    /// <summary>
    /// Setzt den eingegeben Namen gleich playerName.
    /// </summary>
    public void saveName()
    {
        playerName = inputName.text;
        PlayerPrefs.SetString("PlayerName", playerName);
    }

    /// <summary>
    /// Falls der eingebene Name nicht leer ist, wird die nächste Sprechblase angezeigt.
    /// Ansonsten passiert nichts.
    /// </summary>
    void TaskOnConfirm()
    {
        if (!inputName.text.Equals(""))
        {
            speechBubble1.SetActive(false);
            speechBubble2.SetActive(true);
            confirmButton.SetActive(false);
            nextButton2.SetActive(true);
        }
        else
        {
            // kein Wert wurde eingegeben
        }
    }
}