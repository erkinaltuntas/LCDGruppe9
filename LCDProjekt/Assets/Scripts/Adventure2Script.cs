/*************************************************************************** 
* Adventure2Script
* Anwendung: Zur Steuerung des Spielablaufs
* ------------------- 
* Zuletzt bearbeitet von: Erkin Altuntas
* Datum der letzten Bearbeitung: 10.12.2018
* Grund für letzte Bearbeitung: Kommentare/Code Pflege
**************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    public GameObject helpButton, weatherButton, nextLevelButton;
    public GameObject selectionPanel, harvestPanel, weatherPanel;
    public TextMeshProUGUI errorMessage;
    public GameObject tomatoObj;
    public GameObject potatoObj;
    public GameObject cornObj;
    public GameObject carrotObj;
    public GameObject emptyObj;


    // Use this for initialization
    void Start() {
        player = Player.player;

        // Zu Beginn des Spiels Wetteranzeige aktivieren, andere Objekte deaktivieren
        weatherPanel.SetActive(true);
        selectionPanel.SetActive(false);
        errorMessage.text = "";
        weatherButton.SetActive(false);
        helpButton.SetActive(false);

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

    }


    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            // Mausposition definieren
            mousePos = Input.mousePosition;
            print(mousePos);

            // Mausposition World
            mousePosWorld = mainCamera.ScreenToWorldPoint(mousePos);
            // In zweidim Vektor umwandeln
            mousePosWorld2D = new Vector2(mousePosWorld.x, mousePosWorld.y);

            // Bestimmte Punkt des Mausklicks
            hit = Physics2D.Raycast(mousePosWorld2D, Vector2.zero);

            // Prüfe ob hit einen collider beinhaltet
            if (hit.collider != null)
            {
                print(hit.collider.gameObject.name);

                // Falls der Collider, welcher getroffen wurde, der Collider eines Feldes ist, zeige das Auswahlfenster an
                if (hit.collider.gameObject.tag == "Feld")
                {
                    selectionPanel.SetActive(true);
                    helpButton.SetActive(false);
                    weatherButton.SetActive(false);


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
                    if (cash.money >= hit.collider.gameObject.GetComponent<Plant>().price)
                    {
                        errorMessage.text = "";

                        // Bestimmte Preis der Pflanze
                        price = hit.collider.gameObject.GetComponent<Plant>().price;

                        // Anzeigefenster mit Details ausblenden beim Öffnen des SelectionPanels
                        tomatoObj.GetComponent<DisplayDescription>().displayInfo = false;
                        potatoObj.GetComponent<DisplayDescription>().displayInfo = false;
                        cornObj.GetComponent<DisplayDescription>().displayInfo = false;
                        carrotObj.GetComponent<DisplayDescription>().displayInfo = false;
                        emptyObj.GetComponent<DisplayDescription>().displayInfo = false;

                        // Schaut nach welches Feld ausgewaehlt wurde
                        switch (currentFeldId)
                        {
                            // Feld1 wurde ausgewaehlt
                            case 1:
                                // Pflanzennamen des Feldes auf den Namen der Pflanze setzen
                                field1.plantName = hit.collider.gameObject.name.ToString();

                                field1.plant = hit.collider.gameObject.GetComponent<Plant>();

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
                                field2.plantName = hit.collider.gameObject.name.ToString();
                                field2.plant = hit.collider.gameObject.GetComponent<Plant>();
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
                                field3.plantName = hit.collider.gameObject.name.ToString();
                                field3.plant = hit.collider.gameObject.GetComponent<Plant>();
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
                                field4.plantName = hit.collider.gameObject.name.ToString();
                                field4.plant = hit.collider.gameObject.GetComponent<Plant>();
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
                        selectionPanel.SetActive(false);
                        helpButton.SetActive(true);
                        weatherButton.SetActive(true);
                    }
                    // Falls man nicht genuegend Geld hat
                    else
                    {
                        errorMessage.text = "Sie haben nicht genügend Guthaben!";
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

                    //Auswahlfenster deaktivieren
                    selectionPanel.SetActive(false);
                    helpButton.SetActive(true);
                    weatherButton.SetActive(true);
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
            helpButton.SetActive(false);
            weatherButton.SetActive(false);
        }

        // Beende den Erntebereich sobald alle Felder geerntet worden sind
        if (field1.fieldIsHarvested && field2.fieldIsHarvested && field3.fieldIsHarvested && field4.fieldIsHarvested)
        {
            harvestPanel.SetActive(false);
            nextLevelButton.SetActive(true);
           
        }


    }
}
