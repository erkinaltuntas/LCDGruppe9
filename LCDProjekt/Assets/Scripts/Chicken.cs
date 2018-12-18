/*************************************************************************** 
* Chicken
* Anwendung: 
* ------------------- 
* Zuletzt bearbeitet von: Erkin Altuntas
* Datum der letzten Bearbeitung: 10.12.2018
* Grund für letzte Bearbeitung: Kommentare/Code Pflege
**************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour {

    RaycastHit2D hit;
    public Vector3 mousePos;
    public Vector3 mousePosWorld;
    public Vector2 mousePosWorld2D;
    public Camera mainCamera;
    public GameObject chicken1;
    public GameObject chicken2;
    public GameObject chicken3;
    public GameObject chicken4;
    public GameObject chicken5;
    public GameObject chickenAnim;
    public Animation chickAnim;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            // Mausposition definieren
            mousePos = Input.mousePosition;
            //print(mousePos);

            //Mausposition World
            mousePosWorld = mainCamera.ScreenToWorldPoint(mousePos);
            //In zweidim Vektor umwandeln
            mousePosWorld2D = new Vector2(mousePosWorld.x, mousePosWorld.y);

            // Bestimmte Punkt des Mausklicks
            hit = Physics2D.Raycast(mousePosWorld2D, Vector2.zero);

            // Prüfe ob hit einen collider beinhaltet
            if (hit.collider != null)
            {
                // Wenn ein Huhn getroffen worden ist, aktiviere das naechste Huhn (insgesamt 4x)
                if (hit.collider.gameObject.tag == "chicken")
                {
                    if (hit.collider.name == "chicken1")
                    {
                        chicken1.SetActive(false);
                        chicken2.SetActive(true);
                        chicken1.GetComponent<Collider2D>().enabled = false;
                    }
                    else if (hit.collider.name == "chicken2")
                    {
                        chicken2.SetActive(false);
                        chicken3.SetActive(true);
                        chicken2.GetComponent<Collider2D>().enabled = false;

                    }
                    else if (hit.collider.name == "chicken3")
                    {
                        chicken3.SetActive(false);
                        chicken4.SetActive(true);
                        chicken3.GetComponent<Collider2D>().enabled = false;
                    }
                    else if (hit.collider.name == "chicken4")
                    {
                        chicken4.SetActive(false);
                        chicken5.SetActive(true);
                        chicken4.GetComponent<Collider2D>().enabled = false;
                    }
                    else if (hit.collider.name == "chicken5")
                    {
                        chicken1.SetActive(true);
                        chicken2.SetActive(true);
                        chicken3.SetActive(true);
                        chicken4.SetActive(true);
                        chicken5.GetComponent<Collider2D>().enabled = false;
                        chickenAnim.SetActive(true);
                        chickAnim["Chicken"].speed = 0.35f;
                        chickAnim.Play("Chicken");
                    }

                }
            }
        }
    }
}
