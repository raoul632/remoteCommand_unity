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
    Quaternion characterRot;



    private void Start()
    {
        cameraRot = cam.transform.localRotation;
        characterRot = character.transform.localRotation;
       
    }

    void Update()
    {
        // Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1

        float yRot = Input.GetAxis("Mouse X");
        float xRot = Input.GetAxis("Mouse Y");

        cameraRot *= Quaternion.Euler(-xRot , yRot, 0);
        characterRot *= Quaternion.Euler(0, yRot , 0);

        this.transform.localRotation = characterRot;
        cam.transform.localRotation = cameraRot; 

        MovePlayer();

    }

    private void MovePlayer()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * speed ;// rotationSpeed;

        Vector3 camForward = Vector3.Scale(cameraRef.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 moveVector = (translation * camForward + rotation * cameraRef.right).normalized * speed * Time.deltaTime;

        transform.Translate(moveVector);

        /*
          float translation = Input.GetAxis("Vertical") * speed;
          float rotation = Input.GetAxis("Horizontal") * speed ;// rotationSpeed;
          transform.Translate(translation * Time.deltaTime * speed, 0, rotation * Time.deltaTime, Space.World);
         */
        // transform.Rotate(0, rotation * Time.deltaTime, 0);

    }
}
