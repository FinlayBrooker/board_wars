using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropdownChange : MonoBehaviour {

    public void changeArray(int value)
    {
        GenerateButtons.instance.clear();
        GenerateButtons.instance.createButtons(value+3);
        
    }
}
