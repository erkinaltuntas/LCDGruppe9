/*************************************************************************** 
* Money
* Anwendung: Zur Anzeige und Aktualisierung des Geldes
* ------------------- 
* Zuletzt bearbeitet von: Erkin Altuntas
* Datum der letzten Bearbeitung: 10.12.2018
* Grund für letzte Bearbeitung: Kommentare/Code Pflege
**************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Money : MonoBehaviour {

    public Player player;
    public TutorialPlayer tutorialPlayer;
    public TextMeshProUGUI moneyText;
    public double money;
    GameObject weather;
    bool tutorial;

	// Use this for initialization
	void Start () {
        weather = GameObject.Find("Weather");
        moneyText = GetComponent<TextMeshProUGUI>();
        moneyText.text = money.ToString();
        if (weather.GetComponent<Weather>().seasonNumber != 0)
        {
            player = Player.player;
            this.money = player.money;
            tutorial = false;
        }
        else
        {
            tutorialPlayer = TutorialPlayer.tutorialPlayer;
            this.money = tutorialPlayer.money;
            tutorial = true;
        }


    }
	
	// Update is called once per frame
	void Update () {
        moneyText.text = "Geld: "+money.ToString();
        if (!tutorial)
        {          
            player.money = this.money;
        }
        else
        {           
            tutorialPlayer.money = this.money;
        }
    }
    
    public bool enoughMoney()
    {
        if (this.money < 0)
        {
            return false;
        }
        return true;
    }

}
