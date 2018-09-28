using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : Piece {

    public override Piece Init()
    {
        worth = 9;
        title = "Queen";
        number = 4;
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
        worth = 9;
        number = 4;
        title = "Queen";
        movement();
        take();
    }

    // Update is called once per frame


    public override List<Vector2> movement()
    {
        movementPattern.Clear();
        movementPattern.AddRange(moveF(GameLogic.instance.boardSize, false));
        movementPattern.AddRange(moveB(GameLogic.instance.boardSize, false));
        movementPattern.AddRange(moveL(GameLogic.instance.boardSize, false));
        movementPattern.AddRange(moveR(GameLogic.instance.boardSize, false));
        movementPattern.AddRange(moveDLF(GameLogic.instance.boardSize, false));
        movementPattern.AddRange(moveDLB(GameLogic.instance.boardSize, false));
        movementPattern.AddRange(moveDRF(GameLogic.instance.boardSize, false));
        movementPattern.AddRange(moveDRB(GameLogic.instance.boardSize, false));
        return movementPattern;
    }

    public override List<Vector2> take()
    {
        attackPattern.Clear();
        attackPattern.AddRange(moveF(GameLogic.instance.boardSize, true));
        attackPattern.AddRange(moveB(GameLogic.instance.boardSize, true));
        attackPattern.AddRange(moveL(GameLogic.instance.boardSize, true));
        attackPattern.AddRange(moveR(GameLogic.instance.boardSize, true));
        attackPattern.AddRange(moveDLF(GameLogic.instance.boardSize, true));
        attackPattern.AddRange(moveDLB(GameLogic.instance.boardSize, true));
        attackPattern.AddRange(moveDRF(GameLogic.instance.boardSize, true));
        attackPattern.AddRange(moveDRB(GameLogic.instance.boardSize, true));

        attackPath.Clear();
        attackPath.AddRange(moveF(GameLogic.instance.boardSize, false));
        attackPath.AddRange(moveB(GameLogic.instance.boardSize, false));
        attackPath.AddRange(moveL(GameLogic.instance.boardSize, false));
        attackPath.AddRange(moveR(GameLogic.instance.boardSize, false));
        attackPath.AddRange(moveDLF(GameLogic.instance.boardSize, false));
        attackPath.AddRange(moveDLB(GameLogic.instance.boardSize, false));
        attackPath.AddRange(moveDRF(GameLogic.instance.boardSize, false));
        attackPath.AddRange(moveDRB(GameLogic.instance.boardSize, false));
        getProtecteds();
        return attackPattern;
    }
}
