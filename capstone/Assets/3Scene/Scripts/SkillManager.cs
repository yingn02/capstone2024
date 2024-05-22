using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public GameObject SkillPanelManager; //스킬 패널 스크립트

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

    public void skillOn()
    { //text로 어떤 스킬을 사용한 것인지 감지하여, if문으로 알맞은 스킬을 발동 시킨다

        //스킬1
        if (SkillPanelManager.GetComponent<SkillPanelManager>().skillText.text == "과녁 크기 감소 : 상대 턴에 상대방의 과녁 크기가 감소한다.")
        {
            smallTarget.GetComponent<smallTarget>().execute(); //스킬 발동
            smallTarget.GetComponent<smallTarget>().setCool(SkillPanelManager.GetComponent<SkillPanelManager>().selected, 5); //쿨타임 설정
        }

        //스킬2
        if (SkillPanelManager.GetComponent<SkillPanelManager>().skillText.text == "과녁 크기 증가 : 턴이 종료될 때까지 과녁의 크기가 증가한다.")
        {
            bigTarget.GetComponent<bigTarget>().execute();
            bigTarget.GetComponent<bigTarget>().setCool(SkillPanelManager.GetComponent<SkillPanelManager>().selected, 5);
        }

        //스킬3
        if (SkillPanelManager.GetComponent<SkillPanelManager>().skillText.text == "과녁 움직이기 : 상대 턴에 상대방의 과녁이 좌우로 움직인다.")
        {
            movingTarget.GetComponent<movingTarget>().execute();
            movingTarget.GetComponent<movingTarget>().setCool(SkillPanelManager.GetComponent<SkillPanelManager>().selected, 5);
        }

        //스킬4
        if (SkillPanelManager.GetComponent<SkillPanelManager>().skillText.text == "쿨타임 감소 : 플레이어의 모든 스킬 쿨타임이 1턴 감소한다.")
        {
            reduceCool.GetComponent<reduceCool>().execute();
            reduceCool.GetComponent<reduceCool>().setCool(SkillPanelManager.GetComponent<SkillPanelManager>().selected, 5);
        }

        //스킬5
        if (SkillPanelManager.GetComponent<SkillPanelManager>().skillText.text == "스킬 무효화 : 적 팀이 발동 중인 모든 스킬을 무효화 한다.")
        {
            removeSkill.GetComponent<removeSkill>().execute();
            removeSkill.GetComponent<removeSkill>().setCool(SkillPanelManager.GetComponent<SkillPanelManager>().selected, 5);
        }

        //스킬6
        if (SkillPanelManager.GetComponent<SkillPanelManager>().skillText.text == "점수 보너스 : 현재 턴에서 점수를 2배로 얻을 수 있다.")
        {
            scoreBonus.GetComponent<scoreBonus>().execute();
            scoreBonus.GetComponent<scoreBonus>().setCool(SkillPanelManager.GetComponent<SkillPanelManager>().selected, 5);
        }

        //스킬7
        if (SkillPanelManager.GetComponent<SkillPanelManager>().skillText.text == "화살 거대화 : 이번 턴의 화살이 거대화되어 점수 판정 범위가 넓어진다.")
        {
            bigArrow.GetComponent<bigArrow>().execute();
            bigArrow.GetComponent<bigArrow>().setCool(SkillPanelManager.GetComponent<SkillPanelManager>().selected, 3);
        }

        //스킬8
        if (SkillPanelManager.GetComponent<SkillPanelManager>().skillText.text == "더블샷 : 이번 한 턴에 화살을 2발 쏴서 그 2발의 점수를 모두 얻는다.")
        {
            doubleArrow.GetComponent<doubleArrow>().execute();
            doubleArrow.GetComponent<doubleArrow>().setCool(SkillPanelManager.GetComponent<SkillPanelManager>().selected, 5);
        }

        //스킬9
        if (SkillPanelManager.GetComponent<SkillPanelManager>().skillText.text == "투명 화살과 과녁 : 화살과 과녁이 투명화되어 상대방이 사격 시에 큰 방해가 된다.")
        {
            transparent.GetComponent<transparent>().execute();
            transparent.GetComponent<transparent>().setCool(SkillPanelManager.GetComponent<SkillPanelManager>().selected, 7);
        }

        //스킬10
        if (SkillPanelManager.GetComponent<SkillPanelManager>().skillText.text == "풍향 제거 : 풍향 제거")
        {
            removeWind.GetComponent<removeWind>().execute();
            removeWind.GetComponent<removeWind>().setCool(SkillPanelManager.GetComponent<SkillPanelManager>().selected, 5);
        }

        //스킬11
        if (SkillPanelManager.GetComponent<SkillPanelManager>().skillText.text == "태풍 : 태풍")
        {
            typhoon.GetComponent<typhoon>().execute();
            typhoon.GetComponent<typhoon>().setCool(SkillPanelManager.GetComponent<SkillPanelManager>().selected, 5);
        }
    }
}