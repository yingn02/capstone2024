using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csh_rotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0.0f, 2.0f * Time.deltaTime, 0.0f);
    }
}
