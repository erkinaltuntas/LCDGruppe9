/*************************************************************************** 
* Plant
* Anwendung: Zur Defintion der Pflanzen sowie der Steuerung, ob sie von 
* Duerre oder Frost betroffen sind
*------------------- 
* Zuletzt bearbeitet von: Thomas Wieschermann
* Datum der letzten Bearbeitung: 17.01.2019
* Grund für letzte Bearbeitung: Kommentare
**************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Zur Definition der Pflanzen. Den Pflanzen wird eine ID, ein Name, ein (Anbau-)Preis, ein Ertrag, eine Frostresistenzwahrscheinlichkeit 
/// und eine Duerreresistenzwahrscheinlichkeit zugewiesen.
/// Sollte in  <c>Weather.cs</c> bestimmt worden sein, dass für die Jahreszeit
/// Frost und/oder Duerre möglich ist, so wird für die Pflanzen einzelnd errechnet ob sie von Frost und/oder Duerre betroffen sind.
/// </summary>
/// <remarks>Hierbei ist zu beachten, dass alle Eigenschaften
/// außer <c>frosted</c> und <c>droughted</c> über Game-Objekte
/// manuell im Inspektor festgelegt (initialisiert) werden und nicht über Scripte.</remarks>
public class Plant : MonoBehaviour {
    
    public int id;
    public string plantName;
    public double price;

    //maximaler Ertrag
    public double profit;
    public double droughtResistance;
    public double frostResistance;

    public bool frosted;
    public bool droughted;


	/// <summary>
    /// Ruft die beiden Methoden <c>hasPlantDrought</c> und <c>hasPlantFrost</c> auf und bestimmt damit ob eine Pflanze
    /// von Frost oder Duerre betroffen ist.
    /// </summary>
	void Start () {
        
        droughted = hasPlantDrought();
        frosted = hasPlantFrost();

	}

    /// <summary>
    /// Bestimmt ob eine bestimmt Pflanze von Duerre betroffen ist. 
    /// Hierzu wird, sollte der von <c>Weather.cs</c> übergebene relevante Wahrheitswert wahr sein, 
    /// ein Zufallswert, <c>random</c> mit dem im Inspektor festgelegten Duerreresistenzwert verglichen.
    /// Sollte dieser groesser gleich dem Duerreresistenzwert sein, ist die Pflanze von Duerre betroffen.
    /// </summary>
    /// <returns>Wahrheitswert, der angibt ob eine bestimmte Pflanzenart in einer bestimmten Jahreszeit von Duerre betroffen ist.</returns>
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

    /// <summary>
    /// Bestimmt ob eine bestimmt Pflanze von Frost betroffen ist. 
    /// Hierzu wird, sollte der von <c>Weather.cs</c> übergebene relevante Wahrheitswert wahr sein, 
    /// ein Zufallswert, <c>random</c> mit dem im Inspektor festgelegten Frostresistenzwert verglichen.
    /// Sollte dieser groesser gleich dem Frostresistenzwert sein, ist die Pflanze von Frost betroffen.
    /// </summary>
    /// <returns>Wahrheitswert, der angibt ob eine bestimmte Pflanzenart in einer bestimmten Jahreszeit von Frost betroffen ist.</returns>
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
