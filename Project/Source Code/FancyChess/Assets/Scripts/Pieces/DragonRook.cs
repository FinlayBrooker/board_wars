using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonRook : Piece {

    public override Piece Init()
    {
        worth = 13;
        title = "S.Dragon Rook";
        number = 20;
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
        worth = 13;
        title = "S.Dragon Rook";
        number = 20;
        canPromote = false;
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
        movementPattern.AddRange(moveDLB(1, false));
        movementPattern.AddRange(moveDRB(1, false));
        movementPattern.AddRange(moveDLF(1, false));
        movementPattern.AddRange(moveDRF(1, false));
        return movementPattern;
    }

    public override List<Vector2> take()
    {
        attackPattern.Clear();
        attackPattern.AddRange(moveF(GameLogic.instance.boardSize, true));
        attackPattern.AddRange(moveB(GameLogic.instance.boardSize, true));
        attackPattern.AddRange(moveL(GameLogic.instance.boardSize, true));
        attackPattern.AddRange(moveR(GameLogic.instance.boardSize, true));
        attackPattern.AddRange(moveDLB(1, true));
        attackPattern.AddRange(moveDRB(1, true));
        attackPattern.AddRange(moveDLF(1, true));
        attackPattern.AddRange(moveDRF(1, true));
        attackPath.Clear();
        attackPath.AddRange(moveF(GameLogic.instance.boardSize, false));
        attackPath.AddRange(moveB(GameLogic.instance.boardSize, false));
        attackPath.AddRange(moveL(GameLogic.instance.boardSize, false));
        attackPath.AddRange(moveR(GameLogic.instance.boardSize, false));
        attackPath.AddRange(moveDLB(1, false));
        attackPath.AddRange(moveDRB(1, false));
        attackPath.AddRange(moveDLF(1, false));
        attackPath.AddRange(moveDRF(1, false));
        getProtecteds();
        return attackPattern;
    }
}
