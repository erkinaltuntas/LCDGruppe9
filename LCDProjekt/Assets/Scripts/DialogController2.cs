/*************************************************************************** 
* DialogController2
* Anwendung: Zur Steuerung des Dialogs in der Einfuehrungsstory
* (zweite Sprechblase)
* ------------------- 
* Zuletzt bearbeitet von: Erkin Altuntas
* Datum der letzten Bearbeitung: 10.12.2018
* Grund für letzte Bearbeitung: Kommentare/Code Pflege
**************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController2 : MonoBehaviour {
    public float delay = 0.005f;
    private string fullText1 = "Die Farm… Sie ist unser kostbarster Besitz…" + Environment.NewLine + Environment.NewLine + 
        "Und jetzt gehört sie dir!" + Environment.NewLine + Environment.NewLine + 
        "Wir trennen uns wirklich nur schweren Herzens von unserem Hof, aber wir wissen, dass du ihn würdig und profitabel fortführen wirst..";
    private string currentText = "";

    // Use this for initialization
    void Start() {
        StartCoroutine(ShowText());
    }

    private IEnumerator ShowText()
    {
        for(int i=0; i<fullText1.Length; i++)
        {
            currentText = fullText1.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }

    }


}
