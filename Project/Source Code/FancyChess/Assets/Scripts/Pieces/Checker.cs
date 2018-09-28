using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker : Piece {

    public override Piece Init()
    {
        worth = 5;
        title = "Checker";
        number = 14;
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
        worth = 5;
        number = 14;
        title = "Checker";
        canPromote = true;
        movement();
        take();
    }


    public override List<Vector2> movement()
    {
        movementPattern.Clear();
        if (isWhite)
        {
            movementPattern.AddRange(moveDLF(1, false));
            movementPattern.AddRange(moveDRF(1, false));
        }
        else
        {
            movementPattern.AddRange(moveDLB(1, false));
            movementPattern.AddRange(moveDRB(1, false));
        }
        return movementPattern;
    }

    public override List<Vector2> take()
    {
        attackPattern.Clear();
        if (isWhite)
        {
            attackPattern.AddRange(hopLF());
            attackPattern.AddRange(hopRF());
        }
        else
        {
            attackPattern.AddRange(hopLB());
            attackPattern.AddRange(hopRB());
        }
        return attackPattern;
    }
}
