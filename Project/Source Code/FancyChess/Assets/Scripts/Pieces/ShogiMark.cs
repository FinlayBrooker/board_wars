using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShogiMark : MonoBehaviour {

    public Material white;
    public Material black;

	// Use this for initialization
	void Start () {
        
		if(transform.parent.gameObject.GetComponent<Piece>().isWhite)
        {
            GetComponent<Renderer>().material = black;
        }
        else
        {
            GetComponent<Renderer>().material = white;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
