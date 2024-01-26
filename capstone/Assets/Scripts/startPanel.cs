using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class startPanel : MonoBehaviour
{

    public GameObject panel;

    void Start()
    {

    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void startToggle()
    {
        if (this.gameObject.activeSelf) { this.gameObject.SetActive(false); panel.SetActive(true); }
        else { this.gameObject.SetActive(true); panel.SetActive(false); }
    }
}

