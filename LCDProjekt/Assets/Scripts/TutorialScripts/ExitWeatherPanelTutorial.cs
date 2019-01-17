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

/// <summary>
/// 
/// </summary>
public class ExitWeatherPanelTutorial : MonoBehaviour {
    public Button exitWeatherPanel;
    public Button weatherButton;
    bool clicked, clicked2;
    public GameObject step1, step11, step2, step3, step4, step5, step6, step7, step8;
    public Field field1, field2, field3, field4;
    private Collider2D collider1, collider2, collider3, collider4;
    public TutorialAdventureScript tutorial;

    /// <summary>
    /// Initialisierung
    /// </summary>
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

    /// <summary>
    /// 
    /// </summary>
    void TaskOnClick()
    {
        if(tutorial.step1Open)
        {
            step1.SetActive(false);
            step11.SetActive(true);
            tutorial.step1Open = false;
            tutorial.step11Open = true;

            collider1.enabled = false;
            collider2.enabled = false;
            collider3.enabled = false;
            collider4.enabled = false;
        }
        else if(tutorial.step11Open)
        {
            step11.SetActive(false);
            step2.SetActive(true);
            weatherButton.enabled = false;
            tutorial.step11Open = false;
            tutorial.step2Open = true;
            collider1.enabled = false;
            collider2.enabled = false;
            collider3.enabled = false;
            collider4.enabled = false;
        }
        else
        {
            if (tutorial.step2Open)
            {
                step2.SetActive(true);
            }
            if (tutorial.step3Open)
            {
                step3.SetActive(true);
            }
            else if (tutorial.step4Open)
            {
                step4.SetActive(true);
            }
            else if (tutorial.step5Open)
            {
                step5.SetActive(true);
            }
            else if (tutorial.step6Open)
            {
                step6.SetActive(true);
            }
            else if (tutorial.step7Open)
            {
                step7.SetActive(true);
            }
            else if (tutorial.step8Open)
            {
                step8.SetActive(true);
            }

        }
        
    }


    void TaskOnClick2()
    {
        step1.SetActive(false);
        step11.SetActive(false);
        step2.SetActive(false);
        step3.SetActive(false);
        step4.SetActive(false);
        step5.SetActive(false);
        step6.SetActive(false);
        step7.SetActive(false);
        step8.SetActive(false);
    }
}
