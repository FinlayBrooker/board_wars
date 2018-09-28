using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShogiKing : King {

    public override Piece Init()
    {
        worth = 10;
        title = "S.King";
        number = 13;
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
        worth = 10;
        title = "S.King";
        number = 13;
        movement();
        take();
    }


}
