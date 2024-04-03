using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class arrowControl : MonoBehaviour
{
    private bool shoot = false;
    public GameObject grabPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!shoot)
        {
            this.transform.position = grabPoint.transform.position;
            this.transform.Translate(new Vector3(0f, 0, 0), Space.World);
        }
    }
    public void fire(float zdiff)
    {
        Debug.Log("shoot");
        shoot = true;
        this.GetComponent<Rigidbody>().AddForce(transform.right * 3000f * zdiff, ForceMode.Force);

        this.GetComponent<Rigidbody>().useGravity = true;
    }
}
