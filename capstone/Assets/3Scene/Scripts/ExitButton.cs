using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
    public GameObject exitPanel;
    public GameObject ButtonSelection; //ButtonSelection 스크립트
    public GameObject GameManager; //GameManager 스크립트

    public void OnButtonClick()
    {
        if (exitPanel != null)
        {
            exitPanel.SetActive(!exitPanel.activeSelf);
        }
    }

    public void MainScene() {
        SceneManager.LoadScene("MainMenu");
        
        if (GameManager.GetComponent<GameManager>().skill == true) {
            ButtonSelection.GetComponent<ButtonSelection>().refresh = true;
        }
        
    }
}
