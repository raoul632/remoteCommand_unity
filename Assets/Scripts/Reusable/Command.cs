using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command 
{
    // Start is called before the first frame update
   public abstract void  Execute(PassiveObjectController obj);
    public virtual void Undo() { }
}

public class AdvanceObjectCommand : Command
{
    public override void Execute(PassiveObjectController obj)
    {
        obj.PushForward(); 
    }
}

public class BackOffObject : Command
{
    public override void Execute(PassiveObjectController obj)
    {
        //obj.Translate(Vector3.right * 100 * Time.deltaTime * -1);
        obj.PushBackwards(); 
    }
}

public class RotateLeftObject : Command
{
    public override void Execute(PassiveObjectController obj)
    {
        // obj.Translate(Vector3.right * 100 * Time.deltaTime * -1);
        obj.RotateLeft(); 
      
    }
}


public class RotateRightObject : Command
{
    public override void Execute(PassiveObjectController obj)
    {
        obj.RotateRight(); 
    }
}


public class RotateBackObject : Command
{
    public override void Execute(PassiveObjectController obj)
    {
        obj.RotateBackwards(); 
    }
}

public class RotateForwardObject : Command
{
    public override void Execute(PassiveObjectController obj)
    {
        obj.RotateForward(); 
    }
}