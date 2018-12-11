/*************************************************************************** 
* Harvest
* Anwendung: Zum Ernten der Felder sowie Bilanzierung
*------------------- 
* Zuletzt bearbeitet von: Erkin Altuntas
* Datum der letzten Bearbeitung: 11.12.2018
* Grund für letzte Bearbeitung: Bei Frost/Dürre dem Player Array die Werte
* zuweisen
**************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Harvest : MonoBehaviour {

    Player player;
    public Field field;
    public Plant plant;
    public Button harvestFieldButton;
    public Sprite empty;
    public Money cash;
    double missHarvestQuota;
    public GameObject balancePanel, shockPanel;
    public TextMeshProUGUI balanceMessage;


    // Use this for initialization
    void Start () {
        player = Player.player;
        //Shockevents
        if (player.season == 2 || player.season == 3)
        {
            shockPanel.SetActive(true);
        }
        // Die Methode TaskOnClick wird ausgeführt, wenn der harvestFieldButton gedrückt wird
        harvestFieldButton.onClick.AddListener(TaskOnClick);
        plant = field.GetComponent<Field>().plant;
        missHarvestQuota = 1;
        field.changeSprite();

        
    }
	

    void TaskOnClick()
    {
        // Berechne den Umsatz und aktualisere das Geld des Spielers
        double actualProfit = getRandomProfit();
        double loss = actualProfit - plant.profit;
        cash.money = cash.money + actualProfit;

        //Feld Sprite entfernen
        field.GetComponent<SpriteRenderer>().sprite = empty;
        field.fieldIsHarvested = true;

        // Zeige die Bilanz fuer jedes Feld an
        balancePanel.SetActive(true);
        balanceMessage.text = "<b><color=#00FF42>Gewinn: </color=#00FF42></b>" +actualProfit + " <b>Farm$</b>" + Environment.NewLine + Environment.NewLine;

        if (plant.name != "Empty")
        {
            if (plant.frosted)
            {

                balanceMessage.text += "Anteil verdorbene" + Environment.NewLine + "Ernte: " + missHarvestQuota * 100 + "%" + Environment.NewLine + Environment.NewLine +
                    "Entgangener Gewinn" + Environment.NewLine + "wegen Frost: " + loss * (-1) + " Farm$";
                // Zuweisung der Verlustwerte in das PlayerArray
                player.frostLost[player.frostIndex] = loss;
                player.frostIndex++;

            }
            else if (plant.droughted)
            {
                balanceMessage.text += "Anteil verdorbene" + Environment.NewLine + "Ernte: " + missHarvestQuota * 100 + "%" + Environment.NewLine + Environment.NewLine +
                    "Entgangener Gewinn" + Environment.NewLine + "wegen Dürre: " + loss * (-1) + " Farm$";
                // Zuweisung der Verlustwerte in das PlayerArray
                player.droughtLost[player.droughtIndex] = loss;
                player.droughtIndex++;
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
            if(random5 == 0)
            {
                plant.droughted = false;
            }
            else if (random5 == 1)
            {
                plant.frosted = false;
            }
            Debug.Log("von Dürre betroffen:" + plant.droughted + "von Frost betroffen:" + plant.frosted);
            return plant.profit - (plant.profit * missHarvestQuota);
        }
        else if(plant.droughted || plant.frosted)
        {
            Debug.Log("von Dürre betroffen:" + plant.droughted + "von Frost betroffen:" + plant.frosted);
            return plant.profit - (plant.profit * missHarvestQuota);
        }

        Debug.Log("von Dürre betroffen:" + plant.droughted + "von Frost betroffen:" + plant.frosted);
        return plant.profit;
    }
}
