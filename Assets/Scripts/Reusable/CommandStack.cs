using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandStack 
{
    private Stack<Command> _commandHistory = new Stack<Command>(); 

    public void ExecuteCommand(Command command, PassiveObjectController obj)
    {
        command.Execute(obj);
        _commandHistory.Push(command); 

    }

    public void UndoLastCommand()
    {
        if (_commandHistory.Count <= 0)
            return;

        _commandHistory.Pop().Undo(); 
    }
}
