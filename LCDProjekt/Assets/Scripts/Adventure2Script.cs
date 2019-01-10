/*************************************************************************** 
* Adventure2Script
* Anwendung: Zur Steuerung des Spielablaufs
* ------------------- 
* Zuletzt bearbeitet von: Erkin Altuntas
* Datum der letzten Bearbeitung: 8.1.2019
* Grund für letzte Bearbeitung: Bestätigungsdialog
**************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Adventure2Script : MonoBehaviour {


    public Vector3 mousePos;
    public Vector3 mousePosWorld;
    public Camera mainCamera;
    public Vector2 mousePosWorld2D;
    public Field field1, field2, field3, field4;
    public int currentFeldId;
    public double price;
    public Player player;
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
    public GameObject gameButtonsPanel, selectionPanel, harvestPanel, weatherPanel, creditPanel, confirmPanel;
    public Text errorMessage;
    public GameObject tomatoObj;
    public GameObject potatoObj;
    public GameObject cornObj;
    public GameObject carrotObj;
    public GameObject emptyObj;
    public GameObject weather;
    public Button confirmButton, rejectButton;
    private Plant plant;
        
    // Use this for initialization
    void Start() {
        player = Player.player;

        weather = GameObject.Find("Weather");
        

        // Zu Beginn des Spiels Wetteranzeige aktivieren, andere Objekte deaktivieren
        weatherPanel.SetActive(true);
        selectionPanel.SetActive(false);
        errorMessage.text = "";
        gameButtonsPanel.SetActive(false);
        

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


    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            
            // Mausposition definieren
            mousePos = Input.mousePosition;
            //print(mousePos);

            // Mausposition World
            mousePosWorld = mainCamera.ScreenToWorldPoint(mousePos);
            // In zweidim Vektor umwandeln
            mousePosWorld2D = new Vector2(mousePosWorld.x, mousePosWorld.y);

            // Bestimmte Punkt des Mausklicks
            hit = Physics2D.Raycast(mousePosWorld2D, Vector2.zero);

            // Prüfe ob hit einen collider beinhaltet
            if (hit.collider != null)
            {
                //print(hit.collider.gameObject.name);

                // Falls der Collider, welcher getroffen wurde, der Collider eines Feldes ist, zeige das Auswahlfenster an
                if (hit.collider.gameObject.tag == "Feld")
                {
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
                        else if(plant.plantName == "Carrot")
                        {
                            confirmPanel.GetComponentInChildren<Text>().text = Environment.NewLine + "Möchtest du wirklich Karotten anbauen?" + Environment.NewLine + Environment.NewLine;
                        }
                        else if (plant.plantName == "Corn")
                        {
                            confirmPanel.GetComponentInChildren<Text>().text = Environment.NewLine + "Möchtest du wirklich Mais anbauen?" + Environment.NewLine + Environment.NewLine;
                        }
                        else if (plant.plantName == "Potato")
                        {
                            confirmPanel.GetComponentInChildren<Text>().text = Environment.NewLine + "Möchtest du wirklich Kartoffeln anbauen?" + Environment.NewLine + Environment.NewLine;
                        }
                        else if (plant.plantName == "Empty")
                        {
                            confirmPanel.GetComponentInChildren<Text>().text = Environment.NewLine + "Möchtest du wirklich nichts anbauen?" + Environment.NewLine + Environment.NewLine;
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
                            errorMessage.text = "Du hast nicht genügend Guthaben!";
                            
                        }
                        
                        
                    }
                }
                // Falls man Auswahlfenster verlassen will
                else if (hit.collider.gameObject.name == "ExitSelectionPanel")
                {
                    errorMessage.text = "";
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

            /*else
            {
                print("kein Collider erkannt");
            }*/
        }

        // Gehe in den Erntebereich sobald alle Felder bepflanzt worden sind
        if (field1.fieldIsChecked && field2.fieldIsChecked && field3.fieldIsChecked && field4.fieldIsChecked)
        {
            harvestPanel.SetActive(true);
            gameButtonsPanel.SetActive(false);
            
        }

        // Beende den Erntebereich sobald alle Felder geerntet worden sind
        if (field1.fieldIsHarvested && field2.fieldIsHarvested && field3.fieldIsHarvested && field4.fieldIsHarvested)
        {
            harvestPanel.SetActive(false);
            nextLevelButton.SetActive(true);
           
        }


    }

    void TaskOnConfirm()
    {
        // Collider der Pflanzen wieder aktivieren
        tomatoObj.GetComponent<Collider2D>().enabled = true;
        carrotObj.GetComponent<Collider2D>().enabled = true;
        cornObj.GetComponent<Collider2D>().enabled = true;
        potatoObj.GetComponent<Collider2D>().enabled = true;
        emptyObj.GetComponent<Collider2D>().enabled = true;

        errorMessage.text = "";
        // Fügt die Entscheidung zur RisikoList hinzu, falls nicht leer gewählt worden ist
        if (price != 0)
        {
            player.riskScores[player.riskIndex] = player.calculateRiskPlant(plant, weather.GetComponent<Weather>());

        }
        else
        {
            player.riskScores[player.riskIndex] = 0;
        }
        player.riskIndex++; ;

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
                print("Fehler");
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
