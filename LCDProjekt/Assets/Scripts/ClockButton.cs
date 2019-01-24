/*************************************************************************** 
* ClockButton
* Anwendung: Abspielen der Animation der Uhr nach einer Jahreszeit
* ------------------- 
* Zuletzt bearbeitet von: Victor Xu
* Datum der letzten Bearbeitung: 10.12.2018
* Grund für letzte Bearbeitung: Animation der Uhr hat eine bestimmte Geschwindigkeit
**************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Spielt die Uhr-Animation vor der Ernte ab.
/// </summary>
public class ClockButton : MonoBehaviour {

    public Button harvestButton;
    public GameObject clock;
    public GameObject background;
    public Animation clockAnimation;

    /// <summary>
    /// Initialisierung.
    /// </summary> 
    void Start () {
        // Die Methode TaskOnClick wird ausgeführt, wenn der harvestButton gedrückt wird
        harvestButton.onClick.AddListener(TaskOnClick);
    }

    /// <summary>
    /// Spielt die Uhr-Animation auf Button-Klick ab.
    /// </summary>
    void TaskOnClick()
    {
        // Spiele die Animation der Uhr ab
        clock.SetActive(true);
        background.SetActive(true);
        clockAnimation["Clock"].speed = 0.8f;
        clockAnimation.Play("Clock");
        

    }

    /// <summary>
    /// Zum Beenden der Animation.
    /// </summary>
    public void ClockAnimationEnd()
    {
            clock.SetActive(false);
            background.SetActive(false);
        
    }
}
