using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using static System.Net.WebRequestMethods;
using static UnityEditor.Experimental.GraphView.GraphView;

public class arrowControl : MonoBehaviour
{
    private bool shoot = false;
    public GameObject grabPoint;
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Arrow"), LayerMask.NameToLayer("Arrow"));
    }

    // Update is called once per frame
    void Update()
    {
        if (!shoot)
        {
            transform.position = grabPoint.transform.position;
            transform.Translate(new Vector3(0f, 0, 0), Space.World);
        }
    }
    public void fire(float zdiff)
    {
        Debug.Log("shoot");
        shoot = true;
        GetComponent<Rigidbody>().AddForce(transform.right * 3000f * zdiff, ForceMode.Force);
        GetComponent<Rigidbody>().useGravity = true;
    }
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if(collision.gameObject.tag == "Target")
        {
            Debug.Log("Hit!");
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;
            rb.freezeRotation = true;
        }
    }
}
