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

public class DialogController5 : MonoBehaviour
{
    public float delay = 0.005f;
    private string fullText1;
    private string currentText = "";
    public Player player;
    // Use this for initialization
    void Start()
    {
        player = Player.player;
        double money = player.money - (player.timeLoan * 1000);
        double win = player.money - 1000 - (player.timeLoan * 1000);
        if (player.timeLoan==0)
        {
            if (win > 0)
            {
                fullText1 = "Wir sind zurück mein Kind!" + Environment.NewLine + Environment.NewLine + "Du hast insgesamt jetzt " + money + " Farm Dollar."
                + Environment.NewLine + Environment.NewLine + " Du hast also " + win + " Farm Dollar erwirtschaftet..";
            }
            else if (win < 0)
            {
                fullText1 = "Wir sind zurück mein Kind!" + Environment.NewLine + Environment.NewLine + "Du hast insgesamt jetzt " + money + " Farm Dollar."
                + Environment.NewLine + Environment.NewLine + " Du hast also " + win*(-1) + " Farm Dollar verloren..";
            }
            else
            {
                fullText1 = "Wir sind zurück mein Kind!" + Environment.NewLine + Environment.NewLine + "Du hast insgesamt jetzt " + money + " Farm Dollar."
                + Environment.NewLine + Environment.NewLine + " Du hast also genauso viel Geld wie am Anfang..";
            }
        }
        else
        {
            if (win > 0)
            {
                fullText1 = "Wir sind zurück mein Kind!" + Environment.NewLine + Environment.NewLine + "Du hast insgesamt jetzt " + money + " Farm Dollar."
                + Environment.NewLine + Environment.NewLine + " Du hast also " + win + " Farm Dollar erwirtschaftet..";
            }
            else if (win < 0)
            {
                money = money + (player.timeLoan * 1000);
                fullText1 = "Wir sind zurück mein Kind!" + Environment.NewLine + Environment.NewLine + "Du hast insgesamt jetzt " + money + " Farm Dollar."
                + Environment.NewLine + Environment.NewLine + " Du hast also " + win * (-1) + " Farm Dollar verloren, da du " + player.timeLoan + 
                " Mal die" + Environment.NewLine + "Briefmarkensammlung deiner Großmutter verkauft hast..";
            }
            else
            {
                fullText1 = "Wir sind zurück mein Kind!" + Environment.NewLine + Environment.NewLine + "Du hast insgesamt jetzt " + money + " Farm Dollar."
                + Environment.NewLine + Environment.NewLine + " Du hast also genauso viel Geld wie am Anfang..";
            }
        }

        StartCoroutine(ShowText());
    }

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
