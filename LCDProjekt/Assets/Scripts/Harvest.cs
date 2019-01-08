/*************************************************************************** 
* Harvest
* Anwendung: Zum Ernten der Felder sowie Bilanzierung
*------------------- 
* Zuletzt bearbeitet von: Thomas Wieschermann
* Datum der letzten Bearbeitung: 20.12.2018
* Grund für letzte Bearbeitung: Wetteranpassung
**************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Harvest : MonoBehaviour {

    Player player;
    TutorialPlayer tutorialPlayer;
    public Field field;
    public Plant plant;
    public Button harvestFieldButton;
    public Sprite empty;
    public Money cash;
    double missHarvestQuota;
    public GameObject balancePanel;
    public Text balanceMessage;
    public GameObject weather;
    string seasonName;
    bool tutorial;


    // Use this for initialization
    void Start () {
        
        weather = GameObject.Find("Weather");
        if (weather.GetComponent<Weather>().seasonNumber != 0)
        {
            player = Player.player;
            tutorial = false;
        }
        else
        {
            tutorialPlayer = TutorialPlayer.tutorialPlayer;
            tutorial = true;
        }

        seasonName = weather.GetComponent<Weather>().seasonName;

        // Die Methode TaskOnClick wird ausgeführt, wenn der harvestFieldButton gedrückt wird
        
        plant = field.GetComponent<Field>().plant;

        missHarvestQuota = 1;
        field.changeSprite();
        
        harvestFieldButton.onClick.AddListener(TaskOnClick);
    }
	

    void TaskOnClick()
    {
        //Feld Sprite entfernen
        field.GetComponent<SpriteRenderer>().sprite = empty;
        field.fieldIsHarvested = true;

        // Berechne den Umsatz und aktualisere das Geld des Spielers
        double actualProfit = getRandomProfit();
        double loss = actualProfit - plant.profit;
        cash.money = cash.money + actualProfit;

        // Zeige die Bilanz fuer jedes Feld an
        balancePanel.SetActive(true);
        // für TextMeshPro
        //balanceMessage.text = "<b><color=#00FF42>Gewinn: </color=#00FF42></b>" + actualProfit + " <b>Farm$</b>" + Environment.NewLine + Environment.NewLine;
        balanceMessage.text = "Gewinn: " + actualProfit + " Farm $" + Environment.NewLine + Environment.NewLine;

        if (plant.name != "Empty")
        {
            if (plant.frosted)
            {

                balanceMessage.text += "Anteil verdorbene" + Environment.NewLine + "Ernte: " + missHarvestQuota * 100 + "%" + Environment.NewLine + Environment.NewLine +
                    "Entgangener Gewinn" + Environment.NewLine + "wegen Frost: " + loss * (-1) + " Farm $";
                // Zuweisung der Verlustwerte in das PlayerArray
                if (!tutorial)
                {
                    player.frostLost[player.frostIndex] = loss;
                    player.frostIndex++;
                }

            }
            else if (plant.droughted)
            {
                balanceMessage.text += "Anteil verdorbene" + Environment.NewLine + "Ernte: " + missHarvestQuota * 100 + "%" + Environment.NewLine + Environment.NewLine +
                   "Entgangener Gewinn" + Environment.NewLine + "wegen Dürre: " + loss * (-1) + " Farm $";
                // Zuweisung der Verlustwerte in das PlayerArray
                if (!tutorial)
                {
                    player.droughtLost[player.droughtIndex] = loss;
                    player.droughtIndex++;
                }
            }

        }

        

    }


    // Berechnet den Profit eines Feldes
    double getRandomProfit()
    {
        int random3 = UnityEngine.Random.Range(0, 3);
        int random5 = UnityEngine.Random.Range(0, 2);
        if (random3 == 0)
        {
            missHarvestQuota = 0.25;
        }
        else if(random3 == 1)
        {
            missHarvestQuota = 0.5;
        }
        else if(random3 == 2)
        {
            missHarvestQuota = 0.75;
        }

        // Falls Pflanze sowohl von Frost als auch von Dürre betroffen, wähle ein zufälliges davon
        if (plant.droughted && plant.frosted)
        {
            if (random5 == 0)
            {
                plant.droughted = false;
            }
            else if (random5 == 1)
            {
                plant.frosted = false;
            }
        }

        if (plant.droughted || plant.frosted)
        {
            if (seasonName == "Herbst" && player.choice == 1)
            {
                return (plant.profit * 1.25) - ((plant.profit * 1.25) * missHarvestQuota);
            }
            else if (seasonName == "Herbst" && player.choice == 2)
            {
                plant.droughted = false;
                plant.frosted = false;
                return plant.profit;
            }
            else
            {
                return plant.profit - (plant.profit * missHarvestQuota);
            }
        }
        else
        {
            if (seasonName == "Herbst" && player.choice == 1)
            {
                return plant.profit * 1.25;
            }
            else if (seasonName == "Herbst" && player.choice == 2)
            {
                plant.droughted = false;
                plant.frosted = false;
                return plant.profit;
            }
            else
            {
                return plant.profit;
            }
        }

        
    }
}
