/*************************************************************************** 
* Player
* Anwendung: Erstellen des Spielers mit seinen Eigenschaften
* ------------------- 
* Zuletzt bearbeitet von: Victor Xu
* Datum der letzten Bearbeitung: 20.12.2018
* Grund für letzte Bearbeitung: Anzahl der Kredite wird gezählt
**************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;


public class Player : MonoBehaviour {
    
    public static Player player;
    public int id;
    public string playerName;
    public int season;

    // Das Geld kann manuell im Inspektor angepasst werde
    public double money;

    //Risikobewertung
    public double[] riskScores;
    public double[] riskScoreShock;
    public double riskMean = 0;
    public string riskClass;
    

    //für die Endstatistik
    public double[] droughtLost;
    public double[] frostLost;
    public int droughtIndex, frostIndex, riskIndex;
    public double endTotal;

    //für Schocks
    public bool storm = false;
    public int choice;

    //für Kredit
    public int timeLoan = 0;
    public bool creditShown;

    //für die Bestätigung der Risikoklasse am Ende
    public bool riskConfirmed;

    void Awake()
    {
        player = this;
        // Der Spieler wird in die naechste Szene uebertragen
        DontDestroyOnLoad(transform.gameObject);
        
    }

    // Use this for initialization
    void Start()
    {
        droughtLost = new double[16];
        frostLost = new double[16];
        riskScores = new double[16];
        
        riskScoreShock = new double[2];

        //riskIndex = 0;
        droughtIndex = 0;
        frostIndex = 0;

        creditShown = false;

        playerName = PlayerPrefs.GetString("PlayerName");
    }

    // Update is called once per frame
    void Update () {
		
	}

    // Berechnet Risiko auf Basis der Wahl der Pflanze und des aktuellen Wetters
    public double calculateRiskPlant(Plant plant, Weather weather)
    {
        double frostPdroughtP = weather.frostProb + weather.droughtProb;

        return ((weather.frostProb / frostPdroughtP) * Math.Pow((1 - plant.frostResistance + weather.frostProb), 1.905)
                + (weather.droughtProb / frostPdroughtP) * Math.Pow((1 - plant.droughtResistance + weather.droughtProb), 1.905));
    }


    // Berechnet das Risiko des Spielers
    public void calculateRisk()
    {
        double riskSum = 0;
        int counter = 0;
        for(int i = 0; i < riskScores.Length; i++)
        {
            if (riskScores[i]>0)
            {
                riskSum += riskScores[i];
                counter++;
            }
        }

        if (counter > 0)
        {
            riskMean = (riskSum / counter);
        }
    }


    // Ermittelt die Risikoklasse des Spielers
    public void getRiskClass()
    {
        double riskShock = player.riskScoreShock[0] + player.riskScoreShock[1];
        riskMean += riskShock; 

        if (riskMean < 0.7d)
        {
            riskClass = "Sicherheit";
        }
        else if (0.7d <= riskMean && riskMean < 0.9d)
        {
            riskClass = "Ertrag";
        }
        else if (0.9d <= riskMean && riskMean < 1.1d)
        {
            riskClass = "Wachstum";
        }
        else if (1.1d <= riskMean && riskMean < 1.3d)
        {
            riskClass = "Risiko";
        }
        else if (1.3d <= riskMean)
        {
            riskClass = "Spekulativ";
        }
    }
   


    // Sendet das Ergebnis des Spielers an die Datenbank (über MongoConnect)
    public void sendResult()
    {
        GameObject mongo = GameObject.Find("DatabaseConnector");

        // der Datensatz, der abgesendet wird
        BsonDocument[] batch ={
            new BsonDocument{
                {"name", playerName},
                {"result", endTotal},
                {"riskMean", riskMean},
                {"riskName", riskClass},
                {"confirmation", riskConfirmed }
            }
        };

        mongo.GetComponent<MongoConnect>().insertResult(batch);
    }
}
