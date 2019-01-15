/*************************************************************************** 
* DialogController
* Anwendung: Zur Steuerung des Dialogs in der Einfuehrungsstory
* (erste Sprechblase)
* ------------------- 
* Zuletzt bearbeitet von: Erkin Altuntas
* Datum der letzten Bearbeitung: 14.12.2018
* Grund für letzte Bearbeitung: Erstellung
**************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    // Schnelligkeit der Anzeige des Textes
    public float delay = 0.005f;
    // Text der ersten Sprechblase
    private string fullText1 = "Hallo mein Kind." + Environment.NewLine + Environment.NewLine + "Wie war nochmal dein Name?";
    private string currentText = "";

    public InputField inputName;
    string playerName;

    public GameObject speechBubble1, speechBubble2;
    public GameObject confirmButton, nextButton2;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(ShowText());
        playerName = PlayerPrefs.GetString("PlayerName");
        confirmButton.GetComponentInChildren<Button>().onClick.AddListener(TaskOnConfirm);
    }

    // Zeigt den Dialog Buchstabe fuer Buchstaben
    private IEnumerator ShowText()
    {
        for (int i = 0; i < fullText1.Length; i++)
        {
            currentText = fullText1.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }

    }

    public void saveName()
    {
        playerName = inputName.text;
        PlayerPrefs.SetString("PlayerName", playerName);
    }

    void TaskOnConfirm()
    {
        if (!inputName.text.Equals(""))
        {
            speechBubble1.SetActive(false);
            speechBubble2.SetActive(true);
            confirmButton.SetActive(false);
            nextButton2.SetActive(true);
        }
        else
        {
            // kein Wert wurde eingegeben
        }
    }
}