﻿using System.Collections;
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
    public Money cash;
    public Sprite tomato;
    public Sprite potato;
    public Sprite corn;
    public Sprite carrot;
    RaycastHit2D hit;
    Collider2D collider1;
    Collider2D collider2;
    Collider2D collider3;
    Collider2D collider4;

    public GameObject selectionPanel;
  

    // Use this for initialization
    void Start()
    {
        //make SelectionPanel invisible
        selectionPanel.SetActive(false);

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
                if(hit.collider.gameObject.tag == "Feld" )
                {
                    //Zeigt das Auswahlfenster an, nachdem ein Feld ausgewählt wurde
                    selectionPanel.SetActive(true);

                    //setzt currentFeldID auf die ID des ausgewhählten Feldes
                    currentFeldId = hit.collider.gameObject.GetComponent<Feld>().id;
                    
                }
                //Falls der Collider, welcher getroffen wurde, der Collider einer Pflanze ist
                else if (hit.collider.gameObject.tag == "Pflanze")
                {
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

                            //Deaktiviert das Feld nachdem eine Pflanze ausgewählt wurde                            
                            collider1.enabled = false;
                            
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
                            }
                            break;
                        //siehe case 1
                        case 2:
                            feld2.plantName = hit.collider.gameObject.name.ToString();
                            cash.money = cash.money - price;
                            collider2.enabled = false;
                            
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
                            }
                            break;
                        //siehe case 1
                        case 3:
                            feld3.plantName = hit.collider.gameObject.name.ToString();
                            cash.money = cash.money - price;
                            collider3.enabled = false;
                            
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
                            }
                            break;
                        //siehe case 1
                        case 4:
                            feld4.plantName = hit.collider.gameObject.name.ToString();
                            cash.money = cash.money - price;                      
                            collider4.enabled = false;
                            
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
                            }
                            break;
                        default: print("Fehler");
                            break;
                    }

                    //Auswahlfenster deaktivieren
                    selectionPanel.SetActive(false);
                }

            }
            /*else
            {
                print("kein Collider erkannt");
            }*/

                        

        }


    }
}
