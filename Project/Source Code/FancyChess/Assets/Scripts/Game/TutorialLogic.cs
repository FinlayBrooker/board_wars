using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialLogic : GameLogic {

    new public static TutorialLogic instance;
    new public int boardSize = 5;
    new public int promotionRows = 1;
    //public List<List<Tile>> board = new List<List<Tile>>();
    //public GameObject TilePrefab;
    //public Vector3 centerPoint;
    //public List<Piece> pieces;
    public Piece piece;
    //public Player one;
    //public Player two;

    // Use this for initialization
    void Start () {
        instance = this;
        pieces = GlobalVariables.instance.getPiece();
        createBoard();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    new public void createBoard()
    {
        if (boardSize % 2 == 0)
        {
            centerPoint = new Vector3(-TilePrefab.transform.localScale.x / 2, 4 * boardSize, -TilePrefab.transform.localScale.z / 2);
        }
        else
        {
            centerPoint = new Vector3(0, 4 * boardSize, 0);
        }
        Camera.main.transform.position = centerPoint;
        bool rowStart = true;
        Color current = Color.black;
        for (int i = 0; i < boardSize; i++)
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
            for (int j = 0; j < boardSize; j++)
            {
                Tile tile = ((GameObject)Instantiate(TilePrefab, new Vector3((i - Mathf.Floor(boardSize / 2)) * TilePrefab.transform.localScale.x, 0, (j - Mathf.Floor(boardSize / 2)) * TilePrefab.transform.localScale.z), Quaternion.Euler(new Vector3()))).GetComponent<Tile>();
                tile.position = new Vector2(i, j);
                //tile.coords = new char[2];
                //tile.coords[0] = (char)(65 + i);
                //tile.coords[1] = (char)(49 + j);
                tile.coords = new Coordinates(i, j);
                tile.baseColour = current;
                if (j < promotionRows)
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
            rowStart = !rowStart;
            board.Add(row);
        }
    }

    new public void spawnPiece(Player pl, int p, Vector2 pos)
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
        this.piece = piece;
    }

    

    public void switchPiece(int p)
    {
        if(piece != null)
        {
            Destroy(piece.gameObject);
            unHighlightTiles();
        }
        GameObject.Find("Description").GetComponent<Description>().changeDescription(p);
        spawnPiece(one, p, new Vector2(2, 2));
    }
}
