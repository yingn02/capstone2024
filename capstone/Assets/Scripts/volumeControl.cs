using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class volumeControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void control(float v)
    {
        AudioListener.volume = v;
    }
}
