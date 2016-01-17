using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CommandManager : MonoBehaviour {
    enum Command {
        NONE,
        MOVE,
        ATTACK
    }

    Command activeCommand = Command.NONE;
    public Dictionary<string,AbstractCommand> commandList = new Dictionary<string, AbstractCommand>();
    public CommandManager(){
        commandList.Add("move", new MoveCom());
        commandList.Add("attack", new AttackCom());
    }
    public void UseCommand() {
        switch(activeCommand){
            case Command.NONE:
                Debug.Log("no command active");
                break;
            case Command.MOVE:
                commandList["move"].Use(Input.mousePosition);
                break;
            case Command.ATTACK:
                commandList["attack"].Use(Input.mousePosition);
                break;
            default:
                Debug.LogError("Use Command: Not a valid Command");
                break;
        }
    }

    public void ChangeCommand(string com) { 
        com.ToLower();
        switch(com){
            case "none":
                activeCommand = Command.NONE;
                break;
            case "move":
                activeCommand = Command.MOVE;
                break;
            case "attack":
                activeCommand = Command.ATTACK;
                break;
            default:
                Debug.LogError("Change Command: Not a vaild Command");
                break;
        }
    }

}
