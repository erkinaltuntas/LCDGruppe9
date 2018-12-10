﻿/*************************************************************************** 
* DialogController5
* Anwendung: Zur Steuerung des Dialogs in der Abschlussstory
* (erste Sprechblase)
* ------------------- 
* Zuletzt bearbeitet von: Erkin Altuntas
* Datum der letzten Bearbeitung: 10.12.2018
* Grund für letzte Bearbeitung: Erstellung des Skripts
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
        double money = player.money;
        double win = player.money - 1000;


        fullText1 = "Wir sind zurück mein Kind!" + Environment.NewLine + Environment.NewLine + "Du hast insgesamt jetzt " +money+ " Farm Dollar."
            + Environment.NewLine + Environment.NewLine + " Du hast also "+win+" Farm Dollar erwirtschaftet.";

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
