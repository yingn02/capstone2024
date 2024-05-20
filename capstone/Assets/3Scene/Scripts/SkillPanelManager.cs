using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class SkillPanelManager : MonoBehaviour
{
    public GameObject smallTarget; //스킬 스크립트1 (과녁 크기 감소)
    public GameObject bigTarget; //스킬 스크립트2 (과녁 크기 증가)
    public GameObject movingTarget; //스킬 스크립트3 (과녁 움직이기)
    public GameObject reduceCool; //스킬 스크립트4 (쿨타임 감소)
    public GameObject removeSkill; //스킬 스크립트5 (스킬 무효화)
    public GameObject scoreBonus; //스킬 스크립트6 (점수 보너스)
    public GameObject bigArrow; //스킬 스크립트7 (화살 거대화)
    public GameObject doubleArrow; //스킬 스크립트8 (더블샷)
    public GameObject transparent; //스킬 스크립트9 (투명 화살과 과녁)
    public GameObject removeWind; //스킬 스크립트10 (풍향 제거)
    public GameObject typhoon; //스킬 스크립트11 (태풍)

    public TMP_Text skillText;
    public Button buttonA; //스킬1 버튼
    public Button buttonB;
    public Button buttonC;

    public int selected = 0; //몇번째 스킬이 선택되었는가 (스킬마다 쿨타임이 다르므로, SkillManager 스크립트에서 사용할 변수 필요)

    public List<string> skillList = new List<string>(); //스킬텍스트 설정활 리스트

    void Start()
    {
        // ButtonSelection에서 선택된 스킬 텍스트 다시 skillList에 저장
        skillList = ButtonSelection.GetSelectedButtonTexts();

        // 초기 버튼 순서 설정 (버튼 & 쿨타임 오류 대응)
        smallTarget.GetComponent<smallTarget>().num = -1;
        bigTarget.GetComponent<bigTarget>().num = -1;
        movingTarget.GetComponent<movingTarget>().num = -1;

        reduceCool.GetComponent<reduceCool>().num = -1;
        removeSkill.GetComponent<removeSkill>().num = -1;
        scoreBonus.GetComponent<scoreBonus>().num = -1;

        bigArrow.GetComponent<bigArrow>().num = -1;
        doubleArrow.GetComponent<doubleArrow>().num = -1;
        transparent.GetComponent<transparent>().num = -1;

        removeWind.GetComponent<removeWind>().num = -1;
        typhoon.GetComponent<typhoon>().num = -1;

        initialSet();
        //

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

    void Update()
    {
        Debug.Log(selected);
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

    public void initialSet() { //초기 버튼 순서 설정 (버튼 & 쿨타임 오류 대응)
        for (int i = 0; i < 3; i++)
        {
            if (skillList[i] == "과녁 크기 감소 : 과녁 크기 감소") smallTarget.GetComponent<smallTarget>().setCool(i + 1, 0);
            else if (skillList[i] == "과녁 크기 증가 : 과녁 크기 증가") bigTarget.GetComponent<bigTarget>().setCool(i + 1, 0);
            else if (skillList[i] == "과녁 움직이기 : 과녁 움직이기") movingTarget.GetComponent<movingTarget>().setCool(i + 1, 0);
            else if (skillList[i] == "쿨타임 감소 : 플레이어의 모든 스킬 쿨타임이 1턴 감소한다.") reduceCool.GetComponent<reduceCool>().setCool(i + 1, 0);
            else if (skillList[i] == "스킬 무효화 : 적 팀이 발동 중인 모든 스킬을 무효화 한다.") removeSkill.GetComponent<removeSkill>().setCool(i + 1, 0);
            else if (skillList[i] == "점수 보너스 : 현재 턴에서 점수를 2배로 얻을 수 있다.") scoreBonus.GetComponent<scoreBonus>().setCool(i + 1, 0);       
            else if (skillList[i] == "화살 거대화 : 화살 거대화") bigArrow.GetComponent<bigArrow>().setCool(i + 1, 0);
            else if (skillList[i] == "더블샷 : 더블샷") doubleArrow.GetComponent<doubleArrow>().setCool(i + 1, 0);
            else if (skillList[i] == "투명 화살과 과녁 : 투명 화살과 과녁") transparent.GetComponent<transparent>().setCool(i + 1, 0);
            else if (skillList[i] == "풍향 제거: 풍향 제거") removeWind.GetComponent<removeWind>().setCool(i + 1, 0);
            else if (skillList[i] == "태풍 : 태풍") typhoon.GetComponent<typhoon>().setCool(i + 1, 0);
        }

    }
}


