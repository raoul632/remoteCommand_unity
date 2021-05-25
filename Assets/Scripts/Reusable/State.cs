using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SimpleTask 
{
    public int interpolatedFramesCount = 100;
    public bool TaskEnding = false;
    

    // Start is called before the first frame update
    public abstract void Execute(GameObject objectControlled, GameObject remoteControl);

    
    

}
