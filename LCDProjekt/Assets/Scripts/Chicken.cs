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

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //print("Maus wurde gedrückt");

            //Mausposition
            mousePos = Input.mousePosition;
            print(mousePos);

            //Mausposition World
            mousePosWorld = mainCamera.ScreenToWorldPoint(mousePos);
            //In zweidim Vektor umwandeln
            mousePosWorld2D = new Vector2(mousePosWorld.x, mousePosWorld.y);

            //Raycast2d
            hit = Physics2D.Raycast(mousePosWorld2D, Vector2.zero);

            //prüfe ob hit einen collider beinhaltet
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.tag == "chicken")
                {
                    if (hit.collider.name == "chicken1")
                    {
                        chicken1.SetActive(false);
                        chicken2.SetActive(true);
                    }
                    else if (hit.collider.name == "chicken2")
                    {
                        chicken2.SetActive(false);
                        chicken3.SetActive(true);
                    }
                    else if (hit.collider.name == "chicken3")
                    {
                        chicken3.SetActive(false);
                        chicken4.SetActive(true);
                    }
                    else if (hit.collider.name == "chicken4")
                    {
                        chicken4.SetActive(false);
                        chicken5.SetActive(true);
                    }
                    else if (hit.collider.name == "chicken5")
                    {
                        chicken1.SetActive(true);
                        chicken2.SetActive(true);
                        chicken3.SetActive(true);
                        chicken4.SetActive(true);
                    }

                }
            }
        }
    }
}
