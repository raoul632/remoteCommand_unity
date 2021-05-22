using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum ControllerState
{
    On, Off,OnDetect
}

enum MaterialGloom
{
    GloomEmissiveOffSelect= 0,
    GloomEmissionOnSelect = 1,
    GloomEmissionOff = 2,
}
public class RemoteController : MonoBehaviour
{

    [SerializeField] GameObject ButtonOnOff;
    [SerializeField] GameObject RemoteControllBody;

    [SerializeField] GameObject RayCastOrigin; 

    [SerializeField] float buttonOffsetWhenPressed = 0.04f;
    [SerializeField] float stepButtonPressed = 0.01f;

    [SerializeField] List<Material> _GlommLightOnOff; 
    
    
    private ControllerState _controllerState;
    private MeshRenderer _remoteBodyMeshRenderer;

    private CommandStack commandStack; 




    // Start is called before the first frame update

    private void Awake()
    {
        commandStack = new CommandStack(); 
        _remoteBodyMeshRenderer = RemoteControllBody.GetComponent<MeshRenderer>();     
    }


    void Start()
    {
        _controllerState = ControllerState.Off; 
    }

    // Update is called once per frame
    void Update()
    {
        //when i press alpha 0 i need to push button down for a short amount of time and activate red material 
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            if (_controllerState == ControllerState.On)
            {
                print("switch to off");
                _controllerState = ControllerState.Off;
            }
            else if(_controllerState == ControllerState.Off)
            {
                print("switch to on");
                _controllerState = ControllerState.On;
            }
          
            StartCoroutine(PushButtonDown(ButtonOnOff));
            //simple toggle function
        }

        // test if something is detected by the remote command
        RemoteCommandIsOn();

        GameObject objInControl = IsObjectInFrontOfRemote(); 

        if(objInControl != null)
        {
            _controllerState = ControllerState.OnDetect; 
        }
        else
        {
            _controllerState = ControllerState.On;
        }

        //if its on detect i can move object 
        if (_controllerState == ControllerState.OnDetect)
        {

            if (Input.GetKeyDown(KeyCode.Keypad9))
            {
                commandStack.ExecuteCommand(new AdvanceObjectCommand(), objInControl.GetComponent<PassiveObjectController>()); 
            }
            else if (Input.GetKeyDown(KeyCode.Keypad3))
            {
                commandStack.ExecuteCommand(new BackOffObject(), objInControl.GetComponent<PassiveObjectController>());
            }
        }


    }

    //sample i push button, the light goes on and the button come back to its initial state 
    IEnumerator PushButtonDown(GameObject gameObject)
    {
        
        float posYtarget = gameObject.transform.localPosition.y - buttonOffsetWhenPressed; 
        while(gameObject.transform.localPosition.y >= posYtarget)
        {

            gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y - stepButtonPressed, gameObject.transform.localPosition.z);
            yield return new WaitForSeconds(.01f); 
        }
        
        StartCoroutine(PushButtonUp(ButtonOnOff));
    }

    IEnumerator PushButtonUp(GameObject gameObject)
    {
        float posYtarget = gameObject.transform.localPosition.y + buttonOffsetWhenPressed;
        while (gameObject.transform.localPosition.y <= posYtarget)
        {

            gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y + stepButtonPressed, gameObject.transform.localPosition.z);
            yield return new WaitForSeconds(.01f);
        }


     
    }
   /// <summary>
    /// test if an object can be detected by a raycast ?
    /// </summary>
    private GameObject IsObjectInFrontOfRemote()
    {
        RaycastHit hit;
        Ray ray = new Ray(RayCastOrigin.transform.position, RayCastOrigin.transform.right * 100);
        Debug.DrawRay(RayCastOrigin.transform.position, RayCastOrigin.transform.right * 100, Color.green);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {
                return hit.collider.gameObject; 
            }
        }

        return null; 
    }

 

    /// <summary>
    /// If the state of this controller is on, set the material as a gloomy red 
    /// </summary>
    private void RemoteCommandIsOn()
    {
        
        if(_controllerState == ControllerState.On || _controllerState == ControllerState.OnDetect)
        {
            if(_controllerState == ControllerState.On)
            {
                ChangeMaterialRemoteControl((int)MaterialGloom.GloomEmissionOnSelect);
            }
            else
            {
              
                ChangeMaterialRemoteControl((int)MaterialGloom.GloomEmissiveOffSelect); 
            }
            
        }
        else
        {
            ChangeMaterialRemoteControl((int)MaterialGloom.GloomEmissionOff);
        }
    }
    /// <summary>
    /// Cannot change element alone need to replace the whole array 
    /// take enum MaterialGloom at parameter 
    /// </summary>
    /// <param name="num"></param>

    private void ChangeMaterialRemoteControl(int num)
    {
        Material[] mats = _remoteBodyMeshRenderer.materials;
        //cannot change an element need to replace the whole array; 
        mats[1] = _GlommLightOnOff[num];
        _remoteBodyMeshRenderer.materials = mats;
    }
}
