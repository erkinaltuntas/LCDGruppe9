using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureScript : MonoBehaviour {

    public Vector3 mousePos;
    public Vector3 mousePosWorld;
    public Camera mainCamera;
    public Vector2 mousePosWorld2D;
    public Feld feld1;
    RaycastHit2D hit;

    public GameObject selectionPanel;
  

    // Use this for initialization
    void Start()
    {
        //make SelectionPanel invisible
        selectionPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("Maus wurde gedrückt");

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
                print("Objekt mit Collider getroffen");
                //Ausgabe des getroffenen Objects
                print(hit.collider.gameObject.name);

                if(hit.collider.gameObject.name == "Feld1")
                {
                    selectionPanel.SetActive(true);
                } else
                {
                    feld1.plantName = hit.collider.gameObject.name.ToString();
                    selectionPanel.SetActive(false);
                }
            }
            else
            {
                print("kein Collider erkannt");
            }
        }


    }
}
