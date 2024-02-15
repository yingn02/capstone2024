using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Option : MonoBehaviour
{
    public GameObject UI;
    public GameObject OptionPrefab;
    public InputActionReference grabAction;

    void OnEnable()
    {
        grabAction.action.performed += GrabPerformed;
        grabAction.action.Enable();
    }

    void OnDisable()
    {
        grabAction.action.performed -= GrabPerformed;
        grabAction.action.Disable();
    }

    void GrabPerformed(InputAction.CallbackContext context)
    {
        Debug.Log("fafasd");
        // 그랩 버튼이 눌렸을 때 실행할 함수
        UIenable();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void UIenable()
    {
        UI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void UItoggle()
    {
        if (UI.activeSelf)
        {
            UI.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            UI.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void optionToggle()
    {
        if (OptionPrefab.activeSelf)
        {
            OptionPrefab.SetActive(false);
        }
        else
        {
            OptionPrefab.SetActive(true);
        }
    }
}
