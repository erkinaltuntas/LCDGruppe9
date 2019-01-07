/*************************************************************************** 
* Highscore
* Anwendung: Anzeigen der Platzierung
* ------------------- 
* Zuletzt bearbeitet von: Anna Buchner
* Datum der letzten Bearbeitung: 07.01.2019
* Grund für letzte Bearbeitung: Platzierung auswerten
**************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;


public class Highscore : MonoBehaviour {

    public Player player;
    public MongoConnect mongo;
    List<BsonDocument> batchList = new List<BsonDocument>();
    string place = "1";

    // Use this for initialization
    void Start () {
        player = Player.player;
        batchList = mongo.findResults();

        getHighscore();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void getHighscore()
    {
        //Die Platzierung des Spielers nach seinem Endguthaben finden
        foreach (var document in batchList)
        {
            if (document["result"] == player.endTotal)
            {
                place = document["place"].ToString();
                print("found player");
            }
        }
        //Platzierung ausgeben
        print("Du hast Platz " + place + " von " + mongo.numberOfPlayers + " Spielern erreicht.");
    }
}
