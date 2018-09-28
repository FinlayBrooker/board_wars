using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsValue : MonoBehaviour {

	// Use this for initialization
	void Start () {
        resetValue(8);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void resetValue(int size)
    {
        int value = size * 6 + size;
        GetComponent<Text>().text = value.ToString();
    }
}
