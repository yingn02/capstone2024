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
    Vector3 newLineDirection;
    Vector3 newPosition;

    public Transform bowpoint;
    public Transform bowpoint2;

    public GameObject Bow;
    private bowControl bow;
    private GameManager gameManager;

    private bool shot = false;

    AudioSource bowSnd;//활시위 당기는 사운드
   

    void Start()
    {
        //ArrowControl = arrow.gameObject.AddComponent<arrowControl>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        bow = Bow.GetComponent<bowControl>();
        bowSnd = GameObject.Find("bowSnd").GetComponent<AudioSource>();
    }

    public void grabPerformed()
    {
        //Debug.Log("rightstart");
        isGrabbing = true;
        bowSnd.Play();
        if (!shot)
        {
            startPosition = this.gameObject.transform.position;
            startControllerPosition = rightController.transform.position;
        }

    }
    public void grabCanceled()
    {

        //Debug.Log("rightend");
        isGrabbing = false;
        if (!shot)
        {
            float distanceMoved = Vector3.Distance(newPosition, bowpoint.position);
            Debug.Log(distanceMoved);
            shootArrow(distanceMoved);
        }

    }


    public void reloadArrow(GameObject arrow, bool isPlayer)
    {
        shot = false;
        this.arrow = arrow;
        ArrowControl = arrow.GetComponent<arrowControl>();
        ArrowControl.player = isPlayer;
        transform.position = bowpoint2.position;
        startPosition = bowpoint2.position;
        startControllerPosition = rightController.transform.position;
        transform.rotation = bowpoint2.rotation;
        calculatePosition();
    }



    bool charging = false;
    float timer = 0f;
    float distance;
    public void invokeArrow()
    {
        bowSnd?.Play();
        charging = true;
        distance = Random.Range(0.1f, 6f);
        //shootArrow(Random.Range(0.01f, 6f));
    }
    // Update is called once per frame
    void Update()
    {
        if (charging)
        {
            timer += Time.deltaTime;
            float moveAmount = Mathf.Lerp(0, distance * -1.2f, timer);
            transform.position = new Vector3(bowpoint2.position.x, bowpoint2.position.y, bowpoint2.position.z + moveAmount * 0.06f);

            arrow.transform.position = this.transform.position;
            arrow.transform.rotation = Bow.transform.rotation;

            arrow.transform.Rotate(0, -90, 0);

            if (timer >= 1f)
            {
                timer = 0;
                shootArrow(distance);
                charging = false;
                transform.position = bowpoint2.position;
            }
        }

        newLineDirection = (bowpoint.position - bowpoint2.position).normalized;
        if ((isGrabbing && !shot))
        {
            calculatePosition();
        }
    }
    public void shootArrow(float distanceMoved)
    {
        shot = true;
        ArrowControl.fire(distanceMoved, (bowpoint.position - bowpoint2.position).normalized);
        gameManager.Invoke("calculateScore", 2);
        bow.haveArrow = false;
    }


    void calculatePosition()
    {


        Vector3 controllerMovement = rightController.transform.position - startControllerPosition;

        float movementProjection = Vector3.Dot(controllerMovement, newLineDirection);

        newPosition = bowpoint2.position + newLineDirection * movementProjection;
        transform.position = newPosition;

        arrow.transform.position = this.transform.position;
        arrow.transform.rotation = Bow.transform.rotation;

        arrow.transform.Rotate(0, -90, 0);
    }
}