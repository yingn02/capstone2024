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
    public GameObject arrowPrefab;
    public GameObject arrowPoint;
    public grabPoint grabpoint;

    private bool isGrabbing = false;
    public bool haveArrow = true;


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
        isGrabbing = true;
        RemoveControllerModel();
    }
    void GrabCanceled(InputAction.CallbackContext context)
    {
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
        if (!haveArrow)
        {
            Invoke("reloadArrow", 2f);
            haveArrow = true;
        }
        
    }
    void reloadArrow()
    {
        if (arrowPrefab != null && arrowPoint != null)
        {
            GameObject arrow = Instantiate(arrowPrefab, arrowPoint.transform.position,
                arrowPoint.transform.rotation);
            grabpoint.reloadArrow(arrow);

            //haveArrow = true;
        }
        else
        {
            Debug.LogWarning("arrowPrefab 또는 arrowPoint가 설정되지 않았습니다.");
        }
    }
}
