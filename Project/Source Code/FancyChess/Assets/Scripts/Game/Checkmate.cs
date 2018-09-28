using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkmate : Rules {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override int checkWin(Player f, Player e)
    {
        return detectCheck(f,e);
    }

    public bool detectCheckmate(Player f, Player e)
    {
        if (!e.pieces.Contains(e.king) || !f.pieces.Contains(f.king))
        {
            return true;
        }
        if (e.updateControlZones().Contains(GameLogic.instance.selectedPiece.position))
        {
            return false;
        }

        foreach (Vector2 item in e.king.movement())
        {
            f.updateControlZones().Remove(item);
        }
        
        if(e.king.movementPattern.Count == 0)
        {
            return true;
        }
        return false;
    }

    public int detectCheck(Player f,Player e)
    {
        List<Vector2> threatZones = f.controlZones;
        //Debug.Log("Check detecting");
        if (f.updateControlZones().Contains(e.king.position))
        {
            if(detectCheckmate(f, e))
            {
                //Debug.Log("Checkmate detected");
                //GameLogic.instance.handleCheckmate
                return 2;
            }
            else if (f.takenPieces.Contains(e.king))
            {
                return 3;
            }
            else if (e.pieces.Count == 0)
            {
                return 4;
            }
            else
            {
                //Debug.Log("Check detected");
                //GameLogic.instance.handleCheck
                return 1;
            }
            
        }
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
