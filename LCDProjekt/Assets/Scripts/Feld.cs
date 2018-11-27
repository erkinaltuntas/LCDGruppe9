using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feld : MonoBehaviour {

    public int id;
    public string plantName = "";
    //wie viel Prozent der Ernte erfolgreich war
    public int successRate;
    public bool shock;
    public Plant plant;
    Collider2D collider1;
    public bool feldIsHarvested;
    
    // Use this for initialization
    void Start () {
        collider1 = this.GetComponent<Collider2D>();
    }
	
	// Update is called once per frame
	void Update () {
		if(plantName != "")
        {
            collider1.enabled = false; 
        }
	}
}
