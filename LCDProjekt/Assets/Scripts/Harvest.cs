using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Harvest : MonoBehaviour {

    public Feld feld;
    public Button button;
    public int profit;
    public Sprite empty;
    public Money cash;
    double missErnteQuote;

    // Use this for initialization
    void Start () {
        button.onClick.AddListener(TaskOnClick);
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void TaskOnClick()
    {
        profit = calculate();
        cash.money = cash.money + profit;
        feld.GetComponent<SpriteRenderer>().sprite = empty;
        feld.feldIsHarvested = true;
        
    }

    int calculate()
    {
        int ertrag = feld.plant.profit;

        //Random rand = new Random();
        //int n3 = rand.nextInt(3);
        //if (n3 == 0) missErnteQuote = 0.25;
        //if (n3 == 1) missErnteQuote = 0.5;
        //if (n3 == 2) missErnteQuote = 0.75;

        return ertrag;
    }
}
