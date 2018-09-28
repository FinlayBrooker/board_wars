using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Piece : MonoBehaviour {

    public bool isWhite;
    public List<Vector2> movementPattern = new List<Vector2>();
    public List<Vector2> attackPattern = new List<Vector2>();
    public List<Vector2> attackPath = new List<Vector2>();
    public List<Vector2> rangePattern = new List<Vector2>();
    public List<Vector2> rangePath = new List<Vector2>();
    public List<Vector2> protectPattern = new List<Vector2>();
    public Tile on;
    public Vector2 position;
    //public char[] coords;
    public Coordinates coords;
    public bool canPromote = false;
    public List<Piece> promotesToo;
    public bool selected;
    public bool underThreat;
    public int worth;
    public int cost;
    public int value;
    public Color colour;
    public Material White;
    public Material Black;
    public int noMoves;
    public string title;
    public int number;
    public Vector3 dest;
    public bool moving = false;
    public System.Guid id = System.Guid.NewGuid();
    

    public List<List<Tile>> board = new List<List<Tile>>();

    public Piece()
    {

    }

    //deep copy
    
    public Piece(Piece copyPiece)
    {
        isWhite = copyPiece.isWhite;
        movementPattern = copyPiece.movementPattern;
        attackPattern = copyPiece.attackPattern;
        attackPath = copyPiece.attackPath;
        rangePattern = copyPiece.rangePattern;
        rangePath = copyPiece.rangePath;
        protectPattern = copyPiece.protectPattern;
        on = null;
        position = copyPiece.position;
        coords = copyPiece.coords;
        canPromote = copyPiece.canPromote;
        promotesToo = copyPiece.promotesToo;
        selected = copyPiece.selected;
        underThreat = copyPiece.underThreat;
        worth = copyPiece.worth;
        cost = copyPiece.cost;
        value = copyPiece.value;
        colour = copyPiece.colour;
        White = copyPiece.White;
        Black = copyPiece.Black;
        noMoves = copyPiece.noMoves;
        title = copyPiece.title;
        number = copyPiece.number;
        dest = copyPiece.dest;
        moving = copyPiece.moving;
        board = copyPiece.board;
        id = copyPiece.id;
    }

    public virtual Piece Init()
    {
        return this;
    }

    // Use this for initialization
    protected bool Start () {
        setupPiece();
        dest = transform.position;
        if (SceneManager.GetActiveScene().name.Contains("GameDesigner"))
        {
            return true;
        }
        return false;
    }
	
	// Update is called once per frame
	void Update () {
        if (!SceneManager.GetActiveScene().name.Contains("GameDesigner"))
        {
            actualMove();
            
        }
        

    }

    public void setupPiece()
    {
        if (isWhite)
        {
            GetComponent<Renderer>().material = White;
        }
        else
        {
            GetComponent<Renderer>().material = Black;
            transform.localRotation = transform.localRotation*Quaternion.Euler(0,0,180);
        }
        noMoves = 0;
        setBoard(GameLogic.instance.board);
        movement();
        take();
        range();
    }

    void OnMouseDown()
    {
        if (SceneManager.GetActiveScene().name.Contains("GameDesigner"))
        {
            GenerateGame.instance.handleTileClick(GenerateGame.instance.board[Mathf.FloorToInt(position.x)][Mathf.FloorToInt(position.y)]);
        }
        else
        {
            GameLogic.instance.handlePieceClick(this);
        }
        
    }

    public void updateMoves()
    {
        movement();
        take();
        range();
        getProtecteds();
    }

    public void setBoard(List<List<Tile>> newBoard)
    {
        board = newBoard;
        on = newBoard[Mathf.FloorToInt(position.x)][Mathf.FloorToInt(position.y)];
        newBoard[Mathf.FloorToInt(position.x)][Mathf.FloorToInt(position.y)].occupied = true;
        newBoard[Mathf.FloorToInt(position.x)][Mathf.FloorToInt(position.y)].occupiedBy = this;
    }

    protected virtual void actualMove()
    {
        transform.position = Vector3.MoveTowards(transform.position, dest, Time.deltaTime * 20);
        if (transform.position.Equals(dest))
        {
            moving = false;
            updateMoves();
        }
        else
        {
            moving = true;
        }
    }

    public void move(Tile dest)
    {
        //transform.position = dest.transform.position + new Vector3(0, 0.5f, 0);
        this.dest = dest.transform.position + new Vector3(0, 0.5f, 0);
        GameLogic.instance.unHighlightTiles();
        noMoves++;
        moving = true;
        on.occupiedBy = null;
        on.occupied = false;
        on = dest;
        on.occupied = true;
        on.occupiedBy = this;
        position = on.position;
        //GameLogic.instance.changeTurn();
    }

    public virtual void takePiece(Piece e)
    {
        e.on.occupiedBy = null;
        e.on.occupied = false;
        Destroy(e.gameObject);
        this.move(e.on);
        noMoves++;
        updateMoves();
        //GameLogic.instance.changeTurn();
    }

    public virtual void rangePiece(Piece e)
    {
        e.on.occupiedBy = null;
        e.on.occupied = false;
        Destroy(e.gameObject);
        noMoves++;
        updateMoves();
    }

    public virtual void rangedTake(Piece e) { }

    public virtual bool checkAbility() { return false; }

    public virtual void doAbilitly() { }

    public void getProtecteds()
    {
        protectPattern.Clear();
        foreach (Vector2 pos in attackPattern)
        {
            if (board[Mathf.FloorToInt(pos.x)][Mathf.FloorToInt(pos.y)].occupied)
            {
                if (board[Mathf.FloorToInt(pos.x)][Mathf.FloorToInt(pos.y)].occupiedBy.isWhite == isWhite)
                    {
                        protectPattern.Add(pos);
                    }
            }
        }
        foreach (Vector2 item in protectPattern)
        {
            if (attackPattern.Contains(item))
            {
                attackPattern.Remove(item);
            }
        }
    }

    public void getRangeProtecteds()
    {
        protectPattern.Clear();
        foreach (Vector2 pos in rangePattern)
        {
            if (board[Mathf.FloorToInt(pos.x)][Mathf.FloorToInt(pos.y)].occupied)
            {
                if (board[Mathf.FloorToInt(pos.x)][Mathf.FloorToInt(pos.y)].occupiedBy.isWhite == isWhite)
                {
                    protectPattern.Add(pos);
                }
            }  
        }
        foreach (Vector2 item in protectPattern)
        {
            if (rangePattern.Contains(item))
            {
                rangePattern.Remove(item);
            }
        }
    }

    public List<Vector2> moveF(int dist,bool take)
    {
        
        List<Vector2> path = new List<Vector2>();

        for (int i = 1; i < dist + 1; i++)
        {
            if (Mathf.FloorToInt(position.y) + i >= GameLogic.instance.boardSize)
            {
                break;
            }
            else if (board[Mathf.FloorToInt(position.x)][Mathf.FloorToInt(position.y) + i].occupied)
            {
                if (take)
                {
                    
                        path.Add(position + new Vector2(0, i));
                        break;
                    
                }
                break;
            }
            else
            {
                if (take) {  }
                else
                {
                    path.Add(position + new Vector2(0, i));
                }
                
            }
            
        }
        return path;
    }

    public List<Vector2> moveB(int dist, bool take)
    {
        List<Vector2> path = new List<Vector2>();
        for (int i = 1; i < dist + 1; i++)
        { 
            if(Mathf.FloorToInt(position.y) - i < 0)
            {
                break;
            }
            else if (board[Mathf.FloorToInt(position.x)][Mathf.FloorToInt(position.y) - i].occupied)
            {
                if (take)
                {
                    
                        path.Add(position + new Vector2(0, -i));
                        break;
                    
                }
                break;
            }
            else
            {
                if (take) { }
                else
                {
                    path.Add(position + new Vector2(0, -i));
                }
            }
            
        }
        return path;
    }

    public List<Vector2> moveL(int dist, bool take)
    {
        List<Vector2> path = new List<Vector2>();
        for (int i = 1; i < dist + 1; i++)
        {
            if (Mathf.FloorToInt(position.x) - i < 0)
            {
                break;
            }
            else if (board[Mathf.FloorToInt(position.x) - i][Mathf.FloorToInt(position.y)].occupied)
            {
                if (take)
                {
                    
                        path.Add(position + new Vector2(-i, 0));
                        break;
                    
                }
                break;
            }
            else
            {
                if (take) { }
                else
                {
                    path.Add(position + new Vector2(-i, 0));
                }
            }
            
        }
        return path;
    }

    public List<Vector2> moveR(int dist, bool take)
    {
        List<Vector2> path = new List<Vector2>();
        for (int i = 1; i < dist + 1; i++)
        {
            if (Mathf.FloorToInt(position.x) + i >= GameLogic.instance.boardSize)
            {
                break;
            }
            else if (board[Mathf.FloorToInt(position.x) + i][Mathf.FloorToInt(position.y)].occupied)
            {
                if (take)
                {
                    
                        path.Add(position + new Vector2(i, 0));
                        break;
                    
                }
                break;
            }
            else
            {
                if (take) { }
                else
                {
                    path.Add(position + new Vector2(i, 0));
                }
            }
        }
        return path;
    }

    public List<Vector2> moveDLF(int dist, bool take)
    {
        List<Vector2> path = new List<Vector2>();
        for (int i = 1; i < dist + 1; i++)
        {
            if (Mathf.FloorToInt(position.x) - i < 0)
            {
                break;
            }
            else if (Mathf.FloorToInt(position.y) + i >= GameLogic.instance.boardSize)
            {
                break;
            }
            else if (board[Mathf.FloorToInt(position.x) - i][Mathf.FloorToInt(position.y) + i].occupied)
            {
                if (take)
                {
                    
                        path.Add(position + new Vector2(-i, i));
                        break;
                    
                }
                break;
            }
            else
            {
                if (take) { }
                else
                {
                    path.Add(position + new Vector2(-i, i));
                }
            }
                
        }
        return path;
    }

    public List<Vector2> moveDRF(int dist, bool take)
    {
        List<Vector2> path = new List<Vector2>();
        for (int i = 1; i < dist + 1; i++)
        {
            if (Mathf.FloorToInt(position.x) + i >= GameLogic.instance.boardSize)
            {
                break;
            }
            else if (Mathf.FloorToInt(position.y) + i >= GameLogic.instance.boardSize)
            {
                break;
            }
            else if (board[Mathf.FloorToInt(position.x) + i][Mathf.FloorToInt(position.y) + i].occupied)
            {
                if (take)
                {
                    
                        path.Add(position + new Vector2(i, i));
                        break;
                    
                }
                break;
            }
            else
            {
                if (take) { }
                else
                {
                    path.Add(position + new Vector2(i, i));
                }
            }
        }
        return path;
    }

    public List<Vector2> moveDLB(int dist, bool take)
    {
        List<Vector2> path = new List<Vector2>();
        for (int i = 1; i < dist + 1; i++)
        {
            if (Mathf.FloorToInt(position.x) - i < 0)
            {
                break;
            }
            else if (Mathf.FloorToInt(position.y) - i < 0)
            {
                break;
            }
            else if (board[Mathf.FloorToInt(position.x) - i][Mathf.FloorToInt(position.y) - i].occupied)
            {
                if (take)
                {
                    
                        path.Add(position + new Vector2(-i, -i));
                        break;
                       
                }
                break;
            }
            else
            {
                if (take) { }
                else
                {
                    path.Add(position + new Vector2(-i, -i));
                }
            }
                
        }
        return path;
    }

    public List<Vector2> moveDRB(int dist, bool take)
    {
        List<Vector2> path = new List<Vector2>();
        for (int i = 1; i < dist + 1; i++)
        {
            if (Mathf.FloorToInt(position.x) + i >= GameLogic.instance.boardSize)
            {
                break;
            }
            else if (Mathf.FloorToInt(position.y) - i < 0)
            {
                break;
            }
            else if (board[Mathf.FloorToInt(position.x) + i][Mathf.FloorToInt(position.y) - i].occupied)
            {
                if (take)
                {
                    
                        path.Add(position + new Vector2(i, -i));
                        break;
                    
                }
                break;
            }
            else
            {
                if (take) { }
                else
                {
                    path.Add(position + new Vector2(i, -i));
                }
            }
                
        }
        return path;
    }

    public List<Vector2> jump(int x,int y, bool take)
    {
        List<Vector2> path = new List<Vector2>();
        //Debug.Log(position.x + x);
        //Debug.Log(position.y + y);
        if (Mathf.FloorToInt(position.x) + x >= GameLogic.instance.boardSize || Mathf.FloorToInt(position.x) + x < 0)
        {
            
        }
        else if (Mathf.FloorToInt(position.y) + y >= GameLogic.instance.boardSize || Mathf.FloorToInt(position.y) + y < 0)
        {
            
        }
        else if (board[Mathf.FloorToInt(position.x) + x][Mathf.FloorToInt(position.y) + y].occupied)
        {
            if (take)
            {
                
                    path.Add(position + new Vector2(x, y));
                
            }
        }
        else
        {
            if (take) { }
            else
            {
                path.Add(position + new Vector2(x, y));
            }
            
        }    
        return path;
    }

    // commented out untill checkers are implmented
    public List<Vector2> hopLF()
    {
        List<Vector2> path = new List<Vector2>();
        if (Mathf.FloorToInt(position.x) - 1 < 0 && Mathf.FloorToInt(position.x) - 2 < 0)
        {
            return path;
        }
        else if (Mathf.FloorToInt(position.y) + 1 >= GameLogic.instance.boardSize && Mathf.FloorToInt(position.y) + 2 >= GameLogic.instance.boardSize)
        {
            return path;
        }
        else if (GameLogic.instance.board[Mathf.FloorToInt(position.x) - 1][Mathf.FloorToInt(position.y) + 1].occupied && !GameLogic.instance.board[Mathf.FloorToInt(position.x) - 2][Mathf.FloorToInt(position.y) + 2].occupied)
        {
            path.Add(position + new Vector2(-1, 1));
        }
        return new List<Vector2>();
    }

    public List<Vector2> hopRF()
    {
        List<Vector2> path = new List<Vector2>();
        if (Mathf.FloorToInt(position.x) + 1 >= GameLogic.instance.boardSize && Mathf.FloorToInt(position.x) + 2 >= GameLogic.instance.boardSize)
        {
            return path;
        }
        else if (Mathf.FloorToInt(position.y) + 1 >= GameLogic.instance.boardSize && Mathf.FloorToInt(position.y) + 2 >= GameLogic.instance.boardSize)
        {
            return path;
        }
        else if (GameLogic.instance.board[Mathf.FloorToInt(position.x) + 1][Mathf.FloorToInt(position.y) + 1].occupied && !GameLogic.instance.board[Mathf.FloorToInt(position.x) + 2][Mathf.FloorToInt(position.y) + 2].occupied)
        {
            path.Add(position + new Vector2(1, 1));
        }
        return new List<Vector2>();
    }

    public List<Vector2> hopLB()
    {
        List<Vector2> path = new List<Vector2>();
        if (Mathf.FloorToInt(position.x) - 1 < 0 && Mathf.FloorToInt(position.x) - 2 < 0)
        {
            return path;
        }
        else if (Mathf.FloorToInt(position.y) - 1 < 0 && Mathf.FloorToInt(position.y) - 2 < 0)
        {
            return path;
        }
        else if (GameLogic.instance.board[Mathf.FloorToInt(position.x) - 1][Mathf.FloorToInt(position.y) - 1].occupied && !GameLogic.instance.board[Mathf.FloorToInt(position.x) - 2][Mathf.FloorToInt(position.y) - 2].occupied)
        {
            path.Add(position + new Vector2(-1, -1));
        }
        return new List<Vector2>();
    }

    public List<Vector2> hopRB()
    {
        List<Vector2> path = new List<Vector2>();
        if (Mathf.FloorToInt(position.x) + 1 >= GameLogic.instance.boardSize && Mathf.FloorToInt(position.x) + 2 >= GameLogic.instance.boardSize)
        {
            return path;
        }
        else if (Mathf.FloorToInt(position.y) - 1 < 0 && Mathf.FloorToInt(position.y) - 2 < 0)
        {
            return path;
        }
        else if (GameLogic.instance.board[Mathf.FloorToInt(position.x) + 1][Mathf.FloorToInt(position.y) - 1].occupied && !GameLogic.instance.board[Mathf.FloorToInt(position.x) + 2][Mathf.FloorToInt(position.y) - 2].occupied)
        {
            path.Add(position + new Vector2(1, -1));
        }
        return new List<Vector2>();
    }

    // Methods to be overwritten

    public virtual List<Vector2> movement() { return new List<Vector2>(); }

    public virtual List<Vector2> take() { return new List<Vector2>(); }

    public virtual List<Vector2> range() { return new List<Vector2>(); }

    public virtual void promote()
    {
        GameLogic.instance.promotePiece(this);
    }


}
