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

public class DialogController6 : MonoBehaviour
{
    public float delay = 0.005f;
    private string fullText1;
    private string currentText = "";
    public Player player;
    double lostTroughFrost;
    double lostTroughDrought;
    // Use this for initialization
    void Start()
    {
        player = Player.player;
        double money = player.money;
        double win = player.money - 1000;
        lostTroughFrost = lostTroughDrought = 0;

        for (int i=0; i<player.droughtIndex; i++)
        {
            lostTroughDrought += player.droughtLost[i];
        }

        for (int i = 0; i < player.frostIndex; i++)
        {
            lostTroughFrost += player.frostLost[i];
        }

        if(lostTroughDrought<0 && lostTroughFrost < 0)
        {
            fullText1 = "Unsere Farm ist bei dir in sicheren Händen. " + Environment.NewLine + Environment.NewLine +
                "Dir sind wegen dem Frost insgesamt " + lostTroughFrost*(-1) + " FarmDollar entgangen. " + Environment.NewLine + Environment.NewLine +
                "Außerdem hat die Dürre dir insgesamt " + lostTroughDrought*(-1) + " FarmDollar versaut... Schade. ";
        }
        else if(lostTroughDrought < 0 && lostTroughFrost >= 0)
        {
            fullText1 = "Unsere Farm ist bei dir in sicheren Händen. " + Environment.NewLine + Environment.NewLine +
             "Dir sind wegen der Dürre insgesamt " + lostTroughDrought * (-1) + " FarmDollar entgangen. " + Environment.NewLine + Environment.NewLine +
             "Der Frost konnte dir jedoch nichts antun. Sehr schön! ";
        }
        else if (lostTroughDrought >= 0 && lostTroughFrost < 0)
        {
            fullText1 = "Unsere Farm ist bei dir in sicheren Händen. " + Environment.NewLine + Environment.NewLine +
             "Dir sind wegen dem Frost insgesamt " + lostTroughFrost * (-1) + " FarmDollar entgangen. " + Environment.NewLine + Environment.NewLine +
             "Die Dürre konnte dir jedoch nichts antun. Sehr schön! ";
        }
        else
        {
            fullText1 = "Unsere Farm ist bei dir in sicheren Händen. " + Environment.NewLine + Environment.NewLine +
                "Du hast keine Verluste verzeichnet! ";
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
