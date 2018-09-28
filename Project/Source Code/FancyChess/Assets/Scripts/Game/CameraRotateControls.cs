using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotateControls : MonoBehaviour {

    public float dragSpeed = 1;
    private float y, x;
    private Vector3 dragOrigin;
    private Vector3 rotateValue;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(1))
        {
            dragOrigin = Input.mousePosition;
            y = Input.GetAxis("Mouse X");
            x = Input.GetAxis("Mouse Y");
            return;
        }

        if (!Input.GetMouseButton(1)) return;

        rotateValue = new Vector3(x, y * -1, 0);
        transform.eulerAngles = transform.eulerAngles - rotateValue;

        //transform.Rotate(move, Space.World);
    }
}
