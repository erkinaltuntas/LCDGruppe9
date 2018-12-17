using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shock : MonoBehaviour {

    public Player player;
    public Button opt1Button;
    public Button opt2Button;
    public Button exitButton;
    GameObject field1;
    GameObject field2;
    GameObject field3;
    GameObject field4;
    public Sprite empty;
    public GameObject shockPanel, stormPanel;
    GameObject weather;
    string seasonName;
    public int choice;
    public Money cash;

    // Use this for initialization
    void Start () {
        player = Player.player;

        weather = GameObject.Find("Weather");
        seasonName = weather.GetComponent<Weather>().seasonName;

        opt1Button.onClick.AddListener(TaskOnClickOpt1);
        opt2Button.onClick.AddListener(TaskOnClickOpt2);
        exitButton.onClick.AddListener(TaskOnClickExit);

        field1 = GameObject.Find("Field 1");
        field2 = GameObject.Find("Field 2");
        field3 = GameObject.Find("Field 3");
        field4 = GameObject.Find("Field 4");

        print("Shock start");
    }
	
	// Update is called once per frame
	void Update () {
       
    }

    void TaskOnClickOpt1()
    {
        print("Task 1");
        choice = 1;
        //positiver Schock
        if (seasonName == "Sommer")
        {
            cash.money = cash.money - 250;
            print("option 1");
        }
        //negativer Schock
        if (seasonName == "Herbst")
        {
        }
    }

    void TaskOnClickOpt2()
    {
        print("Task 2");
        choice = 2;
        //positiver Schock
        if (seasonName == "Sommer")
        {
            /*int random = UnityEngine.Random.Range(0, 2);
            if (random == 1)
            {
                player.storm = true;

            }
            print("option 2");*/
            player.storm = true;
           

        }
        //negativer Schock
        if (seasonName == "Herbst")
        {
        }
    }
    void TaskOnClickExit()
    {
        field1.GetComponent<SpriteRenderer>().sprite = empty;
        field1.GetComponent<Field>().fieldIsHarvested = true;
        field2.GetComponent<SpriteRenderer>().sprite = empty;
        field2.GetComponent<Field>().fieldIsHarvested = true;
        field3.GetComponent<SpriteRenderer>().sprite = empty;
        field3.GetComponent<Field>().fieldIsHarvested = true;
        field4.GetComponent<SpriteRenderer>().sprite = empty;
        field4.GetComponent<Field>().fieldIsHarvested = true;

        stormPanel.SetActive(false);
    }
}
