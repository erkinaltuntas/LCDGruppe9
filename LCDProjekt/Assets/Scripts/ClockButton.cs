/*************************************************************************** 
* ClockButton
* Anwendung: Abspielen der Animation der Uhr nach einer Jahreszeit
* ------------------- 
* Zuletzt bearbeitet von: Erkin Altuntas
* Datum der letzten Bearbeitung: 10.12.2018
* Grund für letzte Bearbeitung: Kommentare/Code Pflege
**************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockButton : MonoBehaviour {

    public Button harvestButton;
    public GameObject clock;
    public GameObject background;
    public Animation clockAnimation;

	// Use this for initialization
	void Start () {
        // Die Methode TaskOnClick wird ausgeführt, wenn der harvestButton gedrückt wird
        harvestButton.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        // Spiele die Animation der Uhr ab
        clock.SetActive(true);
        background.SetActive(true);
        clockAnimation.Play("Clock");
        

    }

    // Zum Beenden der Animation
    public void ClockAnimationEnd()
    {
            clock.SetActive(false);
            background.SetActive(false);
        
    }
}
