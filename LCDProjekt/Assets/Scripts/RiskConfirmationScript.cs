using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RiskConfirmationScript : MonoBehaviour {
    public Button confirmButton, rejectButton;
    public Player player;
	// Use this for initialization
	void Start () {
        confirmButton.GetComponentInChildren<Button>().onClick.AddListener(TaskOnConfirm);
        rejectButton.GetComponentInChildren<Button>().onClick.AddListener(TaskOnReject);
        player = Player.player;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void TaskOnConfirm()
    {
        player.riskConfirmed = true;

    }

    void TaskOnReject()
    {
        player.riskConfirmed = false;
    }
}
