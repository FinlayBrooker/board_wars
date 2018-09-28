using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBishop : Piece {

    public override Piece Init()
    {
        worth = 11;
        title = "S.Dragon Bishop";
        number = 19;
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
        worth = 11;
        title = "S.Dragon Bishop";
        number = 19;
        canPromote = false;
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
        movementPattern.AddRange(moveF(1, false));
        movementPattern.AddRange(moveL(1, false));
        movementPattern.AddRange(moveR(1, false));
        movementPattern.AddRange(moveB(1, false));
        return movementPattern;
    }

    public override List<Vector2> take()
    {
        attackPattern.Clear();
        attackPattern.AddRange(moveDLF(GameLogic.instance.boardSize, true));
        attackPattern.AddRange(moveDLB(GameLogic.instance.boardSize, true));
        attackPattern.AddRange(moveDRF(GameLogic.instance.boardSize, true));
        attackPattern.AddRange(moveDRB(GameLogic.instance.boardSize, true));
        attackPattern.AddRange(moveF(1, true));
        attackPattern.AddRange(moveL(1, true));
        attackPattern.AddRange(moveR(1, true));
        attackPattern.AddRange(moveB(1, true));
        attackPath.Clear();
        attackPath.AddRange(moveDLF(GameLogic.instance.boardSize, false));
        attackPath.AddRange(moveDLB(GameLogic.instance.boardSize, false));
        attackPath.AddRange(moveDRF(GameLogic.instance.boardSize, false));
        attackPath.AddRange(moveDRB(GameLogic.instance.boardSize, false));
        attackPath.AddRange(moveF(1, false));
        attackPath.AddRange(moveL(1, false));
        attackPath.AddRange(moveR(1, false));
        attackPath.AddRange(moveB(1, false));
        getProtecteds();
        return attackPattern;
    }
}
