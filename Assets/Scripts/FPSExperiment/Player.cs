using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        KeyboardInput();	
	}

   void KeyboardInput()
    {
        if (Input.GetAxis("Vertical") > 0) {
            
        }
    }
}
