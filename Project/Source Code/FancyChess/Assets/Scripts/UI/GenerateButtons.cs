using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateButtons : MonoBehaviour {

    public GameObject buttonprefab;
    public static GenerateButtons instance;
    public GameObject[,] whiteButtons;
    public GameObject[,] blackButtons;
    public ButtonHold lastclicked;
    public int size;
    public bool whiteKing = false;
    public bool blackKing = false;

    void Start()
    {
        instance = this;
        createButtons(3);
    }

	public void createButtons(int size)
    {
        this.size = size;
        Debug.Log(this.transform.localScale);
        float width = 320 / size;
        int rows = Mathf.CeilToInt( size / 3);
        whiteButtons = new GameObject[size, rows];
        blackButtons = new GameObject[size, rows];
        
        Debug.Log(rows);
        for(int i = 0; i < size; i++)
        {
            for(int j = 0; j < rows; j++)
            {
                whiteButtons[i, j] = Instantiate(buttonprefab,Vector3.zero,Quaternion.identity) as GameObject;
                RectTransform trans = whiteButtons[i, j].GetComponent<RectTransform>();
                trans.SetParent(this.transform,false);
                trans.sizeDelta = new Vector2(width, width);
                whiteButtons[i, j].transform.localPosition = new Vector3((i - Mathf.Floor(size / 2)) * width * 2, (j - Mathf.Floor(size / 2)) * width, 0);
                whiteButtons[i, j].GetComponent<ButtonHold>().white = true;
                whiteButtons[i, j].GetComponent<ButtonHold>().pos = new Vector2(i, j);
            }
        }
        for (int i = size-1; i >= 0; i--)
        {
            for (int j = rows-1; j >= 0; j--)
            {
                blackButtons[i, j] = Instantiate(buttonprefab, Vector3.zero, Quaternion.identity) as GameObject;
                RectTransform trans = blackButtons[i, j].GetComponent<RectTransform>();
                trans.SetParent(this.transform, false);
                trans.sizeDelta = new Vector2(width, width);
                blackButtons[i, j].transform.localPosition = new Vector3((i - Mathf.Floor(size / 2)) * width * 2, (j - Mathf.Floor(size / 2)) * width + 212, 0);
                blackButtons[i, j].GetComponent<ButtonHold>().white = false;
                blackButtons[i, j].GetComponent<ButtonHold>().pos = new Vector2(i, j);
            }
        }
    }

    public void clear()
    {
        foreach (var item in whiteButtons)
        {
            Destroy(item);
        }
        foreach (var item in blackButtons)
        {
            Destroy(item);
        }
    }
}
