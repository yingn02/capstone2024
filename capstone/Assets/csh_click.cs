using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class csh_click : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButton(0)) {
        //    SceneManager.LoadScene("SimpleScene");
        //}

        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame) {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
