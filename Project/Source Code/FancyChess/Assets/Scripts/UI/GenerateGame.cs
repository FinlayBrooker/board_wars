using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGame : MonoBehaviour {

    public GameObject TilePrefab;
    public List<List<GeneratedTile>> board = new List<List<GeneratedTile>>();
    public int boardSize;
    public int rows;
    public static GenerateGame instance;
    public GeneratedTile selected;
    public List<Piece> pieces;
    public bool whiteKing;
    public bool blackKing;

	// Use this for initialization
    void Awake()
    {
        instance = this;
    }

	void Start () {
        instance = this;
        boardSize = 8;
        rows = Mathf.RoundToInt((float)boardSize / 3);
        
        createBoard(8);
        pieces = GlobalVariables.instance.getPiece();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void createBoard(int boardSize)
    {
        this.boardSize = boardSize;
        int rows = Mathf.RoundToInt((float)boardSize / 3);
        this.rows = rows;
        float height = 4 * boardSize;
        if(height < 32)
        {
            height = 32;
        }
        if (boardSize % 2 == 0)
        {
            Camera.main.transform.position = new Vector3(-TilePrefab.transform.localScale.x / 2, height, -TilePrefab.transform.localScale.z / 2);
        }
        else
        {
            Camera.main.transform.position = new Vector3(0, height, 0);
        }

        bool rowStart = true;
        Color current = Color.black;
        for (int i = 0; i < boardSize; i++)
        {
            List<GeneratedTile> row = new List<GeneratedTile>();
            if (i > rows-1 && i <= (boardSize-rows-1))
            {
                board.Add(row);
                rowStart = !rowStart;
                continue;
            }
            
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
                GeneratedTile tile = ((GameObject)Instantiate(TilePrefab, new Vector3((i - Mathf.Floor(boardSize / 2)) * TilePrefab.transform.localScale.x, 0, (j - Mathf.Floor(boardSize / 2)) * TilePrefab.transform.localScale.z), Quaternion.Euler(new Vector3()))).GetComponent<GeneratedTile>();
                tile.pos = new Vector2(i, j);
                tile.baseColor = current;
                tile.GetComponent<Renderer>().material.color = tile.baseColor;
                if(i < rows)
                {
                    tile.isWhite = true;
                }
                else
                {
                    tile.isWhite = false;
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

    public void clear()
    {
        foreach (List<GeneratedTile> item in board)
        {
            foreach (GeneratedTile g in item)
            {
                if (g.gameObject != null)
                {
                    if (g.occupied)
                    {
                        RemovePiece.removePiece(g.occupiedBy);
                    }
                    Destroy(g.gameObject);
                }
            }
        }
        board.Clear();
    }

    public void handleTileClick(GeneratedTile t)
    {
        if (selected != null)
        {
            selected.GetComponent<Renderer>().material.color = selected.baseColor;
        }
        selected = t;
        selected.GetComponent<Renderer>().material.color = Color.yellow;
    }

    public void spawnPiece(int p, GeneratedTile gt)
    {
        Piece piece = null;
        /*switch (p)
        {
            case 0:
                piece = Instantiate(pieces[p], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Pawn;
                break;
            case 1:
                piece = Instantiate(pieces[p], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Knight;
                break;
            case 2:
                piece = Instantiate(pieces[p], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Bishop;
                break;
            case 3:
                piece = Instantiate(pieces[p], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Rook;
                break;
            case 4:
                piece = Instantiate(pieces[p], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Queen;
                break;
            case 5:
                piece = Instantiate(pieces[p], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as King;
                break;
            case 6:
                piece = Instantiate(pieces[p], Vector3.zero, Quaternion.Euler(90, 0, 0)) as ShogiPawn;
                break;
            default:
                break;
        }*/
        piece = Instantiate(pieces[p], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
        if (piece.title.Contains("S."))
        {
            piece.transform.rotation = Quaternion.Euler(90, 0, -90);
        }
        gt.occupiedBy = piece;
        gt.occupied = true;
        piece.isWhite = gt.isWhite;
        piece.transform.position = gt.transform.position + new Vector3(0, 0.5f, 0);
    }

    public void spawnPiece(Piece p, GeneratedTile gt)
    {
        Piece piece = null;
        switch (p.title)
        {
            case "Pawn":
                piece = Instantiate(pieces[0], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Pawn;
                break;
            case "Knight":
                piece = Instantiate(pieces[1], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Knight;
                break;
            case "Bishop":
                piece = Instantiate(pieces[2], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Bishop;
                break;
            case "Rook":
                piece = Instantiate(pieces[3], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Rook;
                break;
            case "Queen":
                piece = Instantiate(pieces[4], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Queen;
                break;
            case "King":
                piece = Instantiate(pieces[5], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as King;
                break;
            case "S.Pawn":
                piece = Instantiate(pieces[6], Vector3.zero, Quaternion.Euler(90, 0, 0)) as ShogiPawn;
                break;
            default:
                break;
        }


        gt.occupiedBy = piece;
        gt.occupied = true;
        piece.isWhite = gt.isWhite;
        piece.transform.position = gt.transform.position + new Vector3(0, 0.5f, 0);
    }
}
