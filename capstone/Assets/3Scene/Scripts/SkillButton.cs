using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class SkillButton : MonoBehaviour
{
    public GameObject skillPanel;
    public GameObject SkillManager; //스킬 발동 스크립트

    public void OnButtonClick()
    {
        if (skillPanel != null)
        {
            skillPanel.SetActive(!skillPanel.activeSelf);
        }
    }
    public void OnSelectClick()
    { //스킬 사용 버튼(선택)을 눌렀을 때
        SkillManager.GetComponent<SkillManager>().skillOn(); //스킬 사용 버튼이 눌렸음을 확인
    }
}