using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PassiveObjectController : MonoBehaviour
{
    //mecanism for moving object
    public int interpolationFramesCount = 100;

    [SerializeField] GameObject remoteControl; 
   public  enum InternalState
    {
        IDLE,
        MOVEFORWARD,
        MOVEBACKWARD,
        ROTATELEFT,
        ROTATERIGHT,
        ROTATEFORWARD,
        ROTATEBACKWARD,
    }

    private InternalState _internalState; 

    void Start()
    {
        _internalState = InternalState.IDLE; 
    }


    // Start is called before the first frame update
   

    public void PushForward()
    {
        _internalState = InternalState.MOVEFORWARD;
    }

    public void PushBackwards()
    {
        _internalState = InternalState.MOVEBACKWARD;
    }

    public void RotateForward()
    {
        _internalState = InternalState.ROTATEFORWARD;
    }

    public void RotateBackwards()
    {
        _internalState = InternalState.ROTATEBACKWARD;
    }

    public void RotateLeft()
    {
        _internalState = InternalState.ROTATELEFT;
    }

    public void RotateRight() 
    {
        _internalState = InternalState.ROTATERIGHT;
    }

    public void Nono (InternalState _internal){
        _internalState = _internal; 

    }


    // Update is called once per frame
    void Update()
    {
        switch (_internalState)
        {
            case InternalState.IDLE:
                //do nothing of course
            
                break;
            case InternalState.MOVEFORWARD:
                if ( interpolationFramesCount > 0)
                {
                    
                    Vector3 interpolatedPosition = Vector3.Lerp(gameObject.transform.position, gameObject.transform.position + remoteControl.transform.right , interpolationFramesCount);
                    gameObject.transform.position = interpolatedPosition;
                    interpolationFramesCount--; 
                }
                else
                {
                    interpolationFramesCount = 100; 
                    _internalState = InternalState.IDLE; 
                }
                break;
            case InternalState.MOVEBACKWARD:
                //    Vector3 interpolatedPosition = Vector3.Lerp(gameObject.transform.position, gameObject.transform.forward, interpolationFramesCount);
                //    gameObject.transform.position = interpolatedPosition;
                //
                break;
            case InternalState.ROTATELEFT:

                break;
            case InternalState.ROTATERIGHT:

                break;
            case InternalState.ROTATEFORWARD:

                break;
            case InternalState.ROTATEBACKWARD:

                break;
            default:
                break;
        }
    }
}
