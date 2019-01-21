/*************************************************************************** 
* Schock
* Anwendung: Steuerung der Schock-Events
* ------------------- 
* Zuletzt bearbeitet von: Thomas Wieschermann
* Datum der letzten Bearbeitung: 17.01.2019
* Grund für letzte Bearbeitung: Kommentare/Code Pflege
**************************************************************************/

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shock : MonoBehaviour {

    public Player player;
    public Button opt1Button;
    public Button opt2Button;
    public Button exitButton;
    public GameObject harvestField1Button, harvestField2Button, harvestField3Button, harvestField4Button;
    GameObject field1;
    GameObject field2;
    GameObject field3;
    GameObject field4;
    public Sprite empty;
    public GameObject shockPanel, resultPanel, creditPanel;
    GameObject weather;
    string seasonName;
    public Money cash;
    private double preventionCosts;
    public bool comingFromNegativeShock;
    public Text errorMessage;
    public Text stormMessage;
    public Sprite destroyed;


    // Use this for initialization
    void Start () {
        player = Player.player;

        weather = GameObject.Find("Weather");
        seasonName = weather.GetComponent<Weather>().seasonName;

        opt1Button.onClick.AddListener(TaskOnClickOpt1);
        opt2Button.onClick.AddListener(TaskOnClickOpt2);
        if(seasonName == "Sommer")
        {
            exitButton.onClick.AddListener(TaskOnClickExit);
        }
       

        field1 = GameObject.Find("Field 1");
        field2 = GameObject.Find("Field 2");
        field3 = GameObject.Find("Field 3");
        field4 = GameObject.Find("Field 4");
        
    }
	
	// Update is called once per frame
	void Update () {
       
    }

    void TaskOnClickOpt1()
    {
        player.choice = 1;
        preventionCosts = 250;

        //negativer Schock und Option 1
        if (seasonName == "Sommer")
        {
            // Falls man genug Geld hat fuehre die Option aus
            if(cash.money - preventionCosts >= 0)
            {
                cash.money = cash.money - preventionCosts;
                shockPanel.SetActive(false);

                resultPanel.SetActive(true);
                stormMessage.text = "Dank deiner guten Vorbereitung hat der Sturm dir nichts angetan.";
                
                
                player.riskScoreShock[0] = -0.075;
            }
            else
            {
                // Falls das Kredit in der Jahreszeit noch nicht angeboten wurde, biete es an, sonst nicht
                if (!creditPanel.GetComponent<Credit>().shown)
                {
                    comingFromNegativeShock = true;
                    shockPanel.SetActive(false);
                    creditPanel.SetActive(true);
                }
                else
                {
                    errorMessage.text = "Du hast nicht genügend Guthaben!";
                }
            }
        }
        //positiver Schock und Option 1
        if (seasonName == "Herbst")
        {
            
            player.riskScoreShock[1] = 0.075;
        }
    }

    void TaskOnClickOpt2()
    {
        player.choice = 2;
        
        //negativer Schock und Option 2
        if (seasonName == "Sommer")
        {
            int random = UnityEngine.Random.Range(0, 2);
            if (random == 1)
            {
                player.storm = true;
                resultPanel.SetActive(true);
                shockPanel.SetActive(false);
            }
            else {
                shockPanel.SetActive(false);
                resultPanel.SetActive(true);
                stormMessage.text = "Glück gehabt. Der Sturm konnte deiner Ernte nichts anhaben.";
            }
            player.riskScoreShock[0] = 0.075;
        }
        //positiver Schock und Option 2
        if (seasonName == "Herbst")
        {
            player.riskScoreShock[1] = -0.075;
        }
    }
    void TaskOnClickExit()
    {
        // bei Exit aus SturmPanel werden die Felder automatisch geerntet ohne Erträge 
        if (player.choice == 1 || player.storm == false)
        {
            resultPanel.SetActive(false);
            harvestField1Button.SetActive(true);
            harvestField2Button.SetActive(true);
            harvestField3Button.SetActive(true);
            harvestField4Button.SetActive(true);
        }
        else
        {
            field1.GetComponent<SpriteRenderer>().sprite = destroyed;
            field1.GetComponent<Field>().fieldIsHarvested = true;
            field2.GetComponent<SpriteRenderer>().sprite = destroyed;
            field2.GetComponent<Field>().fieldIsHarvested = true;
            field3.GetComponent<SpriteRenderer>().sprite = destroyed;
            field3.GetComponent<Field>().fieldIsHarvested = true;
            field4.GetComponent<SpriteRenderer>().sprite = destroyed;
            field4.GetComponent<Field>().fieldIsHarvested = true;
        }
        resultPanel.SetActive(false);
    }
}
