using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour {

    public static GlobalVariables instance;
    public static List<Piece> pieces;

    void Start()
    {
        instance = this;
        pieces = getPiece();
    }

    void Update()
    {

    }

    public List<Piece> getPiece()
    {
        Object[] pieces = Resources.LoadAll("Pieces 1");
        List<Piece> p = new List<Piece>();
        for(int i =0; i < pieces.Length; i++)
        {
            GameObject g = (GameObject)pieces[i];
            p.Add(g.GetComponent<Piece>().Init());
        }

        return p;
    }
}
