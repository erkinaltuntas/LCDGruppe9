﻿/*************************************************************************** 
* DialogController7
* Anwendung: Zur Steuerung des Dialogs in der Abschlussstory
* (letzte Sprechblase)
* ------------------- 
* Zuletzt bearbeitet von: Anna Buchner
* Datum der letzten Bearbeitung: 18.12.2018
* Grund für letzte Bearbeitung: Risikoklasse ausgewertet und Einfluss der Schock-Events auf den Score
**************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;

/// <summary>
/// Gibt den Text in einer Sprechblase Buchstabe für Buchstabe aus.
/// Risiko und Risikoklasse wird ausgerechnet.
/// </summary>
/// <remarks>Es wirkt so als würde man gerade den Text tippen.</remarks>
public class DialogController7 : MonoBehaviour
{
    public float delay = 0.005f;
    private string fullText1;
    private string currentText = "";
    public Player player;
    
    /// <summary>
    /// Die Start Methode wird bei der Initialisierung aufgerufen.
    /// calculateRisk() aus der Klasse Player wird ausgeführt.
    /// getRiskClass() aus der Klasse Player wird ausgeführt.
    /// Die Coroutine ShowText() wird gestartet.
    /// </summary>
    void Start()
    {
        player = Player.player;

        // Risiko auswerten
        player.calculateRisk();
        player.getRiskClass();


        // Abschlusstext Risikoklasse
        fullText1 = Environment.NewLine + "Wir sind sehr stolz auf Dich! " + Environment.NewLine + Environment.NewLine + "Mach weiter so und Du wirst es noch weit bringen! "
            + Environment.NewLine + Environment.NewLine + " Viel Glück! ";

        StartCoroutine(ShowText());
    }

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


}
