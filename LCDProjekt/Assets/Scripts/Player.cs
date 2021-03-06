﻿/*************************************************************************** 
* Player
* Anwendung: Erstellen des Spielers mit seinen Eigenschaften
* ------------------- 
* Zuletzt bearbeitet von: Thomas Wieschermann
* Datum der letzten Bearbeitung: 21.01.2019
* Grund fuer letzte Bearbeitung: Risikoklassen geaendert und Kommentare eingefuegt
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

/// <summary>
/// Ermoeglicht die Risikoklassifizierung des Spielers in 5 verschiedene Risikoklassen.
/// Ausserdem werden Verluste durch Duerre und Frost gesammelt und 
/// die Ergebnisse des Spielers an eine Datenbank geschickt. Eine
/// genauere Kommentierung erfolgt innerhalb der Klasse selbst.
/// </summary>
public class Player : MonoBehaviour {
    
    public static Player player;
    public int id;
    public string playerName;
    public int season;

    // Das Geld kann manuell im Inspektor angepasst werden
    public double money;

    // Arrays und Variablen zur Risikobewertung
    public double[] riskScores;
    public double[] riskScoreShock;
    public double riskMean = 0;
    public string riskClass;
    

    //Verluste durch Frost und Duerre fuer die Endstatistik
    public double[] droughtLost;
    public double[] frostLost;
    public int droughtIndex, frostIndex, riskIndex;
    public double endTotal;

    //fuer Schocks
    public bool storm = false;
    public int choice;

    //fuer Kredit
    public int timeLoan = 0;
    public bool creditShown;

    //fuer die Bestaetigung der Risikoklasse am Ende
    public bool riskConfirmed;

    /// <summary>
    /// Der Spieler wird in die naechste Szene uebertragen.
    /// </summary>
    void Awake()
    {
        player = this;
        DontDestroyOnLoad(transform.gameObject);
        
    }

    /// <summary>
    /// Anlage von Arrays sowohl fuer Verluste als auch die 
    /// Risikobewertung der Pflanzenwahl des Spielers.
    /// </summary>
    void Start()
    {
        droughtLost = new double[16];
        frostLost = new double[16];
        riskScores = new double[16];
        
        riskScoreShock = new double[2];

        droughtIndex = 0;
        frostIndex = 0;

        creditShown = false;

        playerName = PlayerPrefs.GetString("PlayerName");
    }

    // Update is called once per frame
    void Update () {
		
	}

    /// <summary>
    /// Berechnet Risiko auf Basis der Pflanzenwahl und des aktuellen Wetters.
    /// Je hoeher die Abweichung der Duerre- und Frostresistenzwerte der ausgewaehlten Pflanzen von den
    /// Frost- und Duerrewerten des Wetters desto extremer der errechnete Risikowert.
    /// Dabei werden Frost- und Duerrewahrscheinlichkeit gegeneinander gewichtet und mit in die
    /// Bewertung einbezogen, d.h. sollte zum Beispiel der Frostwert einer Jahreszeit 60 % und
    /// der Duerrewert 20 % betragen, so ist die Reaktion auf den Frostwert drei mal so 
    /// wichtig wie die Reaktion auf den Duerrewert. Der Potenzwert 1,905  
    /// ermoeglicht fuer die gegebene Pflanzenauswahl einen Risikodurchschnittswert von nahezu = 1 und
    /// bewertet zusaetzlich Entscheidungen, die zu einer hohen Diskrepanz zwischen 
    /// Resistenz und Wetterwahrscheinlichkeit fuehren ueberdurchschnittlich.
    /// </summary>
    /// <param name="plant">Uebergebenes Pflanzenobjekt</param>
    /// <param name="weather">Uebergebenes Wetterobjekt</param>
    /// <returns></returns>
    public double calculateRiskPlant(Plant plant, Weather weather)
    {
        double frostPdroughtP = weather.frostProb + weather.droughtProb;

        return ((weather.frostProb / frostPdroughtP) * Math.Pow((1 - plant.frostResistance + weather.frostProb), 1.905)
                + (weather.droughtProb / frostPdroughtP) * Math.Pow((1 - plant.droughtResistance + weather.droughtProb), 1.905));
    }


    /// <summary>
    /// Berechnet den Durchschnitt aller Risikoentscheidungen des Spielers (ausschliesslich Pflanzenwahl)
    /// </summary>
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


    /// <summary>
    /// Teilt den Spieler in eine von fuenf verschiedenen Risikoklassen ein,
    /// nachdem die Entscheidungen bei den Schockereignissen beruecksichtigt
    /// werden. Einteilung erfolgt ueber die Normierung auf 5 gleiche Abschnitte 
    /// zwischen dem minimal moeglichen Wert 0,297 und dem maximal moeglichen Wert 1,59.
    /// Die Werte wurden aus Risiko_Konzept_GanzjahresPflanzenFINAL.xls uebernommen.
    /// </summary>
    public void getRiskClass()
    {
        double riskShock = player.riskScoreShock[0] + player.riskScoreShock[1];
        riskMean += riskShock; 

        if (riskMean < 0.555d)
        {
            riskClass = "Sicherheit";
        }
        else if (0.555d <= riskMean && riskMean < 0.8142d)
        {
            riskClass = "Ertrag";
        }
        else if (0.8142d <= riskMean && riskMean < 1.0728d)
        {
            riskClass = "Wachstum";
        }
        else if (1.0728d <= riskMean && riskMean < 1.3314d)
        {
            riskClass = "Risiko";
        }
        else if (1.3314d <= riskMean)
        {
            riskClass = "Spekulativ";
        }
    }



    /// <summary>
    /// Sendet das Ergebnis des Spielers an die Datenbank (ueber MongoConnect).
    /// Uebergeben werden dabei Name, Endkontostand, Risikoscore, Risikoklasse
    /// und ob der Spieler mit der Risikobewertung einverstanden war.
    /// </summary>    
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
