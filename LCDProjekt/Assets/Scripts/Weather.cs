/*************************************************************************** 
* Weather
* Anwendung: Zur Defintion des Wetters.  
* Bestimmt ob in einer Jahreszeit Frost oder Duerre (oder beides) auftritt.
*------------------- 
* Zuletzt bearbeitet von: Thomas Wieschermann
* Datum der letzten Bearbeitung: 17.01.2019
* Grund fuer letzte Bearbeitung: Kommentare
**************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Zur Definition des Wetters. Bestimmt ob in einer Jahreszeit Frost oder Duerre (oder beides) auftritt,
/// jedoch noch nicht ob eine bestimmte Pflanze davon betroffen ist.
/// </summary>
/// <remarks>Hierbei ist zu beachten, dass die eigentlichen Werte der Wahrscheinlichkeiten der verschiedenen Jahreszeiten
/// und der Pflanzen direkt ueber Game-Objekte manuell im Inspektor festgelegt werden und nicht ueber Scripte.</remarks>
public class Weather : MonoBehaviour {
    public string seasonName;
    public int seasonNumber;
    public double frostProb;
    public double droughtProb;
    public static bool frost = false;
    public static bool drought = false;

    public int random1, random2;

    /// <summary>
    /// Bei Start werden zunaechst zwei zufaellige Integer-Werte zwischen 0 und 9 festgelegt.
    /// Sukzessiv werden mit diesen beiden zufaelligen Integer-Werten die beiden Methoden isFrost und isDrought aufgerufen.
    /// Dabei wird random1 benutzt um festzulegen ob es Frost gibt und random2 um festzulegen ob es Duerre gibt.
    /// </summary>
    void Start () {

        random1 = Random.Range(0, 10);
        random2 = Random.Range(0, 10);
        frost = isFrost();
        drought = isDrought();

    }

    /// <summary>
    /// Bestimmt ob in einer bestimmten Jahreszeit Frost bei Pflanzen vorkommen kann.
    /// Dabei wird der Zufallswert random1 mit der Frostwahrscheinlichkeit der Jahreszeit verglichen.
    /// Sollte der Zufallswert kleiner gleich dem Wahrscheinlicheitswert der Jahreszeit sein, ist fuer alle Pflanzen in der Jahreszeit
    /// Frost moeglich.
    /// </summary>
    /// <returns>Wahrheitswert der angibt ob Pflanzen von Frost in dieser Jahreszeit betroffen sein koennen</returns>
    public bool isFrost()
    {
        if (random1 <= this.frostProb * 10)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Bestimmt ob in einer bestimmten Jahreszeit Duerre bei Pflanzen vorkommen kann.
    /// Dabei wird der Zufallswert random1 mit der Duerrewahrscheinlichkeit der Jahreszeit verglichen.
    /// Sollte der Zufallswert kleiner gleich dem Wahrscheinlicheitswert der Jahreszeit sein, ist fuer alle Pflanzen in der Jahreszeit
    /// Duerre moeglich.
    /// </summary>
    /// <returns>Wahrheitswert der angibt ob Pflanzen von Duerre in dieser Jahreszeit betroffen sein koennen</returns>
    public bool isDrought()
    {
        if (random2 <= this.droughtProb * 10)
        {
            return true;
        }
        return false;
    }
}
