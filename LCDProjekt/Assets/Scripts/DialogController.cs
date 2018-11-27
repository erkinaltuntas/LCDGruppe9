using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour {
    public float delay = 0.005f;
    public string fullText;
    private string currentText = "";

    // Use this for initialization
    void Start() {
        StartCoroutine(ShowText());
    }

    private IEnumerator ShowText()
    {
        for(int i=0; i<fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }

    }


}
