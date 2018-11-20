using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Money : MonoBehaviour {

    public Player player;
    public TextMeshProUGUI moneyText;
    public int money;

	// Use this for initialization
	void Start () {
        moneyText = GetComponent<TextMeshProUGUI>();
        moneyText.text = money.ToString();

    }
	
	// Update is called once per frame
	void Update () {
        moneyText.text = money.ToString();
        player.money = this.money;
    }
}
