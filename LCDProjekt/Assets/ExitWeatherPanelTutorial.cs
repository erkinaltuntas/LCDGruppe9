/*************************************************************************** 
* ExitWeatherPanelTutorial
* Anwendung: Anzeige der ersten Schritte des Tutorials
*------------------- 
* Zuletzt bearbeitet von: Erkin Altuntas
* Datum der letzten Bearbeitung: 30.12.2018
* Grund für letzte Bearbeitung: Erstellung
* **************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitWeatherPanelTutorial : MonoBehaviour {
    public Button exitWeatherPanel;
    public Button weatherButton;
    bool clicked, clicked2;
    public GameObject step1, step11, step2;
    public Field field1, field2, field3, field4;
    private Collider2D collider1, collider2, collider3, collider4;

    // Use this for initialization
    void Start () {
        exitWeatherPanel.onClick.AddListener(TaskOnClick);
        weatherButton.onClick.AddListener(TaskOnClick2);
        clicked = false;

        // Collider der Felder definieren
        collider1 = field1.GetComponent<Collider2D>();
        collider2 = field2.GetComponent<Collider2D>();
        collider3 = field3.GetComponent<Collider2D>();
        collider4 = field4.GetComponent<Collider2D>();




    }
	
	// Update is called once per frame
	void Update () {
        if (clicked)
        {
            step11.SetActive(false);
        }
	}

    void TaskOnClick()
    {
        step1.SetActive(false);
        if (!clicked)
        {
            step11.SetActive(true);
            collider1.enabled = false;
            collider2.enabled = false;
            collider3.enabled = false;
            collider4.enabled = false;
        }
        else if(clicked && !clicked2)
        {
            
            step2.SetActive(true);
            clicked2 = true;
            collider1.enabled = false;
            collider2.enabled = false;
            collider3.enabled = false;
            collider4.enabled = false;

        }
        
        
    }


    void TaskOnClick2()
    {
        clicked = true;
        step11.SetActive(false);
    }
}
