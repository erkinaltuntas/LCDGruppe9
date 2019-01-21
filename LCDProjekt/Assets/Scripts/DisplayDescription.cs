/*************************************************************************** 
* DisplayDescription
* Anwendung: Zur Anzeige des PopUp Fensters mit den Details der Pflanzen
*------------------- 
* Zuletzt bearbeitet von: Cedric Meyer-Piening
* Datum der letzten Bearbeitung: 21.01.2019
* Grund für letzte Bearbeitung: Kommentare
**************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Zeigt die Details zu den Pflanzen an, wenn man mit der Maus darueber geht.
/// </summary>
public class DisplayDescription : MonoBehaviour {
    // Text, in welches der Beschreibungstext eingefuegt wird (manuell zuweisen)
    public string descriptionString;
    // Textobjekte, in welches der Beschreibungstext eingefuegt wird (manuell zuweisen)
    public Text descriptionText;
    // Das PopUp, in welches das Textobjekte eingefuegt wird (manuell zuweisen)
    public Image descriptionImage;
    public Text errorMessage;
    public float fadeTime;
    public bool displayInfo;
    public Plant plant;

    /// <summary>
    /// Bestimmt, welche Beschreibung angezeigt wird.
    /// </summary>
    void Start() {
        // Identifiziere die Pflanze, um die es sich handelt mit ihren Beschreibungseigenschaften
        plant = this.gameObject.GetComponent<Plant>();
        descriptionImage = plant.GetComponentInChildren<Image>();
        descriptionText = descriptionImage.GetComponentInChildren<Text>();

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
                    "Preis: " + plant.price +" Farm $" + Environment.NewLine +
                    "Maximal möglicher Profit: " + plant.profit+" Farm $" + Environment.NewLine +
                    "Dürreresistenz: " + plant.droughtResistance * 100 + "%" + Environment.NewLine +
                    "Frostresistenz: " + plant.frostResistance * 100 + "%" + Environment.NewLine;
        }

    

        //PopUp ist zu Beginn unsichtbar
        descriptionImage.color = Color.clear;
        descriptionText.color = Color.clear;
	}
	
	/// <summary>
    /// Prueft, ob die Beschreibung angezeigt wird oder nicht.
    /// </summary>
	void Update () {
        FadeText();
	}

    /// <summary>
    /// Die Methode wird aufgerufen, wenn die Maus ueber den Collider einer Pflanze geht
    /// </summary>
    void OnMouseOver()
    {
        displayInfo = true;
    }

    /// <summary>
    /// Die Methode wird aufgerufen, wenn die Maus den Collider einer Pflanze verlaesst.
    /// </summary>
    void OnMouseExit()
    {
        displayInfo = false;
        errorMessage.text = "";
    }

    /// <summary>
    ///  Steuert die Anzeige des PopUps.
    /// </summary>
    void FadeText()
    {
        // Wenn Maus auf Collider, dann zeige das PopUp, indem das Bild und der Text sichtbar wird
        if (displayInfo)
        {
            
            descriptionText.text = descriptionString;
            descriptionText.color = Color.Lerp(descriptionText.color, Color.white, fadeTime * Time.deltaTime);
            descriptionImage.color = Color.Lerp(descriptionImage.color, Color.clear, fadeTime * Time.deltaTime);

        }
        else
        {
            
            descriptionImage.color = Color.Lerp(descriptionImage.color, Color.clear, fadeTime * Time.deltaTime);
            descriptionText.color = Color.Lerp(descriptionText.color, Color.clear, fadeTime * Time.deltaTime);
        }
    }
}
