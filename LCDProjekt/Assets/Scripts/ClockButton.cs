using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockButton : MonoBehaviour {

    public Button harvestButton;
    public GameObject clock;
    public GameObject background;
    public Animation clockAnimation;

	// Use this for initialization
	void Start () {

        harvestButton.onClick.AddListener(TaskOnClick);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void TaskOnClick()
    {
        clock.SetActive(true);
        background.SetActive(true);
        clockAnimation.Play("Clock");
        

    }

    public void ClockAnimationEnd()
    {
        
            clock.SetActive(false);
            background.SetActive(false);
        
    }
}
