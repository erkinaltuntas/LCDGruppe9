﻿/*************************************************************************** 
* TutorialAdventureScript
* Anwendung: Tutorial 
* ------------------- 
* Zuletzt bearbeitet von: Cedric Meyer-Piening
* Datum der letzten Bearbeitung: 17.01.2019
* Grund für letzte Bearbeitung: Kommentare
**************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

/// <summary>
/// Steuerung des Ablaufs des Tutorials.
/// </summary>
public class TutorialAdventureScript : MonoBehaviour {

    public Vector3 mousePos;
    public Vector3 mousePosWorld;
    public Camera mainCamera;
    public Vector2 mousePosWorld2D;
    public Field field1, field2, field3, field4;
    public int currentFeldId;
    public double price;
    public TutorialPlayer tutorialPlayer;
    public Money cash;
    public Sprite tomato;
    public Sprite potato;
    public Sprite corn;
    public Sprite carrot;
    public Sprite empty;
    RaycastHit2D hit;
    Collider2D collider1;
    Collider2D collider2;
    Collider2D collider3;
    Collider2D collider4;
    public GameObject nextLevelButton;
    public GameObject gameButtonsPanel, selectionPanel, harvestPanel, weatherPanel, creditPanel, balancePanels, confirmPanel;
    public Text errorMessage;
    public GameObject tomatoObj;
    public GameObject potatoObj;
    public GameObject cornObj;
    public GameObject carrotObj;
    public GameObject emptyObj;
    public GameObject weather;
    public GameObject step1, step11, step2, step3, step4, step5, step6, step7, step71, step8;
    public Button exitStep2Button;
    public bool step1Open, step11Open, step2Open, step3Open, step4Open, step5Open, step6Open, step7Open, step71Open, step8Open;
    public Button confirmButton, rejectButton, harvestAllButton;
    private Plant plant;

    /// <summary>
    /// Steuert den Start des Tutorials.
    /// </summary>
    // Use this for initialization
    void Start()
    {
        tutorialPlayer = TutorialPlayer.tutorialPlayer;
        weather = GameObject.Find("Weather");
        // Zu Beginn des Spiels Wetteranzeige aktivieren, andere Objekte deaktivieren
        weatherPanel.SetActive(true);
        step1.SetActive(true);
        step1Open = true;
        selectionPanel.SetActive(false);
        errorMessage.text = "";
        gameButtonsPanel.SetActive(false);

        // Definiert welcher Schritt gerade angezeigt wird
        step11Open = step2Open = step3Open = step4Open = step5Open = step6Open = step7Open = step8Open = false;
        step2.GetComponentInChildren<Button>().onClick.AddListener(TaskOnStep2);
        harvestAllButton.onClick.AddListener(TaskOnStep6);
        step71.GetComponentInChildren<Button>().onClick.AddListener(TaskOnStep71);

        // Collider der Felder definieren
        collider1 = field1.GetComponent<Collider2D>();
        collider2 = field2.GetComponent<Collider2D>();
        collider3 = field3.GetComponent<Collider2D>();
        collider4 = field4.GetComponent<Collider2D>();

        // Collider beim Start deaktivieren, damit Felder nicht interaktiv sind
        collider1.enabled = false;
        collider2.enabled = false;
        collider3.enabled = false;
        collider4.enabled = false;

        confirmButton.onClick.AddListener(TaskOnConfirm);
        rejectButton.onClick.AddListener(TaskOnReject);
    }

    /// <summary>
    /// Steuert den Ablauf des Tutorials.
    /// </summary>
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Mausposition definieren
            mousePos = Input.mousePosition;

            // Mausposition World
            mousePosWorld = mainCamera.ScreenToWorldPoint(mousePos);
            // In zweidim Vektor umwandeln
            mousePosWorld2D = new Vector2(mousePosWorld.x, mousePosWorld.y);

            // Bestimme Punkt des Mausklicks
            hit = Physics2D.Raycast(mousePosWorld2D, Vector2.zero);

            // Prüfe ob hit einen collider beinhaltet
            if (hit.collider != null)
            {

                // Falls der Collider, welcher getroffen wurde, der Collider eines Feldes ist, zeige das Auswahlfenster an
                if (hit.collider.gameObject.tag == "Feld")
                {

                    if (!field1.fieldIsChecked && !field2.fieldIsChecked && !field3.fieldIsChecked && !field4.fieldIsChecked)
                    {
                        step3.SetActive(false);
                        step3Open = false;
                        step4.SetActive(true);
                        step4Open = true;
                    }



                    selectionPanel.SetActive(true);
                    gameButtonsPanel.SetActive(false);



                    // Setzt currentFeldID auf die ID des ausgewhählten Feldes
                    currentFeldId = hit.collider.gameObject.GetComponent<Field>().id;
                    collider1.enabled = false;
                    collider2.enabled = false;
                    collider3.enabled = false;
                    collider4.enabled = false;

                }
                // Falls der Collider, welcher getroffen wurde, der Collider einer Pflanze (im Auswahlfenster) ist
                else if (hit.collider.gameObject.tag == "Pflanze")
                {
                    errorMessage.text = "";
                    plant = hit.collider.gameObject.GetComponent<Plant>();
                    price = plant.price;

                    if (cash.money >= price)
                    {


                        // Bestätigungsdialog ausführen
                        confirmPanel.SetActive(true);
                        // Während Dialog kann man die anderen Pflanzen nicht anklicken
                        tomatoObj.GetComponent<Collider2D>().enabled = false;
                        carrotObj.GetComponent<Collider2D>().enabled = false;
                        cornObj.GetComponent<Collider2D>().enabled = false;
                        potatoObj.GetComponent<Collider2D>().enabled = false;
                        emptyObj.GetComponent<Collider2D>().enabled = false;

                        // Dialogtext
                        if (plant.plantName == "Tomato")
                        {
                            confirmPanel.GetComponentInChildren<Text>().text = "Möchtest du wirklich Tomaten anbauen?" + Environment.NewLine + Environment.NewLine;
                        }
                        else if (plant.plantName == "Carrot")
                        {
                            confirmPanel.GetComponentInChildren<Text>().text = "Möchtest du wirklich Karotten anbauen?" + Environment.NewLine + Environment.NewLine;
                        }
                        else if (plant.plantName == "Corn")
                        {
                            confirmPanel.GetComponentInChildren<Text>().text = "Möchtest du wirklich Mais anbauen?" + Environment.NewLine + Environment.NewLine;
                        }
                        else if (plant.plantName == "Potato")
                        {
                            confirmPanel.GetComponentInChildren<Text>().text = "Möchtest du wirklich Kartoffeln anbauen?" + Environment.NewLine + Environment.NewLine;
                        }
                        else if (plant.plantName == "Empty")
                        {
                            confirmPanel.GetComponentInChildren<Text>().text = "Möchtest du wirklich nichts anbauen?";
                        }




                    }
                    // Falls man nicht genuegend Geld hat
                    else
                    {
                        if (!creditPanel.GetComponent<Credit>().shown)
                        {
                            creditPanel.SetActive(true);
                        }
                        else
                        {
                            errorMessage.text = "Sie haben nicht genügend Guthaben!";
                        }


                    }
                }
                // Falls man Auswahlfenster verlassen will
                else if (hit.collider.gameObject.name == "ExitSelectionPanel")
                {

                    // Collider wieder verfügbar machen
                    collider1.enabled = true;
                    collider2.enabled = true;
                    collider3.enabled = true;
                    collider4.enabled = true;

                    // Collider der Pflanzen wieder aktivieren
                    tomatoObj.GetComponent<Collider2D>().enabled = true;
                    carrotObj.GetComponent<Collider2D>().enabled = true;
                    cornObj.GetComponent<Collider2D>().enabled = true;
                    potatoObj.GetComponent<Collider2D>().enabled = true;
                    emptyObj.GetComponent<Collider2D>().enabled = true;
                    //Auswahlfenster deaktivieren
                    confirmPanel.SetActive(false);
                    selectionPanel.SetActive(false);
                    gameButtonsPanel.SetActive(true);
                }
            }
        }

        // Gehe in den Erntebereich sobald alle Felder bepflanzt worden sind
        if (field1.fieldIsChecked && field2.fieldIsChecked && field3.fieldIsChecked && field4.fieldIsChecked)
        {
            step5.SetActive(false);
            step5Open = false;
            step6.SetActive(true);
            step6Open = true;
            harvestPanel.SetActive(true);
            gameButtonsPanel.SetActive(false);

            field1.fieldIsChecked = false;
            field2.fieldIsChecked = false;
            field3.fieldIsChecked = false;
            field4.fieldIsChecked = false;

        }

        // Beende den Erntebereich sobald alle Felder geerntet worden sind
        if (field1.fieldIsHarvested && field2.fieldIsHarvested && field3.fieldIsHarvested && field4.fieldIsHarvested)
        {
            
            step7.SetActive(false);
            step7Open = false;
            if (!step8Open)
            {
                step71.SetActive(true);
                step71Open = true;
            }



            

        }


    }
    /// <summary>
    /// Bei Verlassen des 2. Schrittes, öffne den 3. Schritt
    /// </summary> 
    void TaskOnStep2()
    {
        step3.SetActive(true);
        step3Open = true;
        step2.SetActive(false);
        step2Open = false;

        collider1.enabled = true;
        collider2.enabled = true;
        collider3.enabled = true;
        collider4.enabled = true;

    }

    /// <summary>
    /// Bei Verlassen des 6. Schrittes, öffne den 7. Schritt
    /// </summary>
    void TaskOnStep6()
    {
        step6Open = false;
        step6.SetActive(false);
        step7.SetActive(true);
        step7Open = true;
        

    }

    /// <summary>
    /// Bei Verlassen des 7.1 Schrittes, öffne den 8. Schritt
    /// </summary>
    void TaskOnStep71()
    {
        harvestPanel.SetActive(false);
        balancePanels.SetActive(false);
        step71.SetActive(false);
        step71Open = false;
        step8.SetActive(true);
        step8Open = true;
        nextLevelButton.SetActive(true);
    }

    /// <summary>
    /// Bepflanzt die Felder mit der ausgewählten Pflanze.
    /// </summary>
    void TaskOnConfirm()
    {

        if (!field1.fieldIsChecked && !field2.fieldIsChecked && !field3.fieldIsChecked && !field4.fieldIsChecked)
        {
            step4.SetActive(false);
            step4Open = false;
            step5.SetActive(true);
            step5Open = true;
        }


        errorMessage.text = "";

        // Collider der Pflanzen wieder aktivieren
        tomatoObj.GetComponent<Collider2D>().enabled = true;
        carrotObj.GetComponent<Collider2D>().enabled = true;
        cornObj.GetComponent<Collider2D>().enabled = true;
        potatoObj.GetComponent<Collider2D>().enabled = true;
        emptyObj.GetComponent<Collider2D>().enabled = true;



        // Schaut nach welches Feld ausgewaehlt wurde
        switch (currentFeldId)
        {
            // Feld1 wurde ausgewaehlt
            case 1:
                // Pflanzennamen des Feldes auf den Namen der Pflanze setzen
                field1.plantName = plant.name.ToString();

                field1.plant = plant.GetComponent<Plant>();

                // Zieht den Preis von dem aktuellen Geld ab
                cash.money = cash.money - price;

                // Feld wird als fertig markiert
                field1.fieldIsChecked = true;

                // Passendes Sprite wird gesetzt
                switch (field1.plantName)
                {
                    case "Tomato":
                        field1.GetComponent<SpriteRenderer>().sprite = tomato;
                        break;
                    case "Carrot":
                        field1.GetComponent<SpriteRenderer>().sprite = carrot;
                        break;
                    case "Corn":
                        field1.GetComponent<SpriteRenderer>().sprite = corn;
                        break;
                    case "Potato":
                        field1.GetComponent<SpriteRenderer>().sprite = potato;
                        break;
                    case "Empty":
                        field1.GetComponent<SpriteRenderer>().sprite = empty;
                        break;
                }
                break;

            // Siehe case 1
            case 2:
                field2.plantName = plant.name.ToString();
                field2.plant = plant.GetComponent<Plant>();
                cash.money = cash.money - price;

                field2.fieldIsChecked = true;

                switch (field2.plantName)
                {
                    case "Tomato":
                        field2.GetComponent<SpriteRenderer>().sprite = tomato;
                        break;
                    case "Carrot":
                        field2.GetComponent<SpriteRenderer>().sprite = carrot;
                        break;
                    case "Corn":
                        field2.GetComponent<SpriteRenderer>().sprite = corn;
                        break;
                    case "Potato":
                        field2.GetComponent<SpriteRenderer>().sprite = potato;
                        break;
                    case "Empty":
                        field2.GetComponent<SpriteRenderer>().sprite = empty;
                        break;
                }
                break;

            // Siehe case 1
            case 3:
                field3.plantName = plant.name.ToString();
                field3.plant = plant.GetComponent<Plant>();
                cash.money = cash.money - price;
                field3.fieldIsChecked = true;

                switch (field3.plantName)
                {
                    case "Tomato":
                        field3.GetComponent<SpriteRenderer>().sprite = tomato;
                        break;
                    case "Carrot":
                        field3.GetComponent<SpriteRenderer>().sprite = carrot;
                        break;
                    case "Corn":
                        field3.GetComponent<SpriteRenderer>().sprite = corn;
                        break;
                    case "Potato":
                        field3.GetComponent<SpriteRenderer>().sprite = potato;
                        break;
                    case "Empty":
                        field3.GetComponent<SpriteRenderer>().sprite = empty;
                        break;
                }
                break;

            // Siehe case 1
            case 4:
                field4.plantName = plant.name.ToString();
                field4.plant = plant.GetComponent<Plant>();
                cash.money = cash.money - price;
                field4.fieldIsChecked = true;

                switch (field4.plantName)
                {
                    case "Tomato":
                        field4.GetComponent<SpriteRenderer>().sprite = tomato;
                        break;
                    case "Carrot":
                        field4.GetComponent<SpriteRenderer>().sprite = carrot;
                        break;
                    case "Corn":
                        field4.GetComponent<SpriteRenderer>().sprite = corn;
                        break;
                    case "Potato":
                        field4.GetComponent<SpriteRenderer>().sprite = potato;
                        break;
                    case "Empty":
                        field4.GetComponent<SpriteRenderer>().sprite = empty;
                        break;
                }
                break;
            default:
                break;
        }


        // Collider der Felder wieder verfügbar machen
        collider1.enabled = true;
        collider2.enabled = true;
        collider3.enabled = true;
        collider4.enabled = true;

        // Auswahlfenster deaktivieren und Buttons aktivieren
        confirmPanel.SetActive(false);
        selectionPanel.SetActive(false);
        gameButtonsPanel.SetActive(true);

    }

    /// <summary>
    /// Öffnet das SelectionPanel wieder.
    /// </summary>
    void TaskOnReject()
    {
        errorMessage.text = "";
        // Collider der Pflanzen wieder aktivieren
        tomatoObj.GetComponent<Collider2D>().enabled = true;
        carrotObj.GetComponent<Collider2D>().enabled = true;
        cornObj.GetComponent<Collider2D>().enabled = true;
        potatoObj.GetComponent<Collider2D>().enabled = true;
        emptyObj.GetComponent<Collider2D>().enabled = true;

        confirmPanel.SetActive(false);

    }
}

