using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Harvest : MonoBehaviour {

    public Field field;
    public Plant plant;
    public Button button;
    public double profit;
    public Sprite empty;
    public Money cash;
    double missHarvestQuota;
    public GameObject balancePanel;
    public TextMeshProUGUI balanceMessage;


    // Use this for initialization
    void Start () {
        button.onClick.AddListener(TaskOnClick);
        plant = field.GetComponent<Field>().plant;
        missHarvestQuota = 1;

        
    }
	
	// Update is called once per frame
	void Update () {
       
    }

    void TaskOnClick()
    {
        profit = getRandomProfit();
        cash.money = cash.money + profit;
        field.GetComponent<SpriteRenderer>().sprite = empty;
        field.fieldIsHarvested = true;
        //make BalancePanel visible
        balancePanel.SetActive(true);
        balanceMessage.text = "Verlust durch Frost:" + Environment.NewLine + missHarvestQuota + "%";
    }



    double getRandomProfit()
    {
        int random3 = UnityEngine.Random.Range(0, 3);
        int random5 = UnityEngine.Random.Range(0, 2);
        if (random3 == 0)
        {
            missHarvestQuota = 0.25;
        }
        else if(random3 == 1)
        {
            missHarvestQuota = 0.5;
        }
        else if(random3 == 2)
        {
            missHarvestQuota = 0.75;
        }
        //falls Pflanze sowohl von Frost als auch von Dürre betroffen, wähle ein zufälliges davon
        if (plant.droughted && plant.frosted)
        {
            if(random5 == 0)
            {
                plant.droughted = false;
            }
            else if (random5 == 1)
            {
                plant.frosted = false;
            }
            Debug.Log("von Dürre betroffen:" + plant.droughted + "von Frost betroffen:" + plant.frosted);
            return plant.profit - (plant.profit * missHarvestQuota);
        }
        else if(plant.droughted || plant.frosted)
        {
            Debug.Log("von Dürre betroffen:" + plant.droughted + "von Frost betroffen:" + plant.frosted);
            return plant.profit - (plant.profit * missHarvestQuota);
        }

        Debug.Log("von Dürre betroffen:" + plant.droughted + "von Frost betroffen:" + plant.frosted);
        return plant.profit;
    }
}
