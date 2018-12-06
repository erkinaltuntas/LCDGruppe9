using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public static Player player;
    public int id;
    public string playerName;
    public double money;
    public int riskScore;
    public int season;

    void Awake()
    {
        player = this;
        DontDestroyOnLoad(transform.gameObject);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
