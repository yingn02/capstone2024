using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialSetManager : MonoBehaviour
{
    //private List<string> skillList2 = new List<string>(); //스킬텍스트 리스트를 SkillManager에서 가져옴
    
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
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void initialSet(List<string> skillList) { //초기 버튼 순서 설정 (쿨타임 오류 대응)
        for (int i = 0; i < 3; i++)
        {
            if (skillList[i] == "과녁 크기 감소 : 과녁 크기 감소") smallTarget.GetComponent<smallTarget>().setCool(i, 0); //쿨타임 설정
            else if (skillList[i] == "과녁 크기 증가 : 과녁 크기 증가") bigTarget.GetComponent<bigTarget>().setCool(i, 0);
            else if (skillList[i] == "과녁 움직이기 : 과녁 움직이기") movingTarget.GetComponent<movingTarget>().setCool(i, 0);

            else if (skillList[i] == "쿨타임 감소 : 쿨타임 감소 : 플레이어의 모든 스킬 쿨타임이 1턴 감소한다.") reduceCool.GetComponent<reduceCool>().setCool(i, 0);
            else if (skillList[i] == "스킬 무효화 : 적 팀이 발동 중인 모든 스킬을 무효화 한다.") removeSkill.GetComponent<removeSkill>().setCool(i, 0);
            else if (skillList[i] == "점수 보너스 : 현재 턴에서 점수를 2배로 얻을 수 있다.") scoreBonus.GetComponent<scoreBonus>().setCool(i, 0);

            else if (skillList[i] == "화살 거대화 : 화살 거대화") bigArrow.GetComponent<bigArrow>().setCool(i, 0);
            else if (skillList[i] == "더블샷 : 더블샷") doubleArrow.GetComponent<doubleArrow>().setCool(i, 0);
            else if (skillList[i] == "투명 화살과 과녁 : 투명 화살과 과녁") transparent.GetComponent<transparent>().setCool(i, 0);

            else if (skillList[i] == "풍향 제거: 풍향 제거") removeWind.GetComponent<removeWind>().setCool(i, 0);
            else if (skillList[i] == "태풍 : 태풍") typhoon.GetComponent<typhoon>().setCool(i, 0);
        }
    }
    
}
