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
    bool field1Checked, field2Checked, field3Checked, field4Checked;
    public GameObject helpButton, weatherButton, nextLevelButton;
    public GameObject selectionPanel, harvestPanel, weatherPanel;
    public TextMeshProUGUI errorMessage;
    public GameObject tomatoObj;
    public GameObject potatoObj;
    public GameObject cornObj;
    public GameObject carrotObj;
    public GameObject emptyObj;


    // Use this for initialization
    void Start()
    {
        player = Player.player;

        weatherPanel.SetActive(true);
        //make SelectionPanel invisible
        selectionPanel.SetActive(false);
        errorMessage.text = "";

        //Collider holen
        collider1 = field1.GetComponent<Collider2D>();
        collider2 = field2.GetComponent<Collider2D>();
        collider3 = field3.GetComponent<Collider2D>();
        collider4 = field4.GetComponent<Collider2D>();

        //Collider beim Start deaktivieren
        collider1.enabled = false;
        collider2.enabled = false;
        collider3.enabled = false;
        collider4.enabled = false;

        //Button beim Start deaktivieren
        weatherButton.SetActive(false);
        helpButton.SetActive(false);

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //print("Maus wurde gedrückt");

            //Mausposition
            mousePos = Input.mousePosition;
            print(mousePos);

            //Mausposition World
            mousePosWorld = mainCamera.ScreenToWorldPoint(mousePos);
            //In zweidim Vektor umwandeln
            mousePosWorld2D = new Vector2(mousePosWorld.x, mousePosWorld.y);

            //Raycast2d
            hit = Physics2D.Raycast(mousePosWorld2D, Vector2.zero);

            //prüfe ob hit einen collider beinhaltet
            if (hit.collider != null)
            {
                //print("Objekt mit Collider getroffen");

                //Ausgabe des getroffenen Objects
                print(hit.collider.gameObject.name);

                //Falls der Collider, welcher getroffen wurde, der Collider eines Feldes ist
                if (hit.collider.gameObject.tag == "Feld")
                {
                    //Zeigt das Auswahlfenster an, nachdem ein Feld ausgewählt wurde
                    selectionPanel.SetActive(true);

                    ////
                    helpButton.SetActive(false);
                    weatherButton.SetActive(false);





                    //setzt currentFeldID auf die ID des ausgewhählten Feldes
                    currentFeldId = hit.collider.gameObject.GetComponent<Field>().id;
                    collider1.enabled = false;
                    collider2.enabled = false;
                    collider3.enabled = false;
                    collider4.enabled = false;

                }
                //Falls der Collider, welcher getroffen wurde, der Collider einer Pflanze ist
                else if (hit.collider.gameObject.tag == "Pflanze")
                {
                    if (cash.money >= hit.collider.gameObject.GetComponent<Plant>().price)
                    {
                        errorMessage.text = "";

                        //Setzt den Preis (price) auf den Preis der gewaehlten Pflanze
                        price = hit.collider.gameObject.GetComponent<Plant>().price;

                        //Anzeigefenster mit Details ausblenden beim Öffnen des SelectionPanels
                        tomatoObj.GetComponent<DisplayDescription>().displayInfo = false;
                        potatoObj.GetComponent<DisplayDescription>().displayInfo = false;
                        cornObj.GetComponent<DisplayDescription>().displayInfo = false;
                        carrotObj.GetComponent<DisplayDescription>().displayInfo = false;
                        emptyObj.GetComponent<DisplayDescription>().displayInfo = false;

                        //Schaut nach welches Feld ausgewaehlt wurde
                        switch (currentFeldId)
                        {
                            //Feld1 wurde ausgewaehlt
                            case 1:
                                //Pflanzennamen des Feldes auf den Namen der Pflanze setzen
                                field1.plantName = hit.collider.gameObject.name.ToString();

                                field1.plant = hit.collider.gameObject.GetComponent<Plant>();

                                //Zieht den Preis von dem aktuellen Geld ab
                                cash.money = cash.money - price;

                                //Feld wird als fertig markiert
                                field1Checked = true;

                                //Passendes Sprite wird gesetzt
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
                            //siehe case 1
                            case 2:
                                field2.plantName = hit.collider.gameObject.name.ToString();
                                field2.plant = hit.collider.gameObject.GetComponent<Plant>();
                                cash.money = cash.money - price;

                                field2Checked = true;

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

                            //siehe case 1
                            case 3:
                                field3.plantName = hit.collider.gameObject.name.ToString();
                                field3.plant = hit.collider.gameObject.GetComponent<Plant>();
                                cash.money = cash.money - price;
                                field3Checked = true;

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
                            //siehe case 1
                            case 4:
                                field4.plantName = hit.collider.gameObject.name.ToString();
                                field4.plant = hit.collider.gameObject.GetComponent<Plant>();
                                cash.money = cash.money - price;
                                field4Checked = true;

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


                        //Collider wieder verfügbar machen
                        collider1.enabled = true;
                        collider2.enabled = true;
                        collider3.enabled = true;
                        collider4.enabled = true;

                        //Auswahlfenster deaktivieren
                        selectionPanel.SetActive(false);
                        helpButton.SetActive(true);
                        weatherButton.SetActive(true);
                    }
                    else
                    {
                        errorMessage.text = "Sie haben nicht genügend Guthaben!";
                    }
                }
                else if (hit.collider.gameObject.name == "ExitSelectionPanel")
                {

                    //Collider wieder verfügbar machen
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

        if (field1Checked && field2Checked && field3Checked && field4Checked)
        {
            harvestPanel.SetActive(true);
            helpButton.SetActive(false);
            weatherButton.SetActive(false);
        }

        if (field1.fieldIsHarvested && field2.fieldIsHarvested && field3.fieldIsHarvested && field4.fieldIsHarvested)
        {
            harvestPanel.SetActive(false);
            nextLevelButton.SetActive(true);
        }


    }
}
