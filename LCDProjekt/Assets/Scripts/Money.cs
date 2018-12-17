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
    public TextMeshProUGUI moneyText;
    public double money;

	// Use this for initialization
	void Start () {

        player = Player.player;
        moneyText = GetComponent<TextMeshProUGUI>();
        moneyText.text = money.ToString();
        this.money = player.money;

    }
	
	// Update is called once per frame
	void Update () {
        moneyText.text = money.ToString();
        player.money = this.money;
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
