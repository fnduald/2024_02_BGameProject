using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommand
{
    void Execute();
    void Undo();
}
public class Movecommand : MonoBehaviour
{
    private Transform ObjectToMove;
    private Vector3 displacement;
    
    public Movecommand(Transform obj, Vector3 displacement)
    {
        this.ObjectToMove = obj;
        this.displacement = displacement;
    }
    public void Execute() { ObjectToMove.position += displacement; }
    public void Undo() { ObjectToMove.position -= displacement; }
}

public class CommandManger : MonoBehaviour
{
    public Stack<ICommand>commandHistory = new Stack<ICommand>();
    public void ExecuteCommand(ICommand command)
    { 
        command.Execute();
        commandHistory.Push(command);
    }
    public void UndoLastCommand()
    {
        if (commandHistory.Count > 0)
        {
            ICommand lastcommand = commandHistory.Pop();
            lastcommand.Undo();
        }
    }
}
