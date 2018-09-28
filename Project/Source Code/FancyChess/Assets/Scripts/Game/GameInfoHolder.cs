using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfoHolder : MonoBehaviour {

    public List<Piece> white;
    public List<Piece> black;
    public Rules rules;
    public bool useCaptured;
    public int boardSize;
    public int promoRows;
    public int player = 100;
    public int ai = 100;



	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
