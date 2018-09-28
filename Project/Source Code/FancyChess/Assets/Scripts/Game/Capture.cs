using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capture : Rules {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override int checkWin(Player f, Player e)
    {
        if (f.takenPieces.Contains(e.king))
        {
            return 3;
        }
        else if (e.pieces.Count == 0)
        {
            return 4;
        }
        return 0;
    }
}
