using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shock : MonoBehaviour {

    Player player;

    // Use this for initialization
    void Start () {
        player = Player.player;
        //positiver Schock
        if (player.season == 2){

        }
        //negativer Schock
        if (player.season == 3)
        {

        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
