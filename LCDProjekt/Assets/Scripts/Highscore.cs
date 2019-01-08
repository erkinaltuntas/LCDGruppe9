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
using UnityEngine.UI;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;


public class Highscore : MonoBehaviour {

    public Player player;
    public MongoConnect mongo;
    public Text firstPlace;
    public Text overPlayerPlace;
    public Text playerPlace;
    public Text underPlayerPlace;
    public Text lastPlace;
    string fLine;
    string oPLine;
    string pLine;
    string uPLine;
    string lLine;
    bool firstFound;
    bool oPFound;
    bool pFound;
    bool uPFound;


    List<BsonDocument> batchList = new List<BsonDocument>();
    string place = "1";

    // Use this for initialization
    void Start () {
        player = Player.player;
        batchList = mongo.findResults();

        firstFound = false;
        oPFound = false;
        uPFound = false;
        pFound = false;


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
            if (!(firstFound && pFound && oPFound && uPFound)) { 
                if (!firstFound)
                {

                    fLine = document["place"].ToString() + ". " + document["result"].ToString() + " Farm$";

                    firstFound = true;
                }

                if (pFound)
                {
                    uPLine = document["place"].ToString() + ". " + document["result"].ToString() + " Farm$";
                    uPFound = true;
                }

                if (document["result"] == player.endTotal)
                {
                    oPFound = true;
                    pFound = true;
                    place = document["place"].ToString();
                    print("found player");

                    pLine = place + ". " + document["result"].ToString() + " Farm$";
                }

                if (!oPFound)
                {
                    oPLine = document["place"].ToString() + ". " + document["result"].ToString() + " Farm$";
                }
                               
            }
            else
            {
                lLine = document["place"].ToString() + ". " + document["result"].ToString() + " Farm$";
            }
        }

        //Platzierung ausgeben
        firstPlace.text = fLine;
        overPlayerPlace.text = oPLine;
        playerPlace.text = pLine;
        underPlayerPlace.text = uPLine;
        lastPlace.text = lLine;

        print("Du hast Platz " + place + " von " + mongo.numberOfPlayers + " Spielern erreicht.");

    }


}
