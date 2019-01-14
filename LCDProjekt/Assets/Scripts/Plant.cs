/*************************************************************************** 
* Plant
* Anwendung: Zur Defintion der Pflanzen sowie der Steuerung, ob sie von 
* Duerre oder Frost betroffen sind
*------------------- 
* Zuletzt bearbeitet von: Erkin Altuntas
* Datum der letzten Bearbeitung: 10.12.2018
* Grund für letzte Bearbeitung: Anpassung der Wirkungsweise Frost/Dürre auf die Pflanzen
**************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour {
    // Alle Eigenschaften außer frosted und droughted werden manuell im Inspektor zugewiesen
    public int id;
    public string plantName;
    public double price;

    //maximaler Ertrag
    public double profit;
    public double droughtResistance;
    public double frostResistance;

    public bool frosted;
    public bool droughted;


	// Use this for initialization
	void Start () {
        // Pruefe beim Initialisieren, ob die Pflanze von Duerre oder Frost betroffen ist
        droughted = hasPlantDrought();
        frosted = hasPlantFrost();

	}

    // Bestimmt mittels Wahrscheinlichkeit, ob eine Pflanze von Duerre betroffen ist
    public bool hasPlantDrought()
    {
        if (Weather.frost == true)
        {
            int random = Random.Range(0, 10);
            if (random >= this.droughtResistance * 10)
            {
                return true;
            }
        }
        return false;
    }

    // Bestimmt mittels Wahrscheinlichkeit, ob eine Pflanze von Frost betroffen ist
    public bool hasPlantFrost()
    {
        if (Weather.drought == true)
        {
            int random = Random.Range(0, 10);
            if (random >= this.frostResistance * 10)
            {
                return true;
            }
        }
        
        return false;
    }

}
