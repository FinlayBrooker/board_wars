using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PromotionRowList : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        changeData(3);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void changeData(int rows)
    {
        List<Dropdown.OptionData> data = GetComponent<Dropdown>().options;
        data.Clear();
        for (int i = 0; i < rows; i++)
        {
            Dropdown.OptionData item = new Dropdown.OptionData();
            item.text = (i + 1).ToString();
            data.Add(item);
        }
        if(int.Parse(GetComponentInChildren<Text>().text) > int.Parse(data[data.Count - 1].text))
        {
            GetComponentInChildren<Text>().text = data[data.Count - 1].text;
        }
    }
}
