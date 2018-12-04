using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weather : MonoBehaviour {
    public string seasonName;
    public double frostProb;
    public double droughtProb;

    public int random1, random2;

    // Use this for initialization
    void Start () {
        seasonName = "Frühling";
        //frostProb = 0.5;
        //droughtProb = 0.2;

        random1 = Random.Range(0, 11);
        random2 = Random.Range(0, 11);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool isFrost()
    {
        if (random1 <= this.frostProb * 10)
        {
            return true;
        }
        return false;
    }

    public bool isDrought()
    {
        if (random2 <= this.droughtProb * 10)
        {
            return true;
        }
        return false;
    }
}
