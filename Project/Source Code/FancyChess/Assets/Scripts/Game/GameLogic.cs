using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour {

    public static GameLogic instance;
    public GameObject TilePrefab;
    public List<Piece> pieces;
    public Player one;
    public Player two;
    public Player turnPlayer;
    public int boardSize = 8;
    public int promotionRows = 1;
    public List<List<Tile>> board = new List<List<Tile>>();
    public Piece[,] pieceBoard;
    public Piece selectedPiece;
    private int selectX;
    private int selectY;
    public bool isWhiteTurn = true;
    public Vector3 centerPoint;
    public Rules rules;
    public GameObject messagePrefab;
    public GameObject exitMessagePrefab;
    bool allowInteration = true;
    public bool doCaptured = false;
    public CapturedButton selectedCB;
    public GameObject promoPrefab;
    public bool cont = false;
    bool waitForPromotion = false;
    public Piece promoTo = null;
    public bool placedCaptured = false;
    public int turn=0;
    public bool check = false;

    // Use this for initialization

    void Awake()
    {
        instance = this;
    }

	void Start () {
        pieces = GlobalVariables.instance.getPiece();
        //turnPlayer = one;
        
        if (boardSize % 2 == 0)
        {
            centerPoint = new Vector3(-TilePrefab.transform.localScale.x / 2, 4 * boardSize, -TilePrefab.transform.localScale.z / 2);
        }
        else
        {
            centerPoint = new Vector3(0, 4 * boardSize, 0);
        }
        Camera.main.transform.position = centerPoint;
        if (GameObject.Find("SetupObject"))
        {
            GameInfoHolder go = GameObject.Find("SetupObject").GetComponent<GameInfoHolder>();
            boardSize = go.boardSize;
            promotionRows = go.promoRows;
            createBoard();
            if (boardSize % 2 == 0)
            {
                centerPoint = new Vector3(-TilePrefab.transform.localScale.x / 2, 4 * boardSize, -TilePrefab.transform.localScale.z / 2);
            }
            else
            {
                centerPoint = new Vector3(0, 4 * boardSize, 0);
            }
            Camera.main.transform.position = centerPoint;
            rules = go.rules;
            switch (go.ai)
            {
                case 0: // player is versus another player do nothing
                    break;
                case 1: //player vs rando
                    one.ai = new Rando();
                    two.ai = new Rando();
                    break;
                case 2: //player vs xana
                    one.ai = new Xana();
                    two.ai = new Xana();
                    break;
                case 3: //player vs skynet
                    one.ai = new Skynet();
                    two.ai = new Skynet();
                    break;
                default:
                    break;
            }
            turnPlayer = one;
            one.isWhite = true;
            two.isWhite = false;
            foreach (Piece item in go.white)
            {
                spawnPiece(one, item.number, new Vector2(item.position.y,item.position.x));
            }
            one.setup();
            foreach (Piece item in go.black)
            {
                spawnPiece(two, item.number, new Vector2(item.position.y, item.position.x));
            }
            two.setup();
            UILogic.instance.setup();
            doCaptured = go.useCaptured;
            if(go.player != 100)
            {
                if (go.player == 0)
                {
                    Camera.main.transform.rotation = one.camQ;
                    two.user = false;
                }
                else
                {
                    Camera.main.transform.rotation = two.camQ;
                    one.user = false;
                    //turnPlayer.takeTurn();
                }
            }
            if (go.ai == 0)
            {
                one.user = true;
                two.user = true;
            }
        }
        else
        {
            pieceBoard = new Piece[boardSize, boardSize];
            createBoard();
            rules = new Checkmate();
            //Debug.Log(pieces[0].title + "Here");
            //spawn white pieces
            for (int i = 0; i < 8; i++)
            {
                spawnPiece(one, 0, new Vector2(i, 1));
            }
            spawnPiece(one, 3, new Vector2(0, 0));
            spawnPiece(one, 3, new Vector2(7, 0));
            spawnPiece(one, 1, new Vector2(1, 0));
            spawnPiece(one, 1, new Vector2(6, 0));
            spawnPiece(one, 2, new Vector2(2, 0));
            spawnPiece(one, 2, new Vector2(5, 0));
            spawnPiece(one, 4, new Vector2(3, 0));
            spawnPiece(one, 5, new Vector2(4, 0));
            //black pieces
            for (int i = 0; i < 8; i++)
            {
                spawnPiece(two, 0, new Vector2(i, 6));
            }
            spawnPiece(two, 3, new Vector2(0, 7));
            spawnPiece(two, 3, new Vector2(7, 7));
            spawnPiece(two, 1, new Vector2(1, 7));
            spawnPiece(two, 1, new Vector2(6, 7));
            spawnPiece(two, 2, new Vector2(2, 7));
            spawnPiece(two, 2, new Vector2(5, 7));
            spawnPiece(two, 4, new Vector2(3, 7));
            spawnPiece(two, 5, new Vector2(4, 7));
            UILogic.instance.setup();
            sendMessage("Hello");
        }
    }
	
	// Update is called once per frame
	void Update () {
        //select();
	}

    public void updatePieces()
    {
        foreach (List<Tile> i in board)
        {
            foreach (Tile j in i)
            {
                if(j.occupied == true)
                {
                    j.occupiedBy.updateMoves();
                }
            }
        }
    }

    public IEnumerator changeTurn() {

        updatePieces();
        winConditions();
        //Debug.Log(selectedPiece.moving);
        if (placedCaptured)
        {
            placedCaptured = false;
        }
        else
        {
            while (selectedPiece.moving)
            {
                yield return null;
            }
        }
        
        while (waitForPromotion)
        {
            yield return null;
        }
        //Debug.Log("changing turn");
        turn++;
        UILogic.instance.saveValues(turnPlayer.numberCaptured);
        UILogic.instance.savePoints(turnPlayer.points);
        UILogic.instance.changePoints(turnPlayer.points);
        allowInteration = false;
        yield return new WaitForSeconds(Time.deltaTime * boardSize);
        allowInteration = true;
        //winConditions();
        unselectPiece();
        turnPlayer.updateControlZones();
        isWhiteTurn = !isWhiteTurn;
        updatePieces();
        if (turnPlayer == one)
        {
            turnPlayer = two;
        }
        else
        {
            turnPlayer = one;
        }
        if (!turnPlayer.user)
        {
            turnPlayer.takeTurn();
            turnPlayer.refreshPieces();
            turnPlayer.counter = 0;
            isWhiteTurn = !isWhiteTurn;
            if (turnPlayer == one)
            {
                turnPlayer = two;
            }
            else
            {
                turnPlayer = one;
            }
        }
        else
        {
            Camera.main.transform.position = centerPoint;
            Camera.main.transform.rotation = turnPlayer.camQ;
            UILogic.instance.changeButtons(turnPlayer.numberCaptured);
            UILogic.instance.changePoints(turnPlayer.points);
        }
        
    }

    public void handleTileClick(Tile t)
    {
        if (!allowInteration)
        {
            return;
        }
        if (selectedPiece != null)
        {
            if (selectedPiece.movement().Contains(t.position))
            {
                movePiece(selectedPiece, t);
                //unselectPiece();
            }
            else if (selectedPiece.take().Contains(t.position))
            {
                takePiece(selectedPiece, t.occupiedBy);
                //unselectPiece();
            }
            else if (selectedPiece.range().Contains(t.position))
            {
                rangePiece(selectedPiece, t.occupiedBy);
                //unselectPiece();
            }
            else
            {
                unselectPiece();
            }
        }
        else
        {
            if (t.occupied)
            {
                if(t.occupiedBy.isWhite == isWhiteTurn)
                {
                    changeSelected(t.occupiedBy);
                }
            }
            else
            {
                if(selectedCB != null && doCaptured)
                {
                    spawnCapturedPiece(selectedCB.caputred, t.position);
                    selectedCB.remove();
                    selectedPiece = selectedCB.caputred;
                    selectedPiece.position = t.position;
                    selectedCB = null;
                }
            }
        }
    }

    public void handlePieceClick(Piece p)
    {
        if (!allowInteration)
        {
            return;
        }
        if(selectedPiece != null)
        {
            if (selectedPiece.take().Contains(p.position))
            {
                //selectedPiece.takePiece(p);
                takePiece(selectedPiece, p);
                //unselectPiece();
            }
            else if (selectedPiece.range().Contains(p.position))
            {
                //selectedPiece.takePiece(p);
                rangePiece(selectedPiece, p);
                //unselectPiece();
            }
            else
            {
                unselectPiece();
            }
        }
        else
        {
            if(p.isWhite == isWhiteTurn)
            {
                changeSelected(p);
            }
            
        }
    }

    public void select()
    {
        if (!Camera.main)
        {
            return;
        }
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 50.0f,LayerMask.GetMask("Board")))
        {
            selectX = (int)hit.transform.position.x;
            selectY = (int)hit.transform.position.z;

        }
        else
        {
            selectX = -1000;
            selectY = -1000;
        }
        //Debug.Log(selectX +" "+ selectY);
    }

    public void createBoard()
    {
        

        bool rowStart = true;
        Color current = Color.black;
        for(int i = 0; i < boardSize; i++)
        {
            List<Tile> row = new List<Tile>();
            if (rowStart)
            {
                current = Color.black;
            }
            else
            {
                current = Color.white;
            }
            for(int j = 0; j < boardSize; j++)
            {
                Tile tile = ((GameObject)Instantiate(TilePrefab, new Vector3((i - Mathf.Floor(boardSize / 2)) * TilePrefab.transform.localScale.x, 0, (j - Mathf.Floor(boardSize / 2)) * TilePrefab.transform.localScale.z), Quaternion.Euler(new Vector3()))).GetComponent<Tile>();
                tile.position = new Vector2(i, j);
                //tile.coords = new char[2];
                //tile.coords[0] = (char)(65 + i);
                //tile.coords[1] = (char)(49 + j);
                tile.coords = new Coordinates(i, j);
                tile.baseColour = current;
                if(j < promotionRows)
                {
                    tile.promotionTile = true;
                    tile.whiteProTile = false;
                }
                else if (j >= (boardSize - promotionRows))
                {
                    tile.promotionTile = true;
                    tile.whiteProTile = true;
                }
                row.Add(tile);
                if (current == Color.white)
                {
                    current = Color.black;
                }
                else
                {
                    current = Color.white;
                }
            }
            rowStart = switchBool(rowStart);
            board.Add(row);
        }
    }

    public bool switchBool(bool b)
    {
        if (b)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void spawnPiece(Player pl, int p, Vector2 pos)
    {
        Piece piece = null;
        piece = Instantiate(pieces[p], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
        if (piece.title.Contains("S."))
        {
            piece.transform.rotation = Quaternion.Euler(90, 0, 0);
        }
        piece.on = getPosition(pos);        
        piece.isWhite = pl.isWhite;        
        piece.position = piece.on.position;        
        piece.coords = piece.on.coords;        
        piece.transform.position = piece.on.transform.position + new Vector3(0, 0.5f, 0);        
        piece.on.occupiedBy = piece;        
        piece.on.occupied = true;
        piece.setupPiece();
        pl.pieces.Add(piece);
        if (piece.title == "King")
        {
            pl.king = piece;
        }
    }

    public Tile getPosition(Vector2 pos)
    {
        Tile t = board[Mathf.FloorToInt(pos.x)][Mathf.FloorToInt(pos.y)];
        return t;
    }

    void highlightTiles(List<Vector2> t, List<Vector2> m, List<Vector2> r)
    {
            foreach (Vector2 i in m)
            {
                board[Mathf.FloorToInt(i.x)][Mathf.FloorToInt(i.y)].canMove = true;
                board[Mathf.FloorToInt(i.x)][Mathf.FloorToInt(i.y)].select();
            }
            foreach (Vector2 i in t)
            {
                board[Mathf.FloorToInt(i.x)][Mathf.FloorToInt(i.y)].canTake = true;
                board[Mathf.FloorToInt(i.x)][Mathf.FloorToInt(i.y)].select();
            }
        foreach (Vector2 i in r)
        {
            board[Mathf.FloorToInt(i.x)][Mathf.FloorToInt(i.y)].canRange = true;
            board[Mathf.FloorToInt(i.x)][Mathf.FloorToInt(i.y)].select();
        }
    }

    public void unHighlightTiles()
    {
        foreach (List<Tile> item in board)
        {
            foreach (Tile i in item)
            {
                i.colour = i.baseColour;
                i.selected = false;
                i.canMove = false;
                i.canTake = false;
                i.canRange = false;
                i.select();
                
            }
        }
    }

    public void changeSelected(Piece piece)
    {
        unHighlightTiles();
        selectedPiece = piece;
        piece.on.selected = true;
        piece.on.select();
        List<int> toRemove = new List<int>();
        piece.movement();
        piece.take();
        /*if (piece.title.Contains("King"))
        {
            toRemove.Clear();
            if (turnPlayer.Equals(one))
            {
                one.updateControlZones();
                foreach (Vector2 item in one.controlZones)
                {
                    if (piece.movementPattern.Contains(item))
                    {
                        toRemove.Add(piece.movementPattern.IndexOf(item));
                    }
                }
                foreach (int item in toRemove)
                {
                    piece.movementPattern.RemoveAt(item);
                }
                toRemove.Clear();
                foreach (Vector2 item in one.controlZones)
                {
                    if (piece.attackPattern.Contains(item))
                    {
                        toRemove.Add(piece.attackPattern.IndexOf(item));
                    }
                }
                foreach (int item in toRemove)
                {
                    piece.attackPattern.RemoveAt(item);
                }
            }
            else
            {
                two.updateControlZones();
                foreach (Vector2 item in two.controlZones)
                {
                    if (piece.movementPattern.Contains(item))
                    {
                        toRemove.Add(piece.movementPattern.IndexOf(item));
                    }
                }
                foreach (int item in toRemove)
                {
                    piece.movementPattern.RemoveAt(item);
                }
                toRemove.Clear();
                foreach (Vector2 item in two.controlZones)
                {
                    if (piece.attackPattern.Contains(item))
                    {
                        toRemove.Add(piece.attackPattern.IndexOf(item));
                    }
                }
                foreach (int item in toRemove)
                {
                    piece.attackPattern.RemoveAt(item);
                }
            }

            
        }*/
        highlightTiles(piece.attackPattern, piece.movementPattern, piece.range());
        //Debug.Log("Successful");
        //Debug.Log(piece.checkAbility());
    }

    public void unselectPiece()
    {
        unHighlightTiles();
        selectedPiece = null;
    }

    public void movePiece(Piece p,Tile t)
    {
        
        p.move(t);
        if (t.promotionTile && p.canPromote && t.whiteProTile == p.isWhite)
        {
            p.promote();
        }
        StartCoroutine(changeTurn());
    }

    public void takePiece(Piece p, Piece e)
    {
        
        if (turnPlayer.user)
        {
            UILogic.instance.addToButton(e.title);
        }
        turnPlayer.points += e.worth;
        if (turnPlayer == one)
        {
            two.pieces.Remove(e);
        }
        else
        {
            one.pieces.Remove(e);
        }
        p.takePiece(e);
        //if (turnPlayer.takenPiecesDict.ContainsKey(e))
        //{
        //    turnPlayer.takenPiecesDict[e] += 1;
        //}
        //else
        //{
        //    turnPlayer.takenPiecesDict.Add(e, 1);
        //}
        turnPlayer.takenPieces.Add(e);
        if (e.on.promotionTile && p.canPromote && e.on.whiteProTile == p.isWhite)
        {
            p.promote();
        }
        StartCoroutine(changeTurn());
    }

    public void rangePiece(Piece p, Piece e)
    {
        
        UILogic.instance.addToButton(e.title);
        turnPlayer.points += e.worth;
        if (turnPlayer == one)
        {
            two.pieces.Remove(e);
        }
        else
        {
            one.pieces.Remove(e);
        }
        p.rangePiece(e);
        //if (turnPlayer.takenPiecesDict.ContainsKey(e))
        //{
        //    turnPlayer.takenPiecesDict[e] += 1;
        //}
        //else
        //{
        //    turnPlayer.takenPiecesDict.Add(e, 1);
        //}
        turnPlayer.takenPieces.Add(e);
        StartCoroutine(changeTurn());
    }

    public void winConditions()
    {
        check = false;
        Player e;
        if (turnPlayer.Equals(one))
        {
            e = two;
        }
        else
        {
            e = one;
        }
        string player;
        if (isWhiteTurn)
        {
            player = "One";
        }
        else
        {
            player = "Two";
        }
        switch (rules.checkWin(turnPlayer,e))
        {
            case 0:
                //nothing
                break;
            case 1:
                // check
                //show check message
                check = true;
                sendMessage("Check");
                break;
            case 2:
                //checkmate
                // show checkmate message / end game
                
                sendExitMessage("Player " + player + " Wins by Checkmate");
                //sendExitMessage("Checkmate");
                break;
            case 3:
                // captured
                sendExitMessage("Player " + player + " Wins by Capture");
                break;
            case 4:
                // eliminated
                sendExitMessage("Player " + player + " Wins by Elimiation");
                break;
            default:
                break;
               
        } //Debug.Log(rules.checkWin(turnPlayer, e));
    }

    public void surrender()
    {
        string player;
        if (isWhiteTurn)
        {
            player = "One";
        }
        else
        {
            player = "Two";
        }
        sendExitMessage("Player " + player + " surrendered");
    }

    public void sendMessage(string message)
    {
        GameObject go = Instantiate(messagePrefab, Vector3.zero, Quaternion.identity) as GameObject;
        RectTransform trans = go.GetComponent<RectTransform>();
        trans.SetParent(GameObject.Find("Canvas").transform, false);
        go.GetComponent<Message>().Init(message);
    }

    public void sendExitMessage(string message)
    {
        GameObject go = Instantiate(exitMessagePrefab, Vector3.zero, Quaternion.identity) as GameObject;
        RectTransform trans = go.GetComponent<RectTransform>();
        trans.SetParent(GameObject.Find("Canvas").transform, false);
        go.GetComponent<ExitMessage>().Init(message);
    }

    public void spawnCapturedPiece(Piece p, Vector2 v)
    {
        spawnPiece(turnPlayer, p.number, v);
        placedCaptured = true;
        StartCoroutine(changeTurn());

    }

    public void promotePiece(Piece p)
    {
        if (!turnPlayer.user)
        {
            promoTo = p.promotesToo[p.promotesToo.Count - 1];
            cont = true;
            waitForPromotion = true;
            StartCoroutine(waitForPromoButton(true, p));
        }
        else
        {
            GameObject go = Instantiate(promoPrefab, Vector3.zero, Quaternion.identity) as GameObject;
            RectTransform trans = go.GetComponent<RectTransform>();
            trans.SetParent(GameObject.Find("Canvas").transform, false);
            go.GetComponent<PromoPanel>().promotesTo = p.promotesToo;
            go.GetComponent<PromoPanel>().Init(p.promotesToo);
            waitForPromotion = true;
            StartCoroutine(waitForPromoButton(true, p));
        }
        
    }

    IEnumerator waitForPromoButton(bool wait, Piece p)
    {
        while (wait)
        {
            while (!p.on.promotionTile)
            {
                yield return null;
            }
            if (cont)
            {
                turnPlayer.pieces.Remove(p);
                if (p.isWhite)
                {
                    spawnPiece(one, promoTo.number, p.position);
                }
                else
                {
                    spawnPiece(two, promoTo.number, p.position);
                }
                Destroy(p.gameObject);
                if (!UILogic.instance.needed.Contains(promoTo.title))
                {
                    UILogic.instance.addNewButton(promoTo);
                    one.numberCaptured.Add(0);
                    two.numberCaptured.Add(0);
                }
                promoTo = null;
                cont = false;
                wait = false;
                waitForPromotion = false;
            }
            yield return null;
        }
        //Debug.Log("Button has been clicked");
        yield return 0;
    }
}
