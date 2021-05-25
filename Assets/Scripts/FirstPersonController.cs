using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    [SerializeField]private GameObject cam;
    [SerializeField]private GameObject character;
    [SerializeField] private Transform cameraRef; 

    Quaternion cameraRot;
    Transform cameraTransform; 
    Quaternion characterRot;

    float Xsensitivity = 2;
    float Ysensitivity = 2;

    float MinimumX = -90;
    float MaximumX = 90; 





    private void Start()
    {
        
       
        //cameraRot = cam.transform.localRotation;
        cameraTransform = cam.transform;
        characterRot = character.transform.localRotation;

    }

    void Update()
    {

        //the camera is NOT moving its the remote command only 
        float yRot = Input.GetAxis("Mouse Y") * Ysensitivity;
        float xRot = Input.GetAxis("Mouse X") * Xsensitivity;
        //cameraRot *= Quaternion.Euler(-xRot, 0, 0);
        characterRot *= Quaternion.Euler(0, xRot, yRot);

        //cam.transform.localRotation = cameraRot; 
        character.transform.localRotation = characterRot; 

        MovePlayer();

    }



    private void MovePlayer()
    {
        float v = Input.GetAxis("Vertical") * speed;
        float h = Input.GetAxis("Horizontal") * speed ;// rotationSpeed;

        //Vector3 camForward = Vector3.Scale(cameraRef.forward, new Vector3(1, 0, 1)).normalized;
        //print("cam forward is " + camForward);
        //Vector3 moveVector = (translation * camForward + rotation * cameraRef.right).normalized * speed * Time.deltaTime;
        //print("move vector is " + moveVector);
        //transform.Translate(moveVector);

          Vector3 move = new Vector3(v * Time.deltaTime * speed, 0, h* Time.deltaTime * cameraTransform.transform.right.z) ; 
          transform.Translate(move);
         
        // transform.Rotate(0, rotation * Time.deltaTime, 0);

    }
}
