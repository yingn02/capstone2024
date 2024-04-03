using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.InputSystem;

public class grabPoint : MonoBehaviour
{
    public arrowControl ArrowControl;
    public InputActionReference rightGrabAction;

    private bool isGrabbing = false;

    private Vector3 startPosition;
    void OnEnable()
    {
        rightGrabAction.action.performed += GrabPerformed;
        rightGrabAction.action.canceled += GrabCanceled;
        rightGrabAction.action.Enable();
    }

    void OnDisable()
    {
        rightGrabAction.action.performed -= GrabPerformed;
        rightGrabAction.action.Disable();
    }

    void GrabPerformed(InputAction.CallbackContext context)
    {
        Debug.Log("rightstart");
        isGrabbing = true;
        startPosition = this.gameObject.transform.position;
    }
    void GrabCanceled(InputAction.CallbackContext context)
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
        
    }
}
