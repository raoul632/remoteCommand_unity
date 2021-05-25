using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PassiveObjectController : MonoBehaviour
{
    //mecanism for moving object
    // TODO
    // move all command function to an single call
    public int interpolationFramesCount = 100;

    private SimpleTask _taskToDo; 

    [SerializeField] GameObject remoteControl; 



    void Start()
    {
        _taskToDo = new IdleTask(); 
    }

    public void PushForward()
    {
        _taskToDo = new MoveForwardTask(); 
    }

    public void PushBackwards()
    {
        _taskToDo = new MoveBackwardTask(); 
    }

    public void RotateForward()
    {
       
    }

    public void RotateBackwards()
    {
    }

    public void RotateLeft()
    {
       
    }

    public void RotateRight() 
    {
        
    }


    void Update()
    {
        if (!_taskToDo.TaskEnding)
        {
            _taskToDo.Execute(gameObject, remoteControl); 
        }

    }

  
}
