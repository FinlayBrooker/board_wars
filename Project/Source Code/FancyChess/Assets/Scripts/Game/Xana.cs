using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xana : AI {

    public override void doMove()
    {
        int initalValue = 0;
        //copy current game board
        List<List<Tile>> board = new List<List<Tile>>();
        //make lists for values and moves
        List<AIInfoHolder> info = new List<AIInfoHolder>();
        //create a list of all my pieces
        List<Piece> myPieces = new List<Piece>();
        List<Piece> enemyPieces = new List<Piece>();
        // get current board value
        //should deep copy the board
        foreach (List<Tile> item in GameLogic.instance.board)
        {
            List<Tile> i = new List<Tile>();
            foreach (Tile t in item)
            {
                //if(t.occupied && t.occupiedBy.isWhite != isWhite)
                //{
                //    enemyPieces.Add(new Piece(t.occupiedBy));
                //}
                i.Add(new Tile(t));
            }
            board.Add(i);
        }

        //foreach (Piece item in pieces)
        //{
        //    myPieces.Add(new Piece(item));
        //}

        foreach (List<Tile> item in board)
        {
            foreach (Tile i in item)
            {
                if (i.occupied)
                {
                    if (i.occupiedBy.isWhite == isWhite)
                    {
                        myPieces.Add(new Piece(i.occupiedBy));
                    }
                    else
                    {
                        enemyPieces.Add(new Piece(i.occupiedBy));
                    }
                }
            }
        }

        //Debug.Log(myPieces.Count);
        //Debug.Log(myPieces[0].isWhite);
       
        // simulate moves
        
        Vector2[] mlist;
        Vector2[] tlist;
        Vector2[] rlist;
        int moveCounter = 0;
        int pieceIndex = 0;

        List<Vector2> tiles = new List<Vector2>();
        //do setupup for each piece
        foreach (Piece item in myPieces)
        {
            item.setBoard(board);
            item.movement();
            item.take();
            item.range();
        }
        foreach (Piece item in enemyPieces)
        {
            item.setBoard(board);
            item.movement();
            item.take();
            item.range();
        }

        //initalValue = evaluateBoard(board);

        foreach (Piece p in myPieces)
        {
            //Debug.Log("Initial moves: "+p.movementPattern.Count);
            mlist = new Vector2[p.movementPattern.Count];
            tlist = new Vector2[p.attackPattern.Count];
            rlist = new Vector2[p.rangePattern.Count];

            p.movementPattern.CopyTo(mlist);
            p.attackPattern.CopyTo(tlist);
            p.rangePattern.CopyTo(rlist);
            //Debug.Log(p.movement().Count);
            //Debug.Log(mlist.Length);
            //Debug.Log(p.movement().Count);
            //movement
            moveCounter = 0;
            foreach (Vector2 pos in mlist)
            {
                //Debug.Log("1");
                List<List<Tile>> tempBoard = new List<List<Tile>>();
                foreach (List<Tile> item in board)
                {
                    List<Tile> i = new List<Tile>();
                    foreach (Tile t in item)
                    {
                        i.Add(new Tile(t));
                    }
                    tempBoard.Add(i);
                }

                foreach (List<Tile> item in tempBoard)
                {
                    foreach (Tile i in item)
                    {
                        if (i.occupied)
                        {
                            i.occupiedBy.setBoard(tempBoard);
                        }
                    }
                }

                Piece tempP = tempBoard[Mathf.FloorToInt(p.position.x)][Mathf.FloorToInt(p.position.y)].occupiedBy;
                //Debug.Log(tempP + " Available moves: " + tempP.movement().Count);
                //tempP.setBoard(tempBoard);
                //Debug.Log(tempP + " Available moves 2: " + tempP.movement().Count);
                tempBoard[Mathf.FloorToInt(tempP.position.x)][Mathf.FloorToInt(tempP.position.y)].occupiedBy = null;
                tempBoard[Mathf.FloorToInt(tempP.position.x)][Mathf.FloorToInt(tempP.position.y)].occupied = false;
                tempBoard[Mathf.FloorToInt(pos.x)][Mathf.FloorToInt(pos.y)].occupiedBy = tempP;
                tempBoard[Mathf.FloorToInt(pos.x)][Mathf.FloorToInt(pos.y)].occupied = true;
                tempP.position = tempBoard[Mathf.FloorToInt(pos.x)][Mathf.FloorToInt(pos.y)].position;
                tempP.on = tempBoard[Mathf.FloorToInt(pos.x)][Mathf.FloorToInt(pos.y)];
                // handle promotions
                //Debug.Log(tempP + " Available moves 2.5: " + tempP.movement().Count);
                //Debug.Log("3");
                if (tempP.canPromote && tempBoard[Mathf.FloorToInt(pos.x)][Mathf.FloorToInt(pos.y)].promotionTile)
                {
                    if(tempBoard[Mathf.FloorToInt(pos.x)][Mathf.FloorToInt(pos.y)].whiteProTile == isWhite)
                    {
                        Piece promoP = tempP.promotesToo[tempP.promotesToo.Count - 1];
                        //Debug.Log("4");
                        promoP.setBoard(tempBoard);
                        tempBoard[Mathf.FloorToInt(pos.x)][Mathf.FloorToInt(pos.y)].occupiedBy = promoP;
                        promoP.on = tempBoard[Mathf.FloorToInt(pos.x)][Mathf.FloorToInt(pos.y)];
                        promoP.updateMoves();
                    }
                }
                //Debug.Log(tempP + " Available moves 2.6: " + tempP.movement().Count);
                //Debug.Log("5");
                tempP.updateMoves();
                //Debug.Log(tempP + " Available moves 3: " + tempP.movement().Count);
                info.Add(new AIInfoHolder(evaluateBoard(tempBoard), pos, tempP.id, 'M'));
                //Debug.Log("6");
                moveCounter++;
            }
            //attack
            moveCounter = 0;
            foreach (Vector2 pos in tlist)
            {
                List<List<Tile>> tempBoard = new List<List<Tile>>();
                foreach (List<Tile> item in board)
                {
                    List<Tile> i = new List<Tile>();
                    foreach (Tile t in item)
                    {
                        i.Add(new Tile(t));
                    }
                    tempBoard.Add(i);
                }
                foreach (List<Tile> item in tempBoard)
                {
                    foreach (Tile i in item)
                    {
                        if (i.occupied)
                        {
                            i.occupiedBy.setBoard(tempBoard);
                        }
                    }
                }

                Piece tempP = tempBoard[Mathf.FloorToInt(p.position.x)][Mathf.FloorToInt(p.position.y)].occupiedBy;
                //tempP.setBoard(tempBoard);
                tempBoard[Mathf.FloorToInt(tempP.position.x)][Mathf.FloorToInt(tempP.position.y)].occupiedBy = null;
                tempBoard[Mathf.FloorToInt(tempP.position.x)][Mathf.FloorToInt(tempP.position.y)].occupied = false;
                tempBoard[Mathf.FloorToInt(pos.x)][Mathf.FloorToInt(pos.y)].occupiedBy = tempP;
                tempBoard[Mathf.FloorToInt(pos.x)][Mathf.FloorToInt(pos.y)].occupied = true;
                tempP.position = tempBoard[Mathf.FloorToInt(pos.x)][Mathf.FloorToInt(pos.y)].position;
                tempP.on = tempBoard[Mathf.FloorToInt(pos.x)][Mathf.FloorToInt(pos.y)];
                // handle promotions
                if (tempP.canPromote && tempBoard[Mathf.FloorToInt(pos.x)][Mathf.FloorToInt(pos.y)].promotionTile)
                {
                    if (tempBoard[Mathf.FloorToInt(pos.x)][Mathf.FloorToInt(pos.y)].whiteProTile == isWhite)
                    {
                        Piece promoP = tempP.promotesToo[tempP.promotesToo.Count - 1];
                        tempBoard[Mathf.FloorToInt(pos.x)][Mathf.FloorToInt(pos.y)].occupiedBy = promoP;
                        promoP.on = tempBoard[Mathf.FloorToInt(pos.x)][Mathf.FloorToInt(pos.y)];
                        promoP.updateMoves();
                    }
                }
                tempP.updateMoves();
                info.Add(new AIInfoHolder(evaluateBoard(tempBoard), pos, tempP.id, 'T'));
                moveCounter++;
            }
            //range
            moveCounter = 0;
            foreach (Vector2 pos in rlist)
            {
                List<List<Tile>> tempBoard = new List<List<Tile>>();
                foreach (List<Tile> item in board)
                {
                    List<Tile> i = new List<Tile>();
                    foreach (Tile t in item)
                    {
                        i.Add(new Tile(t));
                    }
                    tempBoard.Add(i);
                }
                foreach (List<Tile> item in tempBoard)
                {
                    foreach (Tile i in item)
                    {
                        if (i.occupied)
                        {
                            i.occupiedBy.setBoard(tempBoard);
                        }
                    }
                }

                Piece tempP = tempBoard[Mathf.FloorToInt(p.position.x)][Mathf.FloorToInt(p.position.y)].occupiedBy;
                //tempP.setBoard(tempBoard);
                tempBoard[Mathf.FloorToInt(pos.x)][Mathf.FloorToInt(pos.y)].occupiedBy = null;
                tempBoard[Mathf.FloorToInt(pos.x)][Mathf.FloorToInt(pos.y)].occupied = false;

                tempP.updateMoves();
                info.Add(new AIInfoHolder(evaluateBoard(tempBoard), pos, tempP.id, 'R'));
                moveCounter++;
            }
            pieceIndex++;
        }
        int capturedPieceIndex = 0;
        // simulate placing a captured piece on to board
        if (GameLogic.instance.doCaptured && takenPieces.Count > 0)
        {
            foreach (Piece captive in takenPieces)
            {
                if(numberCaptured[takenPieces.IndexOf(captive)] > 0)
                {
                    Piece tempP = new Piece(captive);
                    foreach (List<Tile> row in board)
                    {
                        foreach (Tile tile in row)
                        {
                            if (!tile.occupied)
                            {
                                List<List<Tile>> tempBoard = new List<List<Tile>>();
                                foreach (List<Tile> item in board)
                                {
                                    List<Tile> i = new List<Tile>();
                                    foreach (Tile t in item)
                                    {
                                        i.Add(new Tile(t));
                                    }
                                    tempBoard.Add(i);
                                }
                                foreach (List<Tile> item in tempBoard)
                                {
                                    foreach (Tile i in item)
                                    {
                                        if (i.occupied)
                                        {
                                            i.occupiedBy.setBoard(tempBoard);
                                        }
                                    }
                                }
                                captive.setBoard(tempBoard);
                                tempBoard[Mathf.FloorToInt(tile.position.x)][Mathf.FloorToInt(tile.position.y)].occupiedBy = tempP;
                                tempBoard[Mathf.FloorToInt(tile.position.x)][Mathf.FloorToInt(tile.position.y)].occupied = true;
                                tempP.position = tempBoard[Mathf.FloorToInt(tile.position.x)][Mathf.FloorToInt(tile.position.y)].position;

                                tempP.updateMoves();
                                info.Add(new AIInfoHolder(evaluateBoard(tempBoard), tile.position, tempP.id, 'P'));
                            }
                        }
                    }
                }
                capturedPieceIndex++;
            }
        }
        int highestIndex = 0;
        int highestValue = info[0].value;

        foreach (AIInfoHolder item in info)
        {
            if (isWhite)
            {
                if (item.value < highestValue)
                {
                    highestValue = item.value;
                    highestIndex = info.IndexOf(item);
                }
            }
            else
            {
                if (item.value > highestValue)
                {
                    highestValue = item.value;
                    highestIndex = info.IndexOf(item);
                }
            }
        }

        // if there are multiple values the same randomly pick one to prevent repetiotion
        List<int> highestValues = new List<int>();
        List<int> highestIndexs = new List<int>();
        foreach (AIInfoHolder item in info)
        {
            if (item.value == highestValue)
            {
                highestValues.Add(item.value);
                highestIndexs.Add(info.IndexOf(item));
            }
        }

        //random part
        Random.InitState(System.DateTime.Now.Millisecond);
        int rando = Random.Range(0, highestIndexs.Count);

        highestIndex = highestIndexs[rando];

        Debug.Log("HighestValue: " + highestValue);
        //Debug.Log("HighestIndex: " + highestIndex);
        Piece piece = null;
        foreach (Piece item in pieces)
        {
            if (item.id == info[highestIndex].idOfPiece)
            {
                piece = item;
                break;
            }
        }
        switch (info[highestIndex].moveType)
        {
            case 'M':
                //piece = whichPiece[pieceIndex];
                //pieces[piece].setBoard(GameLogic.instance.board);
                //Debug.Log("FinalPosition: " + moves[highestIndex]);
                Debug.Log("Moving: " + piece.title);
                Debug.Log("To: " + info[highestIndex].target);
                GameLogic.instance.movePiece(piece, GameLogic.instance.getPosition(info[highestIndex].target));   
                break;
            case 'T':
                //piece = whichPiece[pieceIndex];
                //pieces[piece].setBoard(GameLogic.instance.board);
                Debug.Log("Attacking with: " + piece.title);
                Debug.Log("To: " + info[highestIndex].target);
                GameLogic.instance.takePiece(piece, GameLogic.instance.getPosition(info[highestIndex].target).occupiedBy);
                break;
            case 'R':
                //piece = whichPiece[pieceIndex];
                //pieces[piece].setBoard(GameLogic.instance.board);
                Debug.Log("Shooting with: " + piece.title);
                Debug.Log("To: " + info[highestIndex].target);
                GameLogic.instance.rangePiece(piece, GameLogic.instance.getPosition(info[highestIndex].target).occupiedBy);
                break;
            case 'P':
                //piece = whichPiece[pieceIndex];
                //takenPieces[piece].setBoard(GameLogic.instance.board);
                Piece takenPiece = null;
                foreach (Piece item in takenPieces)
                {
                    if (item.id == info[highestIndex].idOfPiece)
                    {
                        takenPiece = item;
                        break;
                    }
                }

                Debug.Log("Placing: " + takenPiece.title);
                Debug.Log("To: " + info[highestIndex].target);
                GameLogic.instance.spawnCapturedPiece(takenPiece, info[highestIndex].target);
                break;
            default:
                GameLogic.instance.sendMessage("An Error has occured: Incorrect MoveType");
                break;
        }
        base.doMove();
    }

}
