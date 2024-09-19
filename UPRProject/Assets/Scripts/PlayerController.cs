using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CommandManger CommandManger;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ICommand moveRight = new Movecommand(transform, Vector3.right);
            CommandManger.ExecuteCommand(moveRight);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ICommand moveLeft = new Movecommand(transform, Vector3.left);
            CommandManger.ExecuteCommand(moveLeft);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            CommandManger.UndoLastCommand();
        }
    }
}
