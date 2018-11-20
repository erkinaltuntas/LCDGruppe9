using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureScript : MonoBehaviour {

    public Vector3 mousePos;
    public Vector3 mousePosWorld;
    public Camera mainCamera;
    public Vector2 mousePosWorld2D;
    public Feld feld1;
    public Feld feld2;
    public Feld feld3;
    public Feld feld4;
    public int currentFeldId;
    public int price;
    public Player player;
    public Money money;
    RaycastHit2D hit;

    public GameObject selectionPanel;
  

    // Use this for initialization
    void Start()
    {
        //make SelectionPanel invisible
        selectionPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("Maus wurde gedrückt");

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
                print("Objekt mit Collider getroffen");
                //Ausgabe des getroffenen Objects
                print(hit.collider.gameObject.name);

                if(hit.collider.gameObject.tag == "Feld" )
                {
                    selectionPanel.SetActive(true);
                    currentFeldId = hit.collider.gameObject.GetComponent<Feld>().id;
                } else if (hit.collider.gameObject.tag == "Pflanze")
                {
                    price = hit.collider.gameObject.GetComponent<Plant>().price;
                    switch (currentFeldId)
                    {
                        case 1:
                            feld1.plantName = hit.collider.gameObject.name.ToString();
                            money.money = money.money - price;
                            break;
                        case 2:
                            feld2.plantName = hit.collider.gameObject.name.ToString();
                            money.money = money.money - price;
                            break;
                        case 3:
                            feld3.plantName = hit.collider.gameObject.name.ToString();
                            money.money = money.money - price;
                            break;
                        case 4:
                            feld4.plantName = hit.collider.gameObject.name.ToString();
                            money.money = money.money - price;
                            break;
                        default: print("Fehler");
                            break;
                    }

                    selectionPanel.SetActive(false);
                }

            }
            else
            {
                print("kein Collider erkannt");
            }
        }


    }
}
