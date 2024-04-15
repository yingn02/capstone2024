using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class grabPoint : MonoBehaviour
{
    public GameObject arrow;
    public arrowControl ArrowControl;

    public GameObject rightController;
    private bool isGrabbing = false;

    private Vector3 startPosition;
    private Vector3 startControllerPosition;

    public Transform bowpoint;
    public Transform bowpoint2;

    public bowControl bow;
    private GameManager gameManager;
    

    public void grabPerformed()
    {
        //Debug.Log("rightstart");
        isGrabbing = true;
        startPosition = this.gameObject.transform.position;
        startControllerPosition = rightController.transform.position;
    }
    public void grabCanceled()
    {
        //Debug.Log("rightend");
        isGrabbing = false;
        float distanceMoved = Vector3.Distance(rightController.transform.position, startControllerPosition);
        shootArrow(distanceMoved);

    }
    

    public void reloadArrow(GameObject arrow)
    {
        this.arrow = arrow;
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
        //ArrowControl = arrow.gameObject.AddComponent<arrowControl>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public void invokeArrow()
    {
        shootArrow(Random.Range(0.01f, 6f));
    }
    void shootArrow(float distanceMoved)
    {
        ArrowControl.fire(distanceMoved);
        gameManager.Invoke("calculateScore", 2);
        bow.haveArrow = false;
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
        

        arrow.transform.position = this.transform.position;
        arrow.transform.rotation = this.transform.rotation;
    }
}
