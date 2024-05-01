using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class bowControl : MonoBehaviour
{
    public InputActionReference leftGrabAction;
    public GameObject leftController;
    public GameObject arrowPrefab;
    public GameObject bowPoint;
    public GameObject arrowPoint;
    public grabPoint grabpoint;

    private bool isGrabbing = false;
    public bool haveArrow = false;
    private GameObject arrow;

    public bool player = true;

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
        //RemoveControllerModel();
    }
    void GrabCanceled(InputAction.CallbackContext context)
    {
        isGrabbing = false;
        //RestoreControllerModel();
    }
    void MoveBowToControllerPosition()
    {
        this.transform.position = leftController.transform.position;
        this.transform.rotation = leftController.transform.rotation;
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
        if (isGrabbing && player)
        {
            MoveBowToControllerPosition();
        }
        /*if (!haveArrow)
        {
            Invoke("reloadArrow", 2f);
            haveArrow = true;
        }*/
        
    }
    public void reloadArrow()
    {
        if (arrowPrefab != null && bowPoint != null)
        {
            arrow = Instantiate(arrowPrefab, bowPoint.transform.position,
                bowPoint.transform.rotation);
            arrow.transform.parent = bowPoint.transform;
            grabpoint.reloadArrow(arrow);
            haveArrow = true;
        }
        else
        {
            Debug.LogWarning("arrowPrefab 또는 bowPoint가 설정되지 않았습니다.");
        }
    }
}
