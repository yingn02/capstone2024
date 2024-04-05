using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.InputSystem;

public class grabPoint : MonoBehaviour
{
    public arrowControl ArrowControl;

    public GameObject rightController;
    private bool isGrabbing = false;

    private Vector3 startPosition;
    private Vector3 startControllerPosition;

    public void grabPerformed()
    {
        Debug.Log("rightstart");
        isGrabbing = true;
        startPosition = this.gameObject.transform.position;
        startControllerPosition = rightController.transform.position;
    }
    public void grabCanceled()
    {
        Debug.Log("rightend");
        isGrabbing = false;
        calculateDistance();

    }
    void calculateDistance()
    {
        float zdiff = startPosition.z - this.gameObject.transform.position.z;
        ArrowControl.fire(zdiff);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isGrabbing)
        {
            transform.position = new Vector3(startPosition.x, startPosition.y, 
                startPosition.z + rightController.transform.position.z - startControllerPosition.z);
        }
    }
}
