/*************************************************************************** 
* Field
* Anwendung: Zur Definition und Steuerung der Felder
* ------------------- 
* Zuletzt bearbeitet von: Erkin Altuntas
* Datum der letzten Bearbeitung: 10.12.2018
* Grund fuer letzte Bearbeitung: Kommentare/Code Pflege
**************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Steuert die Felder.
/// </summary>
public class Field : MonoBehaviour {

    public int id;
    public string plantName = "";
    //wie viel Prozent der Ernte erfolgreich war
    public int successRate;
    public bool shock;
    public Plant plant;
    Collider2D collider1;
    public bool fieldIsHarvested;
    public bool fieldIsChecked;
    public Sprite tomatoGrown;
    public Sprite potatoGrown;
    public Sprite cornGrown;
    public Sprite carrotGrown;

    /// <summary>
    /// Initialisierung
    /// </summary>
    void Start () {
        collider1 = this.GetComponent<Collider2D>();
        fieldIsChecked = false;
    }

    /// <summary>
    /// Solange auf dem Feld nichts angepflanzt ist, ist das Feld anklickbar
    /// </summary>
    // Update is called once per frame
    void Update () { 
		if(plantName != "")
        {
            collider1.enabled = false; 
        }
	}

    /// <summary>
    /// Aendert beim Pflanzen die Sprites der Felder.
    /// </summary>
    public void changeSprite()
    {
        // Weise je nach Auswahl dem Feld das Sprite der Pflanze zu
        switch (plantName)
        {
            case "Tomato": this.GetComponent<SpriteRenderer>().sprite = tomatoGrown; break;
            case "Carrot": this.GetComponent<SpriteRenderer>().sprite = carrotGrown; break;
            case "Potato": this.GetComponent<SpriteRenderer>().sprite = potatoGrown; break;
            case "Corn": this.GetComponent<SpriteRenderer>().sprite = cornGrown; break;
            default: break;

        }
    }
}
