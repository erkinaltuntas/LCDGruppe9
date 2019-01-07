using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;


public class MongoConnect : MonoBehaviour {

    string connectionString = "mongodb://localhost:27017";
    //string connectionString = "mongodb://SDTeam:SDTeam18@sdfarms-shard-00-00-8g4lm.mongodb.net:27017,sdfarms-shard-00-01-8g4lm.mongodb.net:27017,sdfarms-shard-00-02-8g4lm.mongodb.net:27017/test?ssl=true&replicaSet=SDFarms-shard-0&authSource=admin&retryWrites=true";


    // Use this for initialization
    void Start () {
       
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

        //speichert die Einträge der DB sortiert in batchList ab
        foreach (var document in resultCollection.FindAll().SetSortOrder(SortBy.Descending("result")))
        {
            batchList.Add(document);
        }

        foreach(var document in batchList)
        {
            Debug.Log(" SELECT ALL DOCS: \n" + document);
        }

        return batchList;
    }
}