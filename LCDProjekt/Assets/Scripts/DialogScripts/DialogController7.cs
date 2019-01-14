/*************************************************************************** 
* DialogController7
* Anwendung: Zur Steuerung des Dialogs in der Abschlussstory
* (erste Sprechblase)
* ------------------- 
* Zuletzt bearbeitet von: Anna Buchner
* Datum der letzten Bearbeitung: 18.12.2018
* Grund für letzte Bearbeitung: Risikoklasse ausgewertet und Einfluss der Schock-Events auf den Score
**************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;

public class DialogController7 : MonoBehaviour
{
    public float delay = 0.005f;
    private string fullText1;
    private string currentText = "";
    public Player player;
    public MongoConnect mongo;

    // Use this for initialization
    void Start()
    {
        player = Player.player;

        // Risiko auswerten
        player.calculateRisk();
        player.getRiskClass();

        // Ergebnis an DB schicken, vorerst auskommentiert
        player.sendResult();

        List<BsonDocument> batch = mongo.findResults();
        

        // Abschlusstext Risikoklasse
        fullText1 = Environment.NewLine + "Wir sind sehr stolz auf dich!" + Environment.NewLine + Environment.NewLine + "Mach weiter so und du wirst es noch weit bringen! " 
            + Environment.NewLine + Environment.NewLine + " Viel Glück!" + "Deine Risikoklasse: " + player.riskClass + ". Risikoscore:" + player.riskMean
            + ".";

        StartCoroutine(ShowText());
    }

    private IEnumerator ShowText()
    {
        for (int i = 0; i < fullText1.Length; i++)
        {
            currentText = fullText1.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }

    }


}
