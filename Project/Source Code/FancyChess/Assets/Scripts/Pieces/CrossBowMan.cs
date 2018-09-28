using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossBowMan : Piece {

    public override Piece Init()
    {
        worth = 7;
        title = "CrossBowMan";
        number = 15;
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
        worth = 7;
        number = 15;
        title = "CrossBowMan";
        movement();
        take();
        range();
        //transform.rotation = transform.rotation * Quaternion.Euler(0, 0, -90);
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
        rangePath.Clear();
        rangePath.AddRange(moveF(GameLogic.instance.boardSize, false));
        rangePath.AddRange(moveB(GameLogic.instance.boardSize, false));
        rangePath.AddRange(moveL(GameLogic.instance.boardSize, false));
        rangePath.AddRange(moveR(GameLogic.instance.boardSize, false));
        getRangeProtecteds();
        return rangePattern;
    }
}
