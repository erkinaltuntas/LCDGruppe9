﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shock : MonoBehaviour {

    Player player;
    public Button opt1Button;
    public Button opt2Button;
    public GameObject shockPanel;
    public Weather weather;

    // Use this for initialization
    void Start () {
        player = Player.player;
        //positiver Schock
        if (weather.seasonName == "Sommer")
        {
           
        }
        //negativer Schock
        if (weather.seasonName == "Herbst")
        {

        }
        opt1Button.onClick.AddListener(TaskOnClick);
        opt2Button.onClick.AddListener(TaskOnClick);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void TaskOnClick()
    {
        shockPanel.SetActive(false);
    }
}
