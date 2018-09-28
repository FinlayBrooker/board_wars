using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHold : MonoBehaviour {

    public Vector2 pos;
    public string piece = "";
    public int p;
    public bool white { get; set; }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponentInChildren<Text>().text = piece;
	}

    public void select()
    {
        GenerateButtons.instance.lastclicked = this;
    }
}
