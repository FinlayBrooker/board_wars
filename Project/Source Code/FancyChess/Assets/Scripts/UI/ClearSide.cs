using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearSide : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void clearSide(bool white)
    {
        foreach (List<GeneratedTile> item in GenerateGame.instance.board)
        {
            foreach (GeneratedTile gt in item)
            {
                if(gt.isWhite == white && gt.occupied)
                {
                    RemovePiece.removePiece(gt.occupiedBy);
                }
            }
        }
        
    }
}
