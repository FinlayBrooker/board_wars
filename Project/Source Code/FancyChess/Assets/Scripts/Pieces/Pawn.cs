using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Piece {

    public override Piece Init()
    {
        worth = 1;
        title = "Pawn";
        number = 0;
        return this;
    }

    // Use this for initialization
    new void Start()
    {
        if (base.Start())
        {
            return;
        }
        setupPiece();
        worth = 1;
        number = 0;
        title = "Pawn";
        canPromote = true;
        movement();
        take();
	}
	
	// Update is called once per frame
	

    public override List<Vector2> movement()
    {
        movementPattern.Clear();
        int moveValue = 1;
        if(noMoves == 0)
        {
            moveValue = 2;
        }
        if (isWhite)
        {
            movementPattern.AddRange(moveF(moveValue, false));
        }
        else
        {
            movementPattern.AddRange(moveB(moveValue, false));
        }
        //Debug.Log(movementPattern);
        return movementPattern;
    }

    public override List<Vector2> take()
    {
        attackPattern.Clear();
        attackPath.Clear();
        if (isWhite)
        {
            attackPattern.AddRange(moveDLF(1,true));
            attackPattern.AddRange(moveDRF(1, true));

            attackPath.AddRange(moveDLF(1, false));
            attackPath.AddRange(moveDRF(1, false));
        }
        else
        {
            attackPattern.AddRange(moveDLB(1, true));
            attackPattern.AddRange(moveDRB(1, true));

            attackPath.AddRange(moveDLB(1, false));
            attackPath.AddRange(moveDRB(1, false));
        }
        getProtecteds();
        return attackPattern;
    }
}
