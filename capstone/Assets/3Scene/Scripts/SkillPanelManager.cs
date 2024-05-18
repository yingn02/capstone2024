using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class SkillPanelManager : MonoBehaviour
{
    public TMP_Text skillText;
    public Button buttonA; //스킬1 버튼
    public Button buttonB;
    public Button buttonC;

    public int selected = 1; //몇번째 스킬이 선택되었는가 (스킬마다 쿨타임이 다르므로, SkillManager 스크립트에서 사용할 변수 필요)

    private List<string> skillList = new List<string>(); //스킬텍스트 설정활 리스트

    void Start()
    {
        // ButtonSelection에서 선택된 스킬 텍스트 다시 skillList에 저장
        skillList = ButtonSelection.GetSelectedButtonTexts();

        // 선택된 스킬 없으면 텍스트 비움
        if (skillList == null || skillList.Count == 0)
        {
            skillText.text = "";
            return;
        }

        buttonA.onClick.AddListener(OnButtonClickA);
        buttonB.onClick.AddListener(OnButtonClickB);
        buttonC.onClick.AddListener(OnButtonClickC);

    }

    public void OnButtonClickA()
    {
        skillText.text = skillList[0];
        selected = 1;
    }

    public void OnButtonClickB()
    {
        skillText.text = skillList[1];
        selected = 2;
    }

    public void OnButtonClickC()
    {
        skillText.text = skillList[2];
        selected = 3;
    }
}


