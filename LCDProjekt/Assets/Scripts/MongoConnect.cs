/*************************************************************************** 
* MongoConnect
* Anwendung: Verbindung zur Datenbank, Abrufen und Speichern der Highscores

* ------------------- 
* Zuletzt bearbeitet von: Anna Buchner
* Datum der letzten Bearbeitung: 07.01.2019
* Grund fuer letzte Bearbeitung: Platzierung hinzugefuegt
**************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;

/// <summary>
/// Verbindung zur Datenbank herstellen, Abrufen und Speichern der Highscores.

/// </summary>
public class MongoConnect : MonoBehaviour {
    
    public int numberOfPlayers;

    string connectionString = "mongodb://localhost:27017";

    /// <summary>
    /// Initialisiert die Anzahl der Spieler als 0.
    /// </summary>
    void Start () {
        numberOfPlayers = 0;
    }

    /// <summary>
    /// Fuegt Dokumente in die DB ein
    /// </summary>
    /// <param name="batch"> Dokument, das in die DB eingefuegt werden soll.</param>
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

    /// <summary>
    /// Gibt eine nach result sortierte Liste der Spieler zurueck.
    /// </summary>
    /// <returns>Sortierte Spieler-Liste</returns>
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

        //speichert die Eintraege der DB sortiert in batchList ab
        foreach (var document in resultCollection.FindAll().SetSortOrder(SortBy.Descending("result")))
        {
            //Dem Dokument seine Platzierung zuweisen
            document["place"] = place;

            //Dokument zur Liste hinzufuegen
            batchList.Add(document);

            numberOfPlayers++;
            place++;
        }

        return batchList;
    }
}