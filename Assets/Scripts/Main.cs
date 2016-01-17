using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Main : MonoBehaviour {
    CommandManager comManager = new CommandManager();
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        KeyboardInput();
        MouseInput();
	}

    void KeyboardInput() {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            comManager.ChangeCommand("none");
            Text txt = (Text)GameObject.Find("action").GetComponent("Text");
            txt.text = "no action";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            comManager.ChangeCommand("move");
            Text txt = (Text)GameObject.Find("action").GetComponent("Text");
            txt.text = "move";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            comManager.ChangeCommand("attack");
            Text txt = (Text)GameObject.Find("action").GetComponent("Text");
            txt.text = "attack";
        }
    }

    void MouseInput() {
        if (Input.GetMouseButtonDown(0))
        {
            comManager.UseCommand();
        }
    }
}
