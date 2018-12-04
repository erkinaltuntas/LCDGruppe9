using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour {

    public int id;
    public string plantName;
    //Preis der Pflanze
    public double price;

    //maximaler Ertrag
    public double profit;
    //Duerreresistenz
    public double droughtResistance;

    //Frostresistenz
    public double frostResistance;

    public bool frosted;
    public bool droughted;


	// Use this for initialization
	void Start () {
        droughted = hasPlantDrought();
        frosted = hasPlantFrost();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool hasPlantDrought()
    {
        int random = Random.Range(0, 11);
        if(random > this.droughtResistance * 10)
        {
            return true;
        }
        return false;
    }

    public bool hasPlantFrost()
    {
        int random = Random.Range(0, 11);
        if (random > this.frostResistance * 10)
        {
            return true;
        }
        return false;
    }

}
