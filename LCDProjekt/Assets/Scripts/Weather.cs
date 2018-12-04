using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weather : MonoBehaviour {
    public string seasonName;
    public double frostProb;
    public double droughtProb;

    // Use this for initialization
    void Start () {
        seasonName = "Frühling";
        frostProb = 0.5;
        droughtProb = 0.2;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void calculateWeather()
    {
        //Random rand = new Random();
       //int n1 = rand.nextInt(11);
       //int n2 = rand.nextInt(11);

        //if (n1 <= frostP * 10 || n2 <= droughtP * 10)
        //{
         //   return plant.ertrag - plant.kosten - plant.ertrag * missErnteQuote;
        //}
        //return plant.ertrag - plant.kosten;
    }
}
