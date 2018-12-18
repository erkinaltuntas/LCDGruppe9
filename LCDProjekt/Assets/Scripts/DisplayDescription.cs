﻿/*************************************************************************** 
* DisplayDescription
* Anwendung: Zur Anzeige des PopUp Fensters mit den Details der Pflanzen
*------------------- 
* Zuletzt bearbeitet von: Erkin Altuntas
* Datum der letzten Bearbeitung: 10.12.2018
* Grund für letzte Bearbeitung: Kommentare/Code Pflege
**************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayDescription : MonoBehaviour {
    // Text, in welches der Beschreibungstext eingefuegt wird (manuell zuweisen)
    public string descriptionString;
    // Textobjekte, in welches der Beschreibungstext eingefuegt wird (manuell zuweisen)
    public TextMeshProUGUI descriptionText;
    // Das PopUp, in welches das Textobjekte eingefuegt wird (manuell zuweisen)
    public Image descriptionImage;

    public float fadeTime;
    public bool displayInfo;
    public Plant plant;



    // Use this for initialization
    void Start() {
        // Identifiziere die Pflanze, um die es sich handelt mit ihren Beschreibungseigenschaften
        plant = this.gameObject.GetComponent<Plant>();
        descriptionImage = plant.GetComponentInChildren<Image>();
        descriptionText = descriptionImage.GetComponentInChildren<TextMeshProUGUI>();


        // Beschreibungstext im PopUp
        descriptionString = "Name: " + plant.plantName + Environment.NewLine +
                            "Preis: " + plant.price + Environment.NewLine +
                            "Profit: " + plant.profit + Environment.NewLine +
                            "Duerreresistenz: " + plant.droughtResistance + Environment.NewLine +
                            "Frostresistenz: " + plant.frostResistance + Environment.NewLine;
    

        //PopUp ist zu Beginn unsichtbar
        descriptionImage.color = Color.clear;
        descriptionText.color = Color.clear;
	}
	
	// Update is called once per frame
	void Update () {
        FadeText();
	}


    // Die Methode wird aufgerufen, wenn die Maus ueber den Collider einer Pflanze geht
    void OnMouseOver()
    {
        displayInfo = true;
    }


    // Die Methode wird aufgerufen, wenn die Maus den Collider einer Pflanze verlaesst
    void OnMouseExit()
    {
        displayInfo = false;
    }

    // Steuert die Anzeige des PopUps
    void FadeText()
    {

        // Wenn Maus auf Collider, dann zeige das PopUp, indem das Bild und der Text sichtbar wird
        if (displayInfo)
        {
            descriptionText.text = descriptionString;
            descriptionText.color = Color.Lerp(descriptionText.color, Color.black, fadeTime * Time.deltaTime);
            descriptionImage.color = Color.Lerp(descriptionImage.color, Color.white, fadeTime * Time.deltaTime);

        }
        else
        {
            descriptionImage.color = Color.Lerp(descriptionImage.color, Color.clear, fadeTime * Time.deltaTime);
            descriptionText.color = Color.Lerp(descriptionText.color, Color.clear, fadeTime * Time.deltaTime);
        }
    }
}
