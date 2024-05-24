using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
    public GameObject exitPanel;
    public GameObject ButtonSelection; //ButtonSelection ��ũ��Ʈ
    public GameObject GameManager; //GameManager ��ũ��Ʈ

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
