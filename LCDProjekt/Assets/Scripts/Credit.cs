/*************************************************************************** 
* Credit
* Anwendung: Zur Steuerung des Spielablaufs
* ------------------- 
* Zuletzt bearbeitet von: Cedric Meyer-Piening
* Datum der letzten Bearbeitung: 8.1.2019
* Grund für letzte Bearbeitung: Kommentare
**************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Gewährt einmal pro Jahreszeit einen Kredit, wenn man zu wenig Geld für eine Aktion hat.
/// </summary>
public class Credit : MonoBehaviour {
    public bool accepted;
    public bool shown;
    public Button acceptButton, rejectButton;
    public Player player;
    public Field field1, field2, field3, field4; 
    public GameObject creditPanel, gameButtonsPanel, selectionPanel, shockPanel;
    public Money money;
    public GameObject tomatoObj;
    public GameObject potatoObj;
    public GameObject cornObj;
    public GameObject carrotObj;
    public GameObject emptyObj;
    GameObject weather;
    string seasonName;
    

    /// <summary>
    /// Initialisiert die benötigten Objekte und öffnet das CreditPanel.
    /// </summary>
    // Use this for initialization
    void Start () {
        creditPanel = this.gameObject;
        player = Player.player;
        shown = true;
        // Steuert, dass der Kredit in jeder Jahreszeit max. 1x angezeigt werden kann
        //player.creditShown = true;

        // Weise den Buttons die Methoden zu
        acceptButton.onClick.AddListener(TaskOnAccept);
        rejectButton.onClick.AddListener(TaskOnReject);
        
        // Deaktivere alle interaktiven Objekten
        field1.GetComponent<Collider2D>().enabled = false;
        field2.GetComponent<Collider2D>().enabled = false;
        field3.GetComponent<Collider2D>().enabled = false;
        field4.GetComponent<Collider2D>().enabled = false;
        gameButtonsPanel.SetActive(false);
        selectionPanel.SetActive(false);

        player.creditShown = true;

        weather = GameObject.Find("Weather");
        seasonName = weather.GetComponent<Weather>().seasonName;

        // Fix, damit nach dem Kredit nicht die alte Beschreibung nochmal auftaucht
        tomatoObj.GetComponent<DisplayDescription>().displayInfo = false;
        cornObj.GetComponent<DisplayDescription>().displayInfo = false;
        potatoObj.GetComponent<DisplayDescription>().displayInfo = false;
        carrotObj.GetComponent<DisplayDescription>().displayInfo = false;
        emptyObj.GetComponent<DisplayDescription>().displayInfo = false;
    }

    /// <summary>
    /// Erhöht den Kontostand, wenn man das Geld annimmt.
    /// </summary>
    void TaskOnAccept()
    {
        // Erhöhe das Geld um 1000, Aktivere wieder interaktive Objekte, schliesse das Fenster
        accepted = true;
        money.money += 1000;
        Player.player.timeLoan++;
        field1.GetComponent<Collider2D>().enabled = true;
        field2.GetComponent<Collider2D>().enabled = true;
        field3.GetComponent<Collider2D>().enabled = true;
        field4.GetComponent<Collider2D>().enabled = true;
        gameButtonsPanel.SetActive(true);
        creditPanel.SetActive(false);

        if(seasonName == "Sommer") {
            if (shockPanel.GetComponent<Shock>().comingFromNegativeShock)
            {
                shockPanel.SetActive(true);
            }
        }
        
    }

    /// <summary>
    /// Schließt das CreditPanel wieder.
    /// </summary>
    void TaskOnReject()
    {
        // Aktivere wieder interaktive Objekte, schliesse das Fenster
        accepted = false;
        field1.GetComponent<Collider2D>().enabled = true;
        field2.GetComponent<Collider2D>().enabled = true;
        field3.GetComponent<Collider2D>().enabled = true;
        field4.GetComponent<Collider2D>().enabled = true;
        gameButtonsPanel.SetActive(true);
        creditPanel.SetActive(false);

        if (seasonName == "Sommer")
        {
            if (shockPanel.GetComponent<Shock>().comingFromNegativeShock)
            {
                shockPanel.SetActive(true);
            }
        }
    }
}
