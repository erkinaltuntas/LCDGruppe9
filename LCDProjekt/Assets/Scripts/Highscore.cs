/*************************************************************************** 
* Highscore
* Anwendung: Anzeigen der Platzierung
* ------------------- 
* Zuletzt bearbeitet von: Erkin Altuntas
* Datum der letzten Bearbeitung: 14.01.2019
* Grund für letzte Bearbeitung: Platzierung auswerten fuer Fall von 5 Spielern
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
    public Text space;
    public Text space2;
    string fLine = "";
    string oPLine = "";
    string pLine = "";
    string uPLine = "";
    string lLine = "";
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

                if (pFound)
                {
                    uPLine = document["place"].ToString() + ". " + document["result"].ToString() + " Farm $";
                    uPFound = true;
                }

                if (!firstFound)
                {
                    if (document["result"] == player.endTotal)
                    {
                        oPFound = true;
                        pFound = true;
                    }
                    fLine = document["place"].ToString() + ". " + document["result"].ToString() + " Farm $";

                    firstFound = true;
                }

                if (!pFound && document["result"] == player.endTotal)
                {
                    oPFound = true;
                    pFound = true;
                    place = document["place"].ToString();

                    pLine = place + ". " + document["result"].ToString() + " Farm $";
                }

                if (!oPFound)
                {
                    oPLine = document["place"].ToString() + ". " + document["result"].ToString() + " Farm $";
                }
                               
            }
            else
            {

                lLine = document["place"].ToString() + ". " + document["result"].ToString() + " Farm $";
            }
        }

        //Platzierung ausgeben (fuer min. 5 Spieler)
        if (place.Equals("1"))
        {
            firstPlace.text = fLine;
            firstPlace.color = Color.green;
            space.text = uPLine;
            overPlayerPlace.text = "...";
            playerPlace.text = lLine;
            playerPlace.color = Color.white;
            underPlayerPlace.text = "";
            space2.text = "";
            lastPlace.text = "";
        }
        else if (place.Equals("2"))
        {
            firstPlace.text = fLine;
            space.text = pLine;
            space.color = Color.green;
            overPlayerPlace.text = uPLine;
            playerPlace.text = "...";
            playerPlace.color = Color.white;
            underPlayerPlace.text = lLine;
            space2.text = "";
            lastPlace.text = "";  
        }
        else
        {
            //letzter oder vorletzter Platz
            if (lLine.Equals(""))
            {
                space.text = "...";
                space2.text = "";
            }
            firstPlace.text = fLine;
            overPlayerPlace.text = oPLine;
            playerPlace.text = pLine;
            underPlayerPlace.text = uPLine;
            lastPlace.text = lLine;

        }
    }


}
