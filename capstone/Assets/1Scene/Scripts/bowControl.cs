using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class bowControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bow;
    public InputActionReference leftGrabAction;
    public GameObject leftController;

    private bool isGrabbing = false;

    void OnEnable()
    {
        leftGrabAction.action.performed += GrabPerformed;
        leftGrabAction.action.canceled += GrabCanceled;
        leftGrabAction.action.Enable();
    }

    void OnDisable()
    {
        leftGrabAction.action.performed -= GrabPerformed;
        leftGrabAction.action.Disable();
    }

    void GrabPerformed(InputAction.CallbackContext context)
    {
        Debug.Log("grabstart");
        isGrabbing = true;
        RemoveControllerModel();
    }
    void GrabCanceled(InputAction.CallbackContext context)
    {
        Debug.Log("grabend");
        isGrabbing = false;
        RestoreControllerModel();
    }
    void MoveBowToControllerPosition()
    {
        bow.transform.position = leftController.transform.position;
        bow.transform.rotation = leftController.transform.rotation;
    }

    void RemoveControllerModel()
    {
        Renderer[] renderers = leftController.GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            renderer.enabled = false;
        }
    }
    void RestoreControllerModel()
    {
        Renderer[] renderers = leftController.GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            renderer.enabled = true;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrabbing)
        {
            MoveBowToControllerPosition();
        }
    }
}
