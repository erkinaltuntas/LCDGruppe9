/*************************************************************************** 
* Credit
* Anwendung: Zur Steuerung des Spielablaufs
* ------------------- 
* Zuletzt bearbeitet von: Erkin Altuntas
* Datum der letzten Bearbeitung: 18.12.2018
* Grund für letzte Bearbeitung: Erstellung
**************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Credit : MonoBehaviour {
    public bool accepted;
    public bool shown;
    public Button acceptButton;
    public Button refuseButton;
    public Player player;
    
    public Field field1, field2, field3, field4;
    public GameObject creditPanel, gameButtonsPanel, selectionPanel;
    public Money money;


    // Use this for initialization
    void Start () {
        creditPanel = this.gameObject;
        player = Player.player;
        player.creditShown = true;
        // Weise den Buttons die Methoden zu
        acceptButton.onClick.AddListener(TaskOnAccept);
        refuseButton.onClick.AddListener(TaskOnRefuse);
        // Weise die Felder zu
        // Deaktivere die Collider der Felder
        field1.GetComponent<Collider2D>().enabled = false;
        field2.GetComponent<Collider2D>().enabled = false;
        field3.GetComponent<Collider2D>().enabled = false;
        field4.GetComponent<Collider2D>().enabled = false;

        gameButtonsPanel.SetActive(false);
        selectionPanel.SetActive(false);

       

        //
    }

    void TaskOnAccept()
    {
        accepted = true;
        money.money += 1000;
        field1.GetComponent<Collider2D>().enabled = true;
        field2.GetComponent<Collider2D>().enabled = true;
        field3.GetComponent<Collider2D>().enabled = true;
        field4.GetComponent<Collider2D>().enabled = true;
        gameButtonsPanel.SetActive(true);
        creditPanel.SetActive(false);
    }
    void TaskOnRefuse()
    {
        accepted = false;
        field1.GetComponent<Collider2D>().enabled = true;
        field2.GetComponent<Collider2D>().enabled = true;
        field3.GetComponent<Collider2D>().enabled = true;
        field4.GetComponent<Collider2D>().enabled = true;
        gameButtonsPanel.SetActive(true);
        creditPanel.SetActive(false);
    }
}
