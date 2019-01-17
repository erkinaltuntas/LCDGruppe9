/*************************************************************************** 
* Harvest
* Anwendung: Zum Ernten der Felder sowie Bilanzierung
*------------------- 
* Zuletzt bearbeitet von: Thomas Wieschermann
* Datum der letzten Bearbeitung: 17.01.2019
* Grund für letzte Bearbeitung: Kommentare
**************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Zum Ernten der einzelnen Felder sowie Bilanzierung.
/// Es wird sowohl die Berechnung des Ertrags der einzelnen Felder ausgeführt als auch die visuelle Darstellung
/// der Ernte der Felder.
/// </summary>
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


    /// <summary>
    /// Überprüft für <c>Harvest.cs</c> ob sich das Spiel im Moment im Tutorial oder im eigentlichen
    /// Spielablauf befindet. Außerdem wird die Methode <c>TaskOnClick</c> ausgeführt, wenn der <c>harvestFieldButton</c>
    /// gedrückt wird. 
    /// </summary>
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
        
        plant = field.GetComponent<Field>().plant;

        missHarvestQuota = 1;
        field.changeSprite();
        
        harvestFieldButton.onClick.AddListener(TaskOnClick);
    }
	
    /// <summary>
    /// Führt sowohl die visuelle Änderung des Feldes als auch die eigentliche Ertragsberechnung für die einzelnen
    /// Felder aus. Eine genauere Beschreibung der einzelnen Komponenten erfolgt innerhalb der Methode.
    /// </summary>
    void TaskOnClick()
    {
        // Feld Sprite entfernen
        field.GetComponent<SpriteRenderer>().sprite = empty;
        field.fieldIsHarvested = true;

        // Berechnet den Umsatz und aktualisiert die Geldmenge des Spielers.
        // Hierzu wird unter anderem die Methode getRandomProfit aufgerufen.
        double actualProfit = Math.Round(getRandomProfit(), 2);
        double loss = actualProfit - plant.profit;
        cash.money = cash.money + actualProfit;

        // Zeigt die Bilanz für jedes einzelne Feld an. Sollte die Pflanze von Frost oder Duerre betroffen sein,
        // wird balanceMessage.text weiter unten im Code durch eine andere Nachricht ersetzt
        balancePanel.SetActive(true);
        // für TextMeshPro lässt sich auch folgendes einbinden
        // balanceMessage.text = "<b><color=#00FF42>Gewinn: </color=#00FF42></b>" + actualProfit + " <b>Farm$</b>" + Environment.NewLine + Environment.NewLine;
        balanceMessage.text = "Gewinn: " + actualProfit + " Farm $" + Environment.NewLine + Environment.NewLine;

        // Überprüfung ob keine Pflanze auf dem Feld angebaut wurde und sukzessive Ausgabe der Bilanz der einzelnen Felder
        // mit Verlusten durch Frost bzw. Duerre
        if (plant.name != "Empty")
        {
            if (plant.frosted)
            {

                balanceMessage.text += "Anteil verdorbene" + Environment.NewLine + "Ernte: " + missHarvestQuota * 100 + "%" + Environment.NewLine + Environment.NewLine +
                    "Entgangener Gewinn" + Environment.NewLine + "wegen Frost: " + loss * (-1) + " Farm $";
                // Zuweisung der Verlustwerte in das PlayerArray. Diese werden am Ende des Spiels ausgelesen um dem Spieler mitzuteilen wieviel er 
                // durch Frost verloren hat.
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
                // Zuweisung der Verlustwerte in das PlayerArray. Diese werden am Ende des Spiels ausgelesen um dem Spieler mitzuteilen wieviel er 
                // durch Duerre verloren hat.
                if (!tutorial)
                {
                    player.droughtLost[player.droughtIndex] = loss;
                    player.droughtIndex++;
                }
            }

        }

        

    }


    /// <summary>
    /// Berechnet den Ertrag eines Feldes unter der Vorraussetzung, dass es von Frost oder Dürre betroffen ist.
    /// Hierzu werden zunächst zwei Zufallswerte berechnet. <c>random3</c> bestimmt in welcher Höhe das Feld vom
    /// Verlust betroffen ist, 25%, 50% oder 75%.
    /// <c>random5</c> bestimmt ob, falls die Pflanze sowohl von Frost als auch von Duerre betroffen ist, von welchem der beiden sie
    /// betroffen ist, da eine Pflanze im Spiel immer nur von Duerre oder von Frost befallen sein kann.
    /// Zusätzlich wird das Schockevent im Herbst beachtet, das, je nach der Wahl des Spielers, 
    /// seine Pflanzen vor Wetterereignissen schützt oder die Erträge alle seiner Pflanzen um 25 % steigert.
    /// Math.round gibt dabei gerundete Ergebnisse zurück um einen visuell ansprechenderen Kontostand dem Spieler
    /// wiedergeben zu können.
    /// </summary>
    /// <returns>Gibt ein Double mit maximal 2 Nachkommastellen zurück, das den Ertrag für einzelne Felder beschreibt. </returns>
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
            //Positives Schockevent im Herbst
            if (seasonName == "Herbst" && player.choice == 1)
            {
                return Math.Round((plant.profit * 1.25) - ((plant.profit * 1.25) * missHarvestQuota), 2);
            }
            else if (seasonName == "Herbst" && player.choice == 2)
            {
                plant.droughted = false;
                plant.frosted = false;
                return Math.Round(plant.profit,2);
            }
            else
            {
                return Math.Round(plant.profit - (plant.profit * missHarvestQuota), 2);
            }
        }
        else
        {
            if (seasonName == "Herbst" && player.choice == 1)
            {
                return Math.Round(plant.profit * 1.25, 2);

            }
            else if (seasonName == "Herbst" && player.choice == 2)
            {
                plant.droughted = false;
                plant.frosted = false;
                return Math.Round(plant.profit ,2);
            }
            else
            {
                return Math.Round(plant.profit ,2);
            }
        }

        
    }
}
