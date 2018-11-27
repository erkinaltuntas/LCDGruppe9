using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AdventureScript : MonoBehaviour
{

    public Vector3 mousePos;
    public Vector3 mousePosWorld;
    public Camera mainCamera;
    public Vector2 mousePosWorld2D;
    public Feld feld1, feld2, feld3, feld4;
    public int currentFeldId;
    public int price;
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
    bool feld1Checked, feld2Checked, feld3Checked, feld4Checked;
    public GameObject nextLevelButton, HelpButton, WeatherButton;
    public GameObject selectionPanel;
    public TextMeshProUGUI errorMessage;
    public Button ExitSelectionPanelButton;


    // Use this for initialization
    void Start()
    {
        //make SelectionPanel invisible
        selectionPanel.SetActive(false);
        ExitSelectionPanelButton = selectionPanel.GetComponent<Button>();
        errorMessage.text = "";
        

        //Collider holen
        collider1 = feld1.GetComponent<Collider2D>();
        collider2 = feld2.GetComponent<Collider2D>();
        collider3 = feld3.GetComponent<Collider2D>();
        collider4 = feld4.GetComponent<Collider2D>();
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
                    HelpButton.SetActive(false);
                    WeatherButton.SetActive(false);

                    



                    //setzt currentFeldID auf die ID des ausgewhählten Feldes
                    currentFeldId = hit.collider.gameObject.GetComponent<Feld>().id;
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

                        //Schaut nach welches Feld ausgewaehlt wurde
                        switch (currentFeldId)
                        {
                            //Feld1 wurde ausgewaehlt
                            case 1:
                                //Pflanzennamen des Feldes auf den Namen der Pflanze setzen
                                feld1.plantName = hit.collider.gameObject.name.ToString();

                                //Zieht den Preis von dem aktuellen Geld ab
                                cash.money = cash.money - price;

                                //Feld wird als fertig markiert
                                feld1Checked = true;

                                //Passendes Sprite wird gesetzt
                                switch (feld1.plantName)
                                {
                                    case "Tomato":
                                        feld1.GetComponent<SpriteRenderer>().sprite = tomato;
                                        break;
                                    case "Carrot":
                                        feld1.GetComponent<SpriteRenderer>().sprite = carrot;
                                        break;
                                    case "Corn":
                                        feld1.GetComponent<SpriteRenderer>().sprite = corn;
                                        break;
                                    case "Potato":
                                        feld1.GetComponent<SpriteRenderer>().sprite = potato;
                                        break;
                                    case "Empty":
                                        feld1.GetComponent<SpriteRenderer>().sprite = empty;
                                        break;
                                }
                                break;
                            //siehe case 1
                            case 2:
                                feld2.plantName = hit.collider.gameObject.name.ToString();
                                cash.money = cash.money - price;

                                feld2Checked = true;

                                switch (feld2.plantName)
                                {
                                    case "Tomato":
                                        feld2.GetComponent<SpriteRenderer>().sprite = tomato;
                                        break;
                                    case "Carrot":
                                        feld2.GetComponent<SpriteRenderer>().sprite = carrot;
                                        break;
                                    case "Corn":
                                        feld2.GetComponent<SpriteRenderer>().sprite = corn;
                                        break;
                                    case "Potato":
                                        feld2.GetComponent<SpriteRenderer>().sprite = potato;
                                        break;
                                    case "Empty":
                                        feld2.GetComponent<SpriteRenderer>().sprite = empty;
                                        break;
                                }
                                break;

                            //siehe case 1
                            case 3:
                                feld3.plantName = hit.collider.gameObject.name.ToString();
                                cash.money = cash.money - price;
                                feld3Checked = true;

                                switch (feld3.plantName)
                                {
                                    case "Tomato":
                                        feld3.GetComponent<SpriteRenderer>().sprite = tomato;
                                        break;
                                    case "Carrot":
                                        feld3.GetComponent<SpriteRenderer>().sprite = carrot;
                                        break;
                                    case "Corn":
                                        feld3.GetComponent<SpriteRenderer>().sprite = corn;
                                        break;
                                    case "Potato":
                                        feld3.GetComponent<SpriteRenderer>().sprite = potato;
                                        break;
                                    case "Empty":
                                        feld3.GetComponent<SpriteRenderer>().sprite = empty;
                                        break;
                                }
                                break;
                            //siehe case 1
                            case 4:
                                feld4.plantName = hit.collider.gameObject.name.ToString();
                                cash.money = cash.money - price;
                                feld4Checked = true;

                                switch (feld4.plantName)
                                {
                                    case "Tomato":
                                        feld4.GetComponent<SpriteRenderer>().sprite = tomato;
                                        break;
                                    case "Carrot":
                                        feld4.GetComponent<SpriteRenderer>().sprite = carrot;
                                        break;
                                    case "Corn":
                                        feld4.GetComponent<SpriteRenderer>().sprite = corn;
                                        break;
                                    case "Potato":
                                        feld4.GetComponent<SpriteRenderer>().sprite = potato;
                                        break;
                                    case "Empty":
                                        feld4.GetComponent<SpriteRenderer>().sprite = empty;
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
                    HelpButton.SetActive(true);
                    WeatherButton.SetActive(true);
                    }
                    else
                    {
                        errorMessage.text = "Sie haben nicht genügend Guthaben!";
                    }
                }
                else if(hit.collider.gameObject.name == "ExitSelectionPanel")
                {

                    //Collider wieder verfügbar machen
                    collider1.enabled = true;
                    collider2.enabled = true;
                    collider3.enabled = true;
                    collider4.enabled = true;

                    //Auswahlfenster deaktivieren
                    selectionPanel.SetActive(false);
                    HelpButton.SetActive(true);
                    WeatherButton.SetActive(true);
                }
            }
            
            /*else
            {
                print("kein Collider erkannt");
            }*/
        }

        if(feld1Checked && feld2Checked && feld3Checked && feld4Checked)
        {
            nextLevelButton.SetActive(true);
            HelpButton.SetActive(false);
            WeatherButton.SetActive(false);
        }
        

    }
}
