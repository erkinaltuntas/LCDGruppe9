/*************************************************************************** 
* DialogController5
* Anwendung: Zur Steuerung des Dialogs in der Abschlussstory
* (erste Sprechblase)
* ------------------- 
* Zuletzt bearbeitet von: Cedric Meyer-Piening
* Datum der letzten Bearbeitung: 17.12.2018
* Grund für letzte Bearbeitung: Risikowert hinzugefügt
**************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController7 : MonoBehaviour
{
    public float delay = 0.005f;
    private string fullText1;
    private string currentText = "";
    public Player player;

    // Use this for initialization
    void Start()
    {
        player = Player.player;
        double money = player.money;
        double win = player.money - 1000;
        double risk = player.calculateRisk();
        string risikoklasse = "";

        if(risk < 0.7d)
        {
            risikoklasse = "Sicherheit";
        }
        else if (0.7d <= risk && risk < 0.9d)
        {
            risikoklasse = "Ertrag";
        }
        else if (0.9d <= risk && risk < 1.1d)
        {
            risikoklasse = "Wachstum";
        }
        else if (1.1d <= risk && risk < 1.3d)
        {
            risikoklasse = "Risiko";
        }
        else if (1.3d <= risk)
        {
            risikoklasse = "Spekulativ";
        }


        fullText1 = Environment.NewLine + "Wir sind sehr stolz auf dich!" + Environment.NewLine + Environment.NewLine + "Mach weiter so und du wirst es noch weit bringen! " 
            + Environment.NewLine + Environment.NewLine + " Viel Glück! Risikoklasse: " + risikoklasse + ". Risikoscore:" + risk + ".";

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
