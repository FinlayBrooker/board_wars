using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlacePiece : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void placePiece()
    {
        int p = GameObject.Find("Pieces").GetComponent<Dropdown>().value;
        string n = GameObject.Find("Pieces").GetComponent<Dropdown>().options[p].text;
        
        
        if (GenerateGame.instance.selected == null || GenerateGame.instance.selected.occupied)
        {
            return;
        }
        GameObject g;
        if (GenerateGame.instance.selected.isWhite)
        {
            g = GameObject.Find("White Points");
        }
        else
        {
            g = GameObject.Find("Black Points");
        }
        int v = int.Parse(g.GetComponent<Text>().text);
        int c = GlobalVariables.pieces[p].cost;
        if (v - c < 0)
        {
            return;
        }
        g.GetComponent<Text>().text = (v - c).ToString();
        if (n.Contains("King"))
        {
            if (GenerateGame.instance.selected.isWhite)
            {
                if (!GenerateGame.instance.whiteKing)
                {
                    GenerateGame.instance.whiteKing = true;
                }
                else
                {
                    return;
                }
            }
            else
            {
                if (!GenerateGame.instance.blackKing)
                {
                    GenerateGame.instance.blackKing = true;
                }
                else
                {
                    return;
                }
            }
        }
        if (GenerateGame.instance.selected.occupied)
        {
            Destroy(GenerateGame.instance.selected.occupiedBy.gameObject);
        }
        GenerateGame.instance.spawnPiece(p,GenerateGame.instance.selected);
        
    }

    public static void placePiece(Piece p, GeneratedTile gt)
    {
        GameObject g;
        if (gt.isWhite)
        {
            g = GameObject.Find("White Points");
        }
        else
        {
            g = GameObject.Find("Black Points");
        }
        int v = int.Parse(g.GetComponent<Text>().text);
        int c = p.cost;
        g.GetComponent<Text>().text = (v - c).ToString();
        GenerateGame.instance.spawnPiece(p.number, gt);
    }
    
}
