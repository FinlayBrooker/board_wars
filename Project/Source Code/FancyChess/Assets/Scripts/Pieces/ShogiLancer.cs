using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShogiLancer : Piece {

    public override Piece Init()
    {
        worth = 3;
        title = "S.Lancer";
        number = 7;
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
        worth = 2;
        number = 7;
        title = "S.Lancer";
        canPromote = true;
        movement();
        take();
    }


    public override List<Vector2> movement()
    {
        movementPattern.Clear();
        if (isWhite)
        {
            movementPattern.AddRange(moveF(GameLogic.instance.boardSize, false));
        }
        else
        {
            movementPattern.AddRange(moveB(GameLogic.instance.boardSize, false));
        }
        return movementPattern;
    }

    public override List<Vector2> take()
    {
        attackPattern.Clear();
        attackPath.Clear();
        if (isWhite)
        {
            attackPattern.AddRange(moveF(GameLogic.instance.boardSize, true));

            attackPath.AddRange(moveF(GameLogic.instance.boardSize, false));
        }
        else
        {
            attackPattern.AddRange(moveB(GameLogic.instance.boardSize, true));

            attackPath.AddRange(moveB(GameLogic.instance.boardSize, false));
        }
        getProtecteds();
        return attackPattern;

    }
}
