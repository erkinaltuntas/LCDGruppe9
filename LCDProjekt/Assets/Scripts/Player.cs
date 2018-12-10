/*************************************************************************** 
* Player
* Anwendung: Erstellen des Spielers mit seinen Eigenschaften
* ------------------- 
* Zuletzt bearbeitet von: Erkin Altuntas
* Datum der letzten Bearbeitung: 10.12.2018
* Grund für letzte Bearbeitung: Kommentare/Code Pflege
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

    void Awake()
    {
        player = this;
        // Der Spieler wird in die naechste Szene uebertragen
        DontDestroyOnLoad(transform.gameObject);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
