using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Piece {

    public override Piece Init()
    {
        worth = 12;
        title = "Wizard";
        number = 18;
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
        worth = 12;
        number = 18;
        title = "Wizard";
        movement();
        take();
        range();
    }


    public override List<Vector2> movement()
    {
        movementPattern.Clear();
        movementPattern.AddRange(moveF(1, false));
        movementPattern.AddRange(moveB(1, false));
        movementPattern.AddRange(moveL(1, false));
        movementPattern.AddRange(moveR(1, false));
        movementPattern.AddRange(moveDLF(1, false));
        movementPattern.AddRange(moveDLB(1, false));
        movementPattern.AddRange(moveDRF(1, false));
        movementPattern.AddRange(moveDRB(1, false));
        return movementPattern;
    }

    public override List<Vector2> range()
    {
        rangePattern.Clear();
        rangePattern.AddRange(moveF(GameLogic.instance.boardSize, true));
        rangePattern.AddRange(moveB(GameLogic.instance.boardSize, true));
        rangePattern.AddRange(moveL(GameLogic.instance.boardSize, true));
        rangePattern.AddRange(moveR(GameLogic.instance.boardSize, true));
        rangePattern.AddRange(moveDLF(GameLogic.instance.boardSize, true));
        rangePattern.AddRange(moveDRF(GameLogic.instance.boardSize, true));
        rangePattern.AddRange(moveDLB(GameLogic.instance.boardSize, true));
        rangePattern.AddRange(moveDRB(GameLogic.instance.boardSize, true));

        rangePath.Clear();
        rangePath.AddRange(moveF(GameLogic.instance.boardSize, false));
        rangePath.AddRange(moveB(GameLogic.instance.boardSize, false));
        rangePath.AddRange(moveL(GameLogic.instance.boardSize, false));
        rangePath.AddRange(moveR(GameLogic.instance.boardSize, false));
        rangePath.AddRange(moveDLF(GameLogic.instance.boardSize, false));
        rangePath.AddRange(moveDRF(GameLogic.instance.boardSize, false));
        rangePath.AddRange(moveDLB(GameLogic.instance.boardSize, false));
        rangePath.AddRange(moveDRB(GameLogic.instance.boardSize, false));
        getRangeProtecteds();
        return rangePattern;
    }
}
