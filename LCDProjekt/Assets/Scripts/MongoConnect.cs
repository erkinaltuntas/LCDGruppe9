/*************************************************************************** 
* MongoConnect
* Anwendung: Verbindung zur Datenbank, Abrufen und Speichern der Highscores

* ------------------- 
* Zuletzt bearbeitet von: Anna Buchner
* Datum der letzten Bearbeitung: 07.01.2019
* Grund für letzte Bearbeitung: Platzierung hinzugefügt
**************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;


public class MongoConnect : MonoBehaviour {

   
    public int numberOfPlayers;

    string connectionString = "mongodb://localhost:27017";
    //string connectionString = "mongodb://SDTeam:SDTeam18@sdfarms-shard-00-00-8g4lm.mongodb.net:27017,sdfarms-shard-00-01-8g4lm.mongodb.net:27017,sdfarms-shard-00-02-8g4lm.mongodb.net:27017/test?ssl=true&replicaSet=SDFarms-shard-0&authSource=admin&retryWrites=true";


    // Use this for initialization
    void Start () {
        numberOfPlayers = 0;
    }

    // Update is called once per frame
    void Update () {
		
	}

    //fügt Dokumente in die DB ein
    public void insertResult(BsonDocument[] batch)
    {
        /*
         * Establish connection
         */
        var client = new MongoClient(connectionString);
        var server = client.GetServer();
        var database = server.GetDatabase("UserDB");
        var resultCollection = database.GetCollection("Results");
        resultCollection.InsertBatch(batch);
    }


    //Gibt eine nach result sortierte Liste der Spieler zurück
    public List<BsonDocument> findResults()
    {
        /*
         * Establish connection
         */
        var client = new MongoClient(connectionString);
        var server = client.GetServer();
        var database = server.GetDatabase("UserDB");
        var resultCollection = database.GetCollection("Results");

        List<BsonDocument> batchList = new List<BsonDocument>();

        //Platzierungsvariable
        int place = 1;

        //speichert die Einträge der DB sortiert in batchList ab
        foreach (var document in resultCollection.FindAll().SetSortOrder(SortBy.Descending("result")))
        {
            //Dem Dokument seine Platzierung zuweisen
            document["place"] = place;

            //Dokument zur Liste hinzufügen
            batchList.Add(document);

            numberOfPlayers++;
            place++;
        }

        return batchList;
    }
}