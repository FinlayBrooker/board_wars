using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemovePiece : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void removePiece()
    {
        if (GenerateGame.instance.selected != null && GenerateGame.instance.selected.occupied)
        {
            int w = GenerateGame.instance.selected.occupiedBy.cost;
            GameObject g;
            if (GenerateGame.instance.selected.occupiedBy.title.Contains("King"))
            {
                if (GenerateGame.instance.selected.occupiedBy.isWhite)
                {
                    GenerateGame.instance.whiteKing = false;
                }
                else
                {
                    GenerateGame.instance.blackKing = false;
                }
            }
            if (GenerateGame.instance.selected.occupiedBy.isWhite)
            {
                g = GameObject.Find("White Points");
            }
            else
            {
                g = GameObject.Find("Black Points");
            }
            int value = int.Parse(g.gameObject.GetComponent<Text>().text);
            g.gameObject.GetComponent<Text>().text = (value + w).ToString();
            Destroy(GenerateGame.instance.selected.occupiedBy.gameObject);
        }
    }

    public static void removePiece(Piece p)
    {
        int w = p.cost;
        GameObject g;
        if (p.title.Contains("King"))
        {
            if (p.isWhite)
            {
                GenerateGame.instance.whiteKing = false;
            }
            else
            {
                GenerateGame.instance.blackKing = false;
            }
        }
        if (p.isWhite)
        {
            g = GameObject.Find("White Points");
        }
        else
        {
            g = GameObject.Find("Black Points");
        }
        int value = int.Parse(g.gameObject.GetComponent<Text>().text);
        g.gameObject.GetComponent<Text>().text = (value + w).ToString();
        Destroy(p.gameObject);
    }
    
}
