using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class csh_mainmenu : MonoBehaviour
{
    public GameObject start_btn;

    public void start_btn_clicked() {
        SceneManager.LoadScene("SelectMenu");
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
}
