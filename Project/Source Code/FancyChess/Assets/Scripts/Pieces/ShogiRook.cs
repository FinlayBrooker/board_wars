using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShogiRook : Piece {

    public override Piece Init()
    {
        worth = 6;
        title = "S.Rook";
        number = 10;
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
        worth = 6;
        title = "S.Rook";
        number = 10;
        canPromote = true;
        movement();
        take();
    }



    public override List<Vector2> movement()
    {
        movementPattern.Clear();
        movementPattern.AddRange(moveF(GameLogic.instance.boardSize, false));
        movementPattern.AddRange(moveB(GameLogic.instance.boardSize, false));
        movementPattern.AddRange(moveL(GameLogic.instance.boardSize, false));
        movementPattern.AddRange(moveR(GameLogic.instance.boardSize, false));
        return movementPattern;
    }

    public override List<Vector2> take()
    {
        attackPattern.Clear();
        attackPattern.AddRange(moveF(GameLogic.instance.boardSize, true));
        attackPattern.AddRange(moveB(GameLogic.instance.boardSize, true));
        attackPattern.AddRange(moveL(GameLogic.instance.boardSize, true));
        attackPattern.AddRange(moveR(GameLogic.instance.boardSize, true));

        attackPath.Clear();
        attackPath.AddRange(moveF(GameLogic.instance.boardSize, false));
        attackPath.AddRange(moveB(GameLogic.instance.boardSize, false));
        attackPath.AddRange(moveL(GameLogic.instance.boardSize, false));
        attackPath.AddRange(moveR(GameLogic.instance.boardSize, false));
        getProtecteds();
        return attackPattern;
    }
}
