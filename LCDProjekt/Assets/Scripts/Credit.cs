using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Credit : MonoBehaviour {

    public Player player;
    public GameObject creditPanel, selectionPanel, money;
    public Button acceptButton;
    public Button denyButton;
    public bool accepted, denied;


	// Use this for initialization
    void Awake()
    {
        selectionPanel.SetActive(false);
        
    }
	void Start () {
		
        acceptButton.onClick.AddListener(TaskOnAccept);
        denyButton.onClick.AddListener(TaskOnDeny);



    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TaskOnAccept()
    {
        if (!denied)
        {
            accepted = true;
            denied = false;
            money.GetComponent<Money>().money += 1000;
            creditPanel.SetActive(false);
        }

    }

    public void TaskOnDeny()
    {
        accepted = false;
        denied = true;
        creditPanel.SetActive(false);
    }
}
