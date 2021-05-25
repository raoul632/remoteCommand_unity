using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleTask : SimpleTask
{
    public override void Execute(GameObject objectControlled, GameObject remoteControl)
    {
        
    }

  

    // Start is called before the first frame update
   
}

public class MoveBackwardTask : SimpleTask
{
    public override void Execute(GameObject objectControlled, GameObject remoteControl)
    {
        if (interpolatedFramesCount >= 0)
        {
            Vector3 interpolatedPosition = Vector3.Lerp(objectControlled.transform.position, objectControlled.transform.position - remoteControl.transform.right, interpolatedFramesCount);
            objectControlled.transform.position = interpolatedPosition;
            interpolatedFramesCount--;
        }
        else
        {
            TaskEnding = true; 
        }
    }
}

public class MoveForwardTask : SimpleTask
{
    public override void Execute(GameObject objectControlled, GameObject remoteControl)
    {
        if (interpolatedFramesCount >= 0)
        {
            Vector3 interpolatedPosition = Vector3.Lerp(objectControlled.transform.position, objectControlled.transform.position + remoteControl.transform.right, interpolatedFramesCount);
            objectControlled.transform.position = interpolatedPosition;
            interpolatedFramesCount--;
        }
        else
        {
            TaskEnding = true;
        }
    }
}

