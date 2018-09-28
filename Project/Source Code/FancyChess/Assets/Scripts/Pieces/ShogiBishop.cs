using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShogiBishop : Piece {

    public override Piece Init()
    {
        worth = 4;
        title = "S.Bishop";
        number = 9;
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
        worth = 4;
        title = "S.Bishop";
        number = 9;
        canPromote = true;
        movement();
        take();
    }



    public override List<Vector2> movement()
    {
        movementPattern.Clear();
        movementPattern.AddRange(moveDLF(GameLogic.instance.boardSize, false));
        movementPattern.AddRange(moveDLB(GameLogic.instance.boardSize, false));
        movementPattern.AddRange(moveDRF(GameLogic.instance.boardSize, false));
        movementPattern.AddRange(moveDRB(GameLogic.instance.boardSize, false));
        return movementPattern;
    }

    public override List<Vector2> take()
    {
        attackPattern.Clear();
        attackPattern.AddRange(moveDLF(GameLogic.instance.boardSize, true));
        attackPattern.AddRange(moveDLB(GameLogic.instance.boardSize, true));
        attackPattern.AddRange(moveDRF(GameLogic.instance.boardSize, true));
        attackPattern.AddRange(moveDRB(GameLogic.instance.boardSize, true));

        attackPath.Clear();
        attackPath.AddRange(moveDLF(GameLogic.instance.boardSize, false));
        attackPath.AddRange(moveDLB(GameLogic.instance.boardSize, false));
        attackPath.AddRange(moveDRF(GameLogic.instance.boardSize, false));
        attackPath.AddRange(moveDRB(GameLogic.instance.boardSize, false));
        getProtecteds();
        return attackPattern;
    }

}
