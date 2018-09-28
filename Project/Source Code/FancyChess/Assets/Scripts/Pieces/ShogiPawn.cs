using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShogiPawn : Piece {

    public override Piece Init()
    {
        worth = 1;
        title = "S.Pawn";
        number = 6;
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
        title = "S.Pawn";
        number = 6;
        movement();
        take();
    }


    public override List<Vector2> movement()
    {
        movementPattern.Clear();
        if (isWhite)
        {
            movementPattern.AddRange(moveF(1, false));
        }
        else
        {
            movementPattern.AddRange(moveB(1, false));
        }
        return movementPattern;
    }

    public override List<Vector2> take()
    {
        attackPattern.Clear();
        attackPath.Clear();
        if (isWhite)
        {
            attackPattern.AddRange(moveF(1, true));

            attackPath.AddRange(moveF(1, false));
        }
        else
        {
            attackPattern.AddRange(moveB(1, true));

            attackPath.AddRange(moveB(1, false));
        }
        getProtecteds();
        return attackPattern;
    }
}
