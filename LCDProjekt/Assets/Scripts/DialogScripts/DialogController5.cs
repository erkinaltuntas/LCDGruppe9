/*************************************************************************** 
* DialogController5
* Anwendung: Zur Steuerung des Dialogs in der Abschlussstory
* (erste Sprechblase)
* ------------------- 
* Zuletzt bearbeitet von: Victor Xu
* Datum der letzten Bearbeitung: 20.12.2018
* Grund für letzte Bearbeitung: Anpassung des Textes je nach Kredit
**************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Gibt den Text in einer Sprechblase Buchstabe für Buchstabe aus.
/// Guthaben ohne Kredit und Gewinn wird ausgerechnet und gespeichert.
/// Je nach Gewinn und Kreditanzahl(0 oder 1) wird ein anderer Text ausgegeben.
/// </summary>
/// <remarks>Es wirkt so als würde man gerade den Text tippen.</remarks>
public class DialogController5 : MonoBehaviour
{
    public float delay = 0.005f;
    private string fullText1;
    private string currentText = "";
    public Player player;
    string name;



    // Use this for initialization
    /// <summary>
    /// Die Start Methode wird bei der Initialisierung aufgerufen.
    /// Guthaben ohne Kredit und Gewinn wird ausgerechnet und gespeichert.
    /// Je nach Gewinn und Kreditanzahl(0 oder 1) wird ein anderer Text ausgegeben.
    /// Die Coroutine ShowText() wird gestartet.
    /// </summary>
    void Start()
    {
        
        player = Player.player;
        name = player.playerName;
        double money = player.money - (player.timeLoan * 1000);
        player.endTotal = money;
        double win = player.money - 1000 - (player.timeLoan * 1000);
        if (player.timeLoan==0)
        {
            if (win > 0)
            {
                fullText1 = "Wir sind zurück, " + name + "." + Environment.NewLine + Environment.NewLine + "Du hast insgesamt jetzt " + money + " Farm $. "
                + Environment.NewLine + Environment.NewLine + " Du hast also " + win + " Farm Dollar erwirtschaftet. ";
            }
            else if (win < 0)
            {
                fullText1 = "Wir sind zurück, " + name + "." + Environment.NewLine + Environment.NewLine + "Du hast insgesamt jetzt " + money + " Farm $. "
                + Environment.NewLine + Environment.NewLine + " Du hast also " + win*(-1) + " Farm Dollar verloren. ";
            }
            else
            {
                fullText1 = "Wir sind zurück, " + name + "." + Environment.NewLine + Environment.NewLine + "Du hast insgesamt jetzt " + money + " Farm $. "
                + Environment.NewLine + Environment.NewLine + " Du hast also genauso viel Geld wie am Anfang. ";
            }
        }
        else
        {
            if (win > 0)
            {
                money = money + (player.timeLoan * 1000);
                fullText1 = "Wir sind zurück, " + name + "." + Environment.NewLine + Environment.NewLine + "Du hast insgesamt jetzt " + money + " Farm $. "
                + Environment.NewLine + Environment.NewLine + " Du hast also " + win + " Farm Dollar erwirtschaftet, da Du dir " + player.timeLoan +
                " Mal " + Environment.NewLine + "Geld von Deiner Großmutter geliehen hast. ";
            }
            else if (win < 0)
            {
                money = money + (player.timeLoan * 1000);
                fullText1 = "Wir sind zurück, " + name + "." + Environment.NewLine + Environment.NewLine + "Du hast insgesamt jetzt " + money + " Farm $. "
                + Environment.NewLine + Environment.NewLine + " Du hast also " + win * (-1) + " Farm Dollar verloren, da Du dir " + player.timeLoan + 
                " Mal " + Environment.NewLine + "Geld von Deiner Großmutter geliehen hast. ";
            }
            else
            {
                fullText1 = "Wir sind zurück, " + name + "." + Environment.NewLine + Environment.NewLine + "Du hast insgesamt jetzt " + money + " Farm $. "
                + Environment.NewLine + Environment.NewLine + " Du hast also genauso viel Geld wie am Anfang. ";
            }
        }

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
