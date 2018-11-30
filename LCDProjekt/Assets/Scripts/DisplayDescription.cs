using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayDescription : MonoBehaviour {
    public string myString;
    public TextMeshProUGUI description;
    public float fadeTime;
    public bool displayInfo;

	// Use this for initialization
	void Start () {

        description = this.gameObject.GetComponentInChildren<TextMeshProUGUI>();
        description.color = Color.clear;
	}
	
	// Update is called once per frame
	void Update () {
        FadeText();
        
	}

    void OnMouseOver()
    {
        displayInfo = true;
    }

    void OnMouseExit()
    {
        displayInfo = false;
    }

    void FadeText()
    {
        if (displayInfo)
        {
            description.text = myString;
            description.color = Color.Lerp(description.color, Color.white, fadeTime * Time.deltaTime);

        }
        else
        {
            description.color = Color.Lerp(description.color, Color.clear, fadeTime * Time.deltaTime);
        }
    }
}
