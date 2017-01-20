using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       InputHandler();

    }

    private void InputHandler()
    {
        if (Input.GetButtonDown("X")) { Debug.Log("0"); }
        if (Input.GetButtonDown("Circle")) { Debug.Log("1"); }
        if (Input.GetButtonDown("Square")) { Debug.Log("2"); }
        if (Input.GetButtonDown("Triangle")) { Debug.Log("3"); }
    }
}
