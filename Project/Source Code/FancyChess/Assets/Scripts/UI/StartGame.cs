using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void startGame(int scene)
    {
        if(GenerateGame.instance.whiteKing != true && GenerateGame.instance.blackKing != true)
        {
            return;
        }
        int boardSize = GenerateGame.instance.boardSize;
        int promoRows = int.Parse(GameObject.Find("PromoRows").GetComponentInChildren<Text>().text);
        List<Piece> white = new List<Piece>();
        List<Piece> black = new List<Piece>();
        foreach (List<GeneratedTile> item in GenerateGame.instance.board)
        {
            foreach (GeneratedTile i in item)
            {
                if (i.occupied)
                {
                    if (i.isWhite)
                    {
                        white.Add(i.occupiedBy);
                    }
                    else
                    {
                        black.Add(i.occupiedBy);
                    }
                }
            }
        }
        int s = GameObject.Find("Rules").GetComponent<Dropdown>().value;
        Rules rules;
        switch (s)
        {
            case 0:
                rules = new Checkmate();
                break;

            case 1:
                rules = new Capture();
                break;

            case 2:
                rules = new Elimination();
                break;

            default:
                rules = new Checkmate();
                break;
        }

        

        GameObject setupObject = new GameObject();
        setupObject.name = "SetupObject";
        setupObject.AddComponent<GameInfoHolder>();
        setupObject.GetComponent<GameInfoHolder>().black = black;
        setupObject.GetComponent<GameInfoHolder>().white = white;
        setupObject.GetComponent<GameInfoHolder>().boardSize = boardSize;
        setupObject.GetComponent<GameInfoHolder>().promoRows = promoRows;
        setupObject.GetComponent<GameInfoHolder>().useCaptured = GameObject.Find("Captured").GetComponentInChildren<Toggle>().isOn;
        setupObject.GetComponent<GameInfoHolder>().rules = rules;

        if (GameObject.Find("Player"))
        {
            setupObject.GetComponent<GameInfoHolder>().player = GameObject.Find("Player").GetComponent<Dropdown>().value;
        }
        if (GameObject.Find("AI"))
        {
            setupObject.GetComponent<GameInfoHolder>().ai = GameObject.Find("AI").GetComponent<Dropdown>().value;
        }

        DontDestroyOnLoad(GameObject.Find("SetupObject"));
        SceneManager.LoadScene(scene);

    }
}
