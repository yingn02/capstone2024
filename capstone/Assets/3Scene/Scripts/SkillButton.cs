using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class SkillButton : MonoBehaviour
{
    public GameObject skillPanel; 

    public void OnButtonClick()
    {
        if (skillPanel != null)
        {
            skillPanel.SetActive(!skillPanel.activeSelf);
        }
    }
}

