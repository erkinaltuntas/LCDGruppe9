/*************************************************************************** 
* DialogController6
* Anwendung: Zur Steuerung des Dialogs in der Abschlussstory
* (zweite Sprechblase)
* ------------------- 
* Zuletzt bearbeitet von: Erkin Altuntas
* Datum der letzten Bearbeitung: 11.12.2018
* Grund für letzte Bearbeitung: Anzeige der Verluste/Gewinne durch Frost
* und Dürre
**************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Gibt den Text in einer Sprechblase Buchstabe für Buchstabe aus.
/// Verlorenes Geld durch Frost und Dürre wird ausgerechnet.
/// Je nach Verlust wird ein anderer Text ausgegeben.
/// </summary>
/// <remarks>Es wirkt so als würde man gerade den Text tippen.</remarks>
public class DialogController6 : MonoBehaviour
{
    public float delay = 0.005f;
    private string fullText1;
    private string currentText = "";
    public Player player;
    double lostThroughFrost;
    double lostThroughDrought;


    // Use this for initialization
    /// <summary>
    /// Die Start Methode wird bei der Initialisierung aufgerufen.
    /// Verlorenes Geld durch Frost und Dürre wird ausgerechnet.
    /// Je nach Verlust wird ein anderer Text in fullText1 gespeichert.
    /// Die Coroutine ShowText() wird gestartet.
    /// </summary>
    void Start()
    {
        player = Player.player;
        double money = player.money;
        double win = player.money - 1000;
        lostThroughFrost = lostThroughDrought = 0;

        for (int i=0; i<player.droughtIndex; i++)
        {
            lostThroughDrought += player.droughtLost[i];
        }

        for (int i = 0; i < player.frostIndex; i++)
        {
            lostThroughFrost += player.frostLost[i];
        }

        if(lostThroughDrought<0 && lostThroughFrost < 0)
        {
            fullText1 = "Unsere Farm ist bei dir in sicheren Händen. " + Environment.NewLine + Environment.NewLine +
                "Dir sind wegen dem Frost insgesamt " + lostThroughFrost*(-1) + " FarmDollar entgangen. " + Environment.NewLine + Environment.NewLine +
                "Außerdem hat die Dürre dir insgesamt " + lostThroughDrought*(-1) + " FarmDollar versaut... Schade. ";
        }
        else if(lostThroughDrought < 0 && lostThroughFrost >= 0)
        {
            fullText1 = "Unsere Farm ist bei dir in sicheren Händen. " + Environment.NewLine + Environment.NewLine +
             "Dir sind wegen der Dürre insgesamt " + lostThroughDrought * (-1) + " FarmDollar entgangen. " + Environment.NewLine + Environment.NewLine +
             "Der Frost konnte dir jedoch nichts antun. Sehr schön! ";
        }
        else if (lostThroughDrought >= 0 && lostThroughFrost < 0)
        {
            fullText1 = "Unsere Farm ist bei dir in sicheren Händen. " + Environment.NewLine + Environment.NewLine +
             "Dir sind wegen dem Frost insgesamt " + lostThroughFrost * (-1) + " FarmDollar entgangen. " + Environment.NewLine + Environment.NewLine +
             "Die Dürre konnte dir jedoch nichts antun. Sehr schön! ";
        }
        else
        {
            fullText1 = "Unsere Farm ist bei dir in sicheren Händen. " + Environment.NewLine + Environment.NewLine +
                "Du hast keine Verluste verzeichnet! ";
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
