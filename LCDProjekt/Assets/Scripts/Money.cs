/*************************************************************************** 
* Money
* Anwendung: Zur Anzeige und Aktualisierung des Geldes
* ------------------- 
* Zuletzt bearbeitet von: Erkin Altuntas
* Datum der letzten Bearbeitung: 10.12.2018
* Grund fuer letzte Bearbeitung: Kommentare/Code Pflege
**************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Steuert den Kontostand.
/// </summary>
public class Money : MonoBehaviour {

    public Player player;
    public TutorialPlayer tutorialPlayer;
    public TextMeshProUGUI moneyText;
    public double money;
    GameObject weather;
    bool tutorial;

	/// <summary>
    /// Initialisierung der Money-Objekte.
    /// </summary>
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
	
	/// <summary>
    /// Zeigt den aktuellen Kontostand an.
    /// </summary>
	void Update () {
        moneyText.text = "<color=green>" +money.ToString()+ "<color=white>" + " Farm $";
        if (!tutorial)
        {          
            player.money = this.money;
        }
        else
        {           
            tutorialPlayer.money = this.money;
        }
    }
    
    /// <summary>
    /// Prueft, ob der Spieler ueber 0 Farm $ hat.
    /// </summary>
    /// <returns>Gibt true zurueck, wenn der Spieler mehr als 0 Farm $ hat und false sonst.</returns>
    public bool enoughMoney()
    {
        if (this.money < 0)
        {
            return false;
        }
        return true;
    }

}
