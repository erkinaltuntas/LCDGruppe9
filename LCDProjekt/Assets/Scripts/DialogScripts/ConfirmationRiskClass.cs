using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmationRiskClass : MonoBehaviour {

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


        // Abschlusstext Risikoklasse

        if (player.riskMedian < 0.7d)
        {
            fullText1 = Environment.NewLine + "Deine Risikoklasse ist Sicherheit." + Environment.NewLine + Environment.NewLine + "Beschreibung:" + Environment.NewLine +
                "Kontinuierliche Wertentwicklung bei niedriger Rendite." + Environment.NewLine + "Minimale Risiken aus Kursschwankung";
        }
        else if (0.7d <= player.riskMedian && player.riskMedian < 0.9d)
        {
            fullText1 = Environment.NewLine + "Deine Risikoklasse ist Ertrag." + Environment.NewLine + Environment.NewLine + "Beschreibung::" + Environment.NewLine +
                "Kapitalwachstum aus Zinserträgen und möglichen Kursgewinnen." + Environment.NewLine + "Moderate Risiken aus Kursschwankungen, geringe Bonitätsrisiken.";
        }
        else if (0.9d <= player.riskMedian && player.riskMedian < 1.1d)
        {
            fullText1 = Environment.NewLine + "Deine Risikoklasse ist Wachstum." + Environment.NewLine + Environment.NewLine + "Beschreibung::" + Environment.NewLine +
                "Höheres Kapitalwachstum durch höhere Kurs- und Zinserträge." + Environment.NewLine + "Höhere Kursschwankungsrisiken, Kursverluste möglich.";
        }
        else if (1.1d <= player.riskMedian && player.riskMedian < 1.3d)
        {
            fullText1 = Environment.NewLine + "Deine Risikoklasse ist Risiko." + Environment.NewLine + Environment.NewLine + "Beschreibung::" + Environment.NewLine +
                "Hohe Ertragschancen durch hohe Zins-, Kurs-, Währungsgewinne." + Environment.NewLine + "Hohe Zins-, Bonitäts-und Währungsrisiken.Hohes Kursrisiko.";
        }
        else if (1.3d <= player.riskMedian)
        {
            fullText1 = Environment.NewLine + "Deine Risikoklasse ist Spekulativ." + Environment.NewLine + Environment.NewLine + "Beschreibung::" + Environment.NewLine +
                "Sehr hohe Ertragschancen durch überdurchschnittliche Zins-, Kurs-, Währungsgewinne." + Environment.NewLine + "Überdurchschnittlich hohe Risiken aus Zins-, Kurs-,Währungsschwankungen, Totalverlust möglich.";
        }


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
