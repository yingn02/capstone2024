using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class grabPoint : MonoBehaviour
{
    public arrowControl ArrowControl;

    public GameObject rightController;
    private bool isGrabbing = false;

    private Vector3 startPosition;
    private Vector3 startControllerPosition;

    public Transform bowpoint;
    public Transform bowpoint2;

    public bowControl bow;

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
        float distanceMoved = Vector3.Distance(rightController.transform.position, startControllerPosition);
        ArrowControl.fire(distanceMoved);
        bow.haveArrow = false;
    }

    public void reloadArrow(GameObject arrow)
    {
        ArrowControl = arrow.GetComponent<arrowControl>();
        transform.position = bowpoint2.position;
        startPosition = bowpoint2.position;
        startControllerPosition = rightController.transform.position;
        transform.rotation = bowpoint2.rotation;
        calculatePosition();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrabbing)
        {
            calculatePosition();
        }
    }
    void calculatePosition()
    {
        Vector3 lineDirection = (bowpoint.position - startPosition).normalized;
        Vector3 controllerMovement = rightController.transform.position - startControllerPosition;

        float movementProjection = Vector3.Dot(controllerMovement, lineDirection);

        Vector3 newPosition = startPosition + lineDirection * movementProjection;
        transform.position = newPosition;
    }
}
