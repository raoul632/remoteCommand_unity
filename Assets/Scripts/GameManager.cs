using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Light lightControl; 
    private static GameManager _instance; 
    public static GameManager Instance
    {
        get
        {
            return _instance; 
        }
    }

    private void Awake()
    {
        if(_instance == null)
        {

            _instance = this;
        }
        else
        {

            print("There is a duplicate object ");

        }
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            lightControl.intensity += 1; 
        }

    }
}
