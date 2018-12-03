using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayDescription : MonoBehaviour {
    public string descriptionString;
   
    public TextMeshProUGUI descriptionText;

    public float fadeTime;
    public bool displayInfo;
    public Plant plant;

    public Image descriptionImage;


	// Use this for initialization
	void Start () {
        //Identifiziere die Pflanze, um die es sich handelt mit ihren Beschreibungsobjekten
        plant = this.gameObject.GetComponent<Plant>();
        descriptionImage = plant.GetComponentInChildren<Image>();
        descriptionText = descriptionImage.GetComponentInChildren<TextMeshProUGUI>();


        //Beschreibungstext
        descriptionString = "Name: " + plant.plantName + Environment.NewLine +
                            "Preis: " + plant.price + Environment.NewLine +
                            "Profit: " + plant.profit + Environment.NewLine +
                            "Duerreresistenz: " + plant.droughtResistance + Environment.NewLine +
                            "Frostresistenz: " + plant.frostResistance + Environment.NewLine +
                            "Bedarf an Wasser: " + plant.needForRain + Environment.NewLine +
                            "Bedarf an Sonne: " + plant.needForSun;

        //Objekte, in welches die Beschreibung überführt wird am Anfang nicht sichtbar
        descriptionImage.color = Color.clear;
        descriptionText.color = Color.clear;
	}
	
	// Update is called once per frame
	void Update () {
        FadeText();
	}


    //wenn Maus über den Collider der Pflanze geht
    void OnMouseOver()
    {
        displayInfo = true;
    }


    //wenn Maus den Collider der Pflanze verlässt
    void OnMouseExit()
    {
        displayInfo = false;
    }



    void FadeText()
    {

        //wenn Maus auf Collider, dann zeige den Text, indem Farbe sichtbar wird, sonst zeige Farbe nicht
        if (displayInfo)
        {
            descriptionText.text = descriptionString;
            descriptionText.color = Color.Lerp(descriptionText.color, Color.white, fadeTime * Time.deltaTime);
            descriptionImage.color = Color.Lerp(descriptionImage.color, Color.white, fadeTime * Time.deltaTime);

        }
        else
        {
            descriptionImage.color = Color.Lerp(descriptionImage.color, Color.clear, fadeTime * Time.deltaTime);
            descriptionText.color = Color.Lerp(descriptionText.color, Color.clear, fadeTime * Time.deltaTime);
        }
    }
}
