using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Money : MonoBehaviour {

    public Player player;
    public TextMeshProUGUI moneyText;
    public double money;

	// Use this for initialization
    // initialisiere Geldanzeige 
	void Start () {
        moneyText = GetComponent<TextMeshProUGUI>();
        moneyText.text = money.ToString();
        money = 1000;

    }
	
	// Update is called once per frame
    //aktualisiere die Geldanzeige
	void Update () {
        moneyText.text = money.ToString();
        player.money = this.money;
    }
}
