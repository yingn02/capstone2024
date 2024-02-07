using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;


public class Paddle : MonoBehaviour
{
    public GameObject originalController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(originalController.transform.position.x + 0.01030457f, originalController.transform.position.y - 0.07239223f, originalController.transform.position.z + 0.08378766f); ;
        gameObject.transform.rotation = originalController.transform.rotation;
    }
}
