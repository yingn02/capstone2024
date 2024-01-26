using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class closePanel : MonoBehaviour
{
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void closeToggle()
    {
        if (this.gameObject.activeSelf) { this.gameObject.SetActive(false); panel.SetActive(true); }
        else { this.gameObject.SetActive(true); panel.SetActive(false); }
    }

    public void closeGame()
    {
        Debug.Log("Quit");
        #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
