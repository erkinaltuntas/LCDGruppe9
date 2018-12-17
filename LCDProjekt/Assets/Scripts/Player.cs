/*************************************************************************** 
* Player
* Anwendung: Erstellen des Spielers mit seinen Eigenschaften
* ------------------- 
* Zuletzt bearbeitet von: Erkin Altuntas
* Datum der letzten Bearbeitung: 11.12.2018
* Grund für letzte Bearbeitung: Gewinne/Verluste mittels Arrays
* dokumentieren
**************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public static Player player;
    public int id;
    public string playerName;
    // Das Geld kann manuell im Inspektor angepasst werden
    public double money;
    public int riskScore;
    public int season;
    public double[] droughtLost;
    public double[] frostLost;
    public int droughtIndex;
    public int frostIndex;
    public bool storm = false;


    void Awake()
    {
        player = this;
        // Der Spieler wird in die naechste Szene uebertragen
        DontDestroyOnLoad(transform.gameObject);
    }

    // Use this for initialization
    void Start () {
        droughtLost = new double[16];
        frostLost = new double[16];
        droughtIndex = 0;
        frostIndex = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
