using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Harvest : MonoBehaviour {

    public Feld feld;
    public Button button;
    public int profit;
    public Sprite empty;
    

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
        feld.GetComponent<SpriteRenderer>().sprite = empty;
        feld.feldIsHarvested = true;
        
    }

    int calculate()
    {
        int ertrag = feld.plant.profit;

        return ertrag;
    }
}
