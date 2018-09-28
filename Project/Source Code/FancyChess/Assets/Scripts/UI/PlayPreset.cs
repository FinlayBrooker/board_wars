using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayPreset : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void playGame(int scene)
    {
        int v = GameObject.Find("Preset").GetComponent<Dropdown>().value;
        GameObject setupObject = new GameObject();
        setupObject.name = "SetupObject";
        setupObject.AddComponent<GameInfoHolder>();
        List<Piece> black = new List<Piece>();
        List<Piece> white = new List<Piece>();
        switch (v)
        {
            case 0:
                //chess
                
                Piece p, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15;
                for (int i = 0; i < 8; i++)
                {
                    Piece p0 = Instantiate(GlobalVariables.pieces[0], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                    p0.position = new Vector2(6, i);
                    Debug.Log(p0.position);
                    black.Add(p0);
                    Debug.Log(black[i].position);
                }
                p = Instantiate(GlobalVariables.pieces[3], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                p.position = new Vector2(7, 0);
                black.Add(p);
                p1 = Instantiate(GlobalVariables.pieces[3], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                p1.position = new Vector2(7, 7);
                black.Add(p1);
                p2 = Instantiate(GlobalVariables.pieces[1], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                p2.position = new Vector2(7, 1);
                black.Add(p2);
                p3 = Instantiate(GlobalVariables.pieces[1], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                p3.position = new Vector2(7, 6);
                black.Add(p3);
                p4 = Instantiate(GlobalVariables.pieces[2], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                p4.position = new Vector2(7, 2);
                black.Add(p4);
                p5 = Instantiate(GlobalVariables.pieces[2], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                p5.position = new Vector2(7, 5);
                black.Add(p5);
                p6 = Instantiate(GlobalVariables.pieces[4], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                p6.position = new Vector2(7, 3);
                black.Add(p6);
                p7 = Instantiate(GlobalVariables.pieces[5], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                p7.position = new Vector2(7, 4);
                black.Add(p7);

                for (int i = 0; i < 8; i++)
                {
                    Piece p0 = Instantiate(GlobalVariables.pieces[0], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                    p0.position = new Vector2(1, i);
                    white.Add(p0);
                }
                p8 = Instantiate(GlobalVariables.pieces[3], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                p8.position = new Vector2(0, 0);
                white.Add(p8);
                p9 = Instantiate(GlobalVariables.pieces[3], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                p9.position = new Vector2(0, 7);
                white.Add(p9);
                p10 = Instantiate(GlobalVariables.pieces[1], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                p10.position = new Vector2(0, 1);
                white.Add(p10);
                p11 = Instantiate(GlobalVariables.pieces[1], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                p11.position = new Vector2(0, 6);
                white.Add(p11);
                p12 = Instantiate(GlobalVariables.pieces[2], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                p12.position = new Vector2(0, 2);
                white.Add(p12);
                p13 = Instantiate(GlobalVariables.pieces[2], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                p13.position = new Vector2(0, 5);
                white.Add(p13);
                p14 = Instantiate(GlobalVariables.pieces[4], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                p14.position = new Vector2(0, 3);
                white.Add(p14);
                p15 = Instantiate(GlobalVariables.pieces[5], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                p15.position = new Vector2(0, 4);
                white.Add(p15);
                foreach (Piece item in black)
                {
                    Debug.Log(item.position);
                }
                setupObject.GetComponent<GameInfoHolder>().black = black;
                setupObject.GetComponent<GameInfoHolder>().white = white;
                setupObject.GetComponent<GameInfoHolder>().boardSize = 8;
                setupObject.GetComponent<GameInfoHolder>().promoRows = 1;
                setupObject.GetComponent<GameInfoHolder>().useCaptured = false;
                setupObject.GetComponent<GameInfoHolder>().rules = new Checkmate();
                break;
            case 1:
                //shogi
                Piece pi;
                for (int i = 0; i < 9; i++)
                {
                    pi = Instantiate(GlobalVariables.pieces[6], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                    pi.position = new Vector2(6, i);
                    black.Add(pi);
                }
                pi = pi = Instantiate(GlobalVariables.pieces[7], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pi.position = new Vector2(8, 0);
                black.Add(pi);
                pi = pi = Instantiate(GlobalVariables.pieces[7], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pi.position = new Vector2(8, 8);
                black.Add(pi);
                pi = pi = Instantiate(GlobalVariables.pieces[8], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pi.position = new Vector2(8, 1);
                black.Add(pi);
                pi = pi = Instantiate(GlobalVariables.pieces[8], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pi.position = new Vector2(8, 7);
                black.Add(pi);
                pi = pi = Instantiate(GlobalVariables.pieces[9], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pi.position = new Vector2(7, 1);
                black.Add(pi);
                pi = pi = Instantiate(GlobalVariables.pieces[10], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pi.position = new Vector2(7, 7);
                black.Add(pi);
                pi = pi = Instantiate(GlobalVariables.pieces[11], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pi.position = new Vector2(8, 2);
                black.Add(pi);
                pi = pi = Instantiate(GlobalVariables.pieces[11], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pi.position = new Vector2(8, 6);
                black.Add(pi);
                pi = pi = Instantiate(GlobalVariables.pieces[12], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pi.position = new Vector2(8, 3);
                black.Add(pi);
                pi = pi = Instantiate(GlobalVariables.pieces[12], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pi.position = new Vector2(8, 5);
                black.Add(pi);
                pi = pi = Instantiate(GlobalVariables.pieces[13], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pi.position = new Vector2(8, 4);
                black.Add(pi);
                //
                for (int i = 0; i < 9; i++)
                {
                    pi = Instantiate(GlobalVariables.pieces[6], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                    pi.position = new Vector2(2, i);
                    white.Add(pi);
                }
                pi = pi = Instantiate(GlobalVariables.pieces[7], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pi.position = new Vector2(0, 0);
                white.Add(pi);
                pi = pi = Instantiate(GlobalVariables.pieces[7], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pi.position = new Vector2(0, 8);
                white.Add(pi);
                pi = pi = Instantiate(GlobalVariables.pieces[8], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pi.position = new Vector2(0, 1);
                white.Add(pi);
                pi = pi = Instantiate(GlobalVariables.pieces[8], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pi.position = new Vector2(0, 7);
                white.Add(pi);
                pi = pi = Instantiate(GlobalVariables.pieces[9], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pi.position = new Vector2(1, 1);
                white.Add(pi);
                pi = pi = Instantiate(GlobalVariables.pieces[10], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pi.position = new Vector2(1, 7);
                white.Add(pi);
                pi = pi = Instantiate(GlobalVariables.pieces[11], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pi.position = new Vector2(0, 2);
                white.Add(pi);
                pi = pi = Instantiate(GlobalVariables.pieces[11], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pi.position = new Vector2(0, 6);
                white.Add(pi);
                pi = pi = Instantiate(GlobalVariables.pieces[12], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pi.position = new Vector2(0, 3);
                white.Add(pi);
                pi = pi = Instantiate(GlobalVariables.pieces[12], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pi.position = new Vector2(0, 5);
                white.Add(pi);
                pi = pi = Instantiate(GlobalVariables.pieces[13], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pi.position = new Vector2(0, 4);
                white.Add(pi);
                setupObject.GetComponent<GameInfoHolder>().black = black;
                setupObject.GetComponent<GameInfoHolder>().white = white;
                setupObject.GetComponent<GameInfoHolder>().boardSize = 9;
                setupObject.GetComponent<GameInfoHolder>().promoRows = 3;
                setupObject.GetComponent<GameInfoHolder>().useCaptured = true;
                setupObject.GetComponent<GameInfoHolder>().rules = new Capture();
                break;
            case 2:
                // war
                Piece pc;
                for (int i = 0; i < 13; i++)
                {
                    pc = Instantiate(GlobalVariables.pieces[0], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                    pc.position = new Vector2(9, i);
                    black.Add(pc);
                }
                for (int i = 0; i < 13; i++)
                {
                    if (i % 2 == 1)
                    {
                        pc = Instantiate(GlobalVariables.pieces[14], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                        pc.position = new Vector2(10, i);
                        black.Add(pc);
                    }
                }
                pc = Instantiate(GlobalVariables.pieces[12], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pc.position = new Vector2(10, 0);
                black.Add(pc);
                pc = Instantiate(GlobalVariables.pieces[12], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pc.position = new Vector2(10, 6);
                black.Add(pc);
                pc = Instantiate(GlobalVariables.pieces[12], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pc.position = new Vector2(10, 12);
                black.Add(pc);
                pc = Instantiate(GlobalVariables.pieces[1], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pc.position = new Vector2(10, 2);
                black.Add(pc);
                pc = Instantiate(GlobalVariables.pieces[1], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pc.position = new Vector2(10, 10);
                black.Add(pc);
                pc = Instantiate(GlobalVariables.pieces[16], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pc.position = new Vector2(10, 8);
                black.Add(pc);
                pc = Instantiate(GlobalVariables.pieces[16], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pc.position = new Vector2(10, 4);
                black.Add(pc);
                pc = Instantiate(GlobalVariables.pieces[10], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pc.position = new Vector2(11, 3);
                black.Add(pc);
                pc = Instantiate(GlobalVariables.pieces[9], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pc.position = new Vector2(11, 9);
                black.Add(pc);
                pc = Instantiate(GlobalVariables.pieces[3], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pc.position = new Vector2(12, 12);
                black.Add(pc);
                pc = Instantiate(GlobalVariables.pieces[3], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pc.position = new Vector2(12, 0);
                black.Add(pc);
                pc = Instantiate(GlobalVariables.pieces[15], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pc.position = new Vector2(12, 1);
                black.Add(pc);
                pc = Instantiate(GlobalVariables.pieces[15], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pc.position = new Vector2(12, 11);
                black.Add(pc);
                pc = Instantiate(GlobalVariables.pieces[7], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pc.position = new Vector2(12, 10);
                black.Add(pc);
                pc = Instantiate(GlobalVariables.pieces[7], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pc.position = new Vector2(12, 2);
                black.Add(pc);
                pc = Instantiate(GlobalVariables.pieces[2], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pc.position = new Vector2(12, 3);
                black.Add(pc);
                pc = Instantiate(GlobalVariables.pieces[2], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pc.position = new Vector2(12, 9);
                black.Add(pc);
                pc = Instantiate(GlobalVariables.pieces[17], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pc.position = new Vector2(12, 8);
                black.Add(pc);
                pc = Instantiate(GlobalVariables.pieces[17], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pc.position = new Vector2(12, 4);
                black.Add(pc);
                pc = Instantiate(GlobalVariables.pieces[4], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pc.position = new Vector2(12, 5);
                black.Add(pc);
                pc = Instantiate(GlobalVariables.pieces[5], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pc.position = new Vector2(12, 6);
                black.Add(pc);
                pc = Instantiate(GlobalVariables.pieces[18], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pc.position = new Vector2(12, 7);
                black.Add(pc);
                //
                for (int i = 0; i < 13; i++)
                {
                    pc = Instantiate(GlobalVariables.pieces[0], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                    pc.position = new Vector2(3, i);
                    white.Add(pc);
                }
                for (int i = 0; i < 13; i++)
                {
                    if (i % 2 == 1)
                    {
                        pc = Instantiate(GlobalVariables.pieces[14], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                        pc.position = new Vector2(2, i);
                        white.Add(pc);
                    }
                }
                pc = Instantiate(GlobalVariables.pieces[12], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pc.position = new Vector2(2, 0);
                white.Add(pc);
                pc = Instantiate(GlobalVariables.pieces[12], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pc.position = new Vector2(2, 6);
                white.Add(pc);
                pc = Instantiate(GlobalVariables.pieces[12], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pc.position = new Vector2(2, 12);
                white.Add(pc);
                pc = Instantiate(GlobalVariables.pieces[1], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pc.position = new Vector2(2, 2);
                white.Add(pc);
                pc = Instantiate(GlobalVariables.pieces[1], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pc.position = new Vector2(2, 10);
                white.Add(pc);
                pc = Instantiate(GlobalVariables.pieces[16], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pc.position = new Vector2(2, 8);
                white.Add(pc);
                pc = Instantiate(GlobalVariables.pieces[16], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pc.position = new Vector2(2, 4);
                white.Add(pc);
                pc = Instantiate(GlobalVariables.pieces[10], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pc.position = new Vector2(1, 3);
                white.Add(pc);
                pc = Instantiate(GlobalVariables.pieces[9], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pc.position = new Vector2(1, 9);
                white.Add(pc);
                pc = Instantiate(GlobalVariables.pieces[3], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pc.position = new Vector2(0, 12);
                white.Add(pc);
                pc = Instantiate(GlobalVariables.pieces[3], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pc.position = new Vector2(0, 0);
                white.Add(pc);
                pc = Instantiate(GlobalVariables.pieces[15], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pc.position = new Vector2(0, 1);
                white.Add(pc);
                pc = Instantiate(GlobalVariables.pieces[15], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pc.position = new Vector2(0, 11);
                white.Add(pc);
                pc = Instantiate(GlobalVariables.pieces[7], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pc.position = new Vector2(0, 10);
                white.Add(pc);
                pc = Instantiate(GlobalVariables.pieces[7], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pc.position = new Vector2(0, 2);
                white.Add(pc);
                pc = Instantiate(GlobalVariables.pieces[2], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pc.position = new Vector2(0, 3);
                white.Add(pc);
                pc = Instantiate(GlobalVariables.pieces[2], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pc.position = new Vector2(0, 9);
                white.Add(pc);
                pc = Instantiate(GlobalVariables.pieces[17], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pc.position = new Vector2(0, 8);
                white.Add(pc);
                pc = Instantiate(GlobalVariables.pieces[17], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pc.position = new Vector2(0, 4);
                white.Add(pc);
                pc = Instantiate(GlobalVariables.pieces[4], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pc.position = new Vector2(0, 5);
                white.Add(pc);
                pc = Instantiate(GlobalVariables.pieces[5], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pc.position = new Vector2(0, 6);
                white.Add(pc);
                pc = Instantiate(GlobalVariables.pieces[18], Vector3.zero, Quaternion.Euler(-90, 0, 0)) as Piece;
                pc.position = new Vector2(0, 7);
                white.Add(pc);
                setupObject.GetComponent<GameInfoHolder>().black = black;
                setupObject.GetComponent<GameInfoHolder>().white = white;
                setupObject.GetComponent<GameInfoHolder>().boardSize = 13;
                setupObject.GetComponent<GameInfoHolder>().promoRows = 2;
                setupObject.GetComponent<GameInfoHolder>().useCaptured = true;
                setupObject.GetComponent<GameInfoHolder>().rules = new Capture();

                break;
            case 3:
                break;
            case 4:
                break;
            default:
                break;

            
        }
        DontDestroyOnLoad(GameObject.Find("SetupObject"));
        SceneManager.LoadScene(scene);
    }

}
