/*************************************************************************** 
* DisplayDescription
* Anwendung: Zur Anzeige des PopUp Fensters mit den Details der Pflanzen
*------------------- 
* Zuletzt bearbeitet von: Erkin Altuntas
* Datum der letzten Bearbeitung: 7.1.2019
* Grund für letzte Bearbeitung: Pflanzennamen auf deutsch anzeigen lassen
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
        if(plant.plantName == "Empty")
        {
            descriptionString = "Name: leeres Feld " + Environment.NewLine+ Environment.NewLine +"Bringt keinen Ertrag";
        }
        else
        {
            if (plant.plantName == "Tomato")
            {
                descriptionString = "Name: Tomate";
            }
            else if (plant.plantName == "Carrot")
            {
                descriptionString = "Name: Karotte";
            }
            else if (plant.plantName == "Corn")
            {
                descriptionString = "Name: Mais";
            }
            else if (plant.plantName == "Potato")
            {
                descriptionString = "Name: Kartoffel";
            }
            descriptionString += Environment.NewLine + Environment.NewLine +
                    "Preis: " + plant.price +" Farm$" + Environment.NewLine +
                    "Maximal möglicher Profit: " + plant.profit+" Farm$" + Environment.NewLine +
                    "Dürreresistenz: " + plant.droughtResistance * 100 + "%" + Environment.NewLine +
                    "Frostresistenz: " + plant.frostResistance * 100 + "%" + Environment.NewLine;
        }

    

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
