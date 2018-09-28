using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rando : AI
{
    //randomness

    public override void doMove()
    {
        takeTurn(-1);
        base.doMove();
    }

    public void takeTurn(int ignore)
    {
        if (counter > 100)
        {
            return;
        }
        Random.InitState(System.DateTime.Now.Millisecond);
        int piece = Random.Range(0, pieces.Count);
        while (piece == ignore) // dont pick same piece twice
        {
            Random.InitState(System.DateTime.Now.Millisecond);
            piece = Random.Range(0, pieces.Count);
        }
        //GameLogic.instance.selectedPiece = pieces[piece];
        if (pieces[piece].take().Count == 0)
        {
            if (pieces[piece].range().Count == 0)
            {
                if (pieces[piece].movement().Count == 0)
                {
                    ignore = 2;
                    takeTurn(ignore);
                    counter++;
                    return;
                }
                else
                {
                    Random.InitState(System.DateTime.Now.Millisecond);
                    int moveto = Random.Range(0, pieces[piece].movement().Count);
                    GameLogic.instance.movePiece(pieces[piece], GameLogic.instance.getPosition(pieces[piece].movement()[moveto]));
                }
            }
            else
            {
                Random.InitState(System.DateTime.Now.Millisecond);
                int rangeto = Random.Range(0, pieces[piece].range().Count);
                GameLogic.instance.rangePiece(pieces[piece], GameLogic.instance.getPosition(pieces[piece].range()[rangeto]).occupiedBy);
            }
        }
        else
        {
            Random.InitState(System.DateTime.Now.Millisecond);
            int taketo = Random.Range(0, pieces[piece].take().Count);
            GameLogic.instance.takePiece(pieces[piece], GameLogic.instance.getPosition(pieces[piece].take()[taketo]).occupiedBy);
        }

    }
}
