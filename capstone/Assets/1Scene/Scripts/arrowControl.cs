using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor.Rendering;
using UnityEngine;
using static System.Net.WebRequestMethods;
using static UnityEditor.Experimental.GraphView.GraphView;

public class arrowControl : MonoBehaviour
{

    private float speed = 5000f;
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Arrow"), LayerMask.NameToLayer("Arrow"));

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void fire(float diff)
    {
        Debug.Log("shoot");
        GetComponent<Rigidbody>().AddForce(transform.right * speed * diff, ForceMode.Force);
        GetComponent<Rigidbody>().useGravity = true;

        
    }
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            score = 1; //임시, 현재는 과녁을 맞추면 1점
        }
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.freezeRotation = true;
    }

}
