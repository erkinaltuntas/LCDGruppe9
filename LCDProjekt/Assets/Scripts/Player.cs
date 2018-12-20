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

public class Player : MonoBehaviour {
    
    public static Player player;
    public int id;
    public string playerName;
    // Das Geld kann manuell im Inspektor angepasst werde
    public double money;
    public double[] riskScores;
    public double[] riskScoreShock;
    public double risk;
    public int season;
    public double[] droughtLost;
    public double[] frostLost;
    public int droughtIndex, frostIndex, riskIndex;
    public bool storm = false;
    public int choice;
    public int timeLoan = 0;

    public bool creditShown;

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
    }

    // Update is called once per frame
    void Update () {
		
	}

    // Berechnet Risiko auf Basis der Wahl der Pflanze und des aktuellen Wetters
    public double calculateRiskPlant(Plant plant, Weather weather)
    {
        double frostPdroughtP = weather.frostProb + weather.droughtProb;

        return ((weather.frostProb / frostPdroughtP) * Math.Pow((1 - plant.frostResistance + weather.frostProb), 1.311)
                + (weather.droughtProb / frostPdroughtP) * Math.Pow((1 - plant.droughtResistance + weather.droughtProb), 1.311));
    }

    public double calculateRisk()
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
        double riskMedian = 0;
        if (counter > 0)
        {
            riskMedian = (riskSum / counter);
        }
        
        return riskMedian;
    }
}
