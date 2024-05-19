using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public GameObject SkillPanelManager; //스킬 패널 스크립트

    public GameObject reduceCool; //스킬 스크립트4 (쿨타임 감소)
    public GameObject removeSkill; //스킬 스크립트5 (스킬 무효화)
    public GameObject scoreBonus; //스킬 스크립트6 (스킬 보너스)

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void skillOn() { //text로 어떤 스킬을 사용한 것인지 감지하여, if문으로 알맞은 스킬을 발동 시킨다

        //스킬4
        if (SkillPanelManager.GetComponent<SkillPanelManager>().skillText.text == "쿨타임 감소 : 플레이어의 스킬 쿨타임을 1턴 감소시킵니다.")
        {
            reduceCool.GetComponent<reduceCool>().execute(); //스킬 발동
            reduceCool.GetComponent<reduceCool>().setCool(SkillPanelManager.GetComponent<SkillPanelManager>().selected); //쿨타임 설정
        }

        //스킬5
        if (SkillPanelManager.GetComponent<SkillPanelManager>().skillText.text == "스킬 무효화 : 적 팀이 발동 중인 스킬을 무효화 합니다.")
        {
            removeSkill.GetComponent<removeSkill>().execute();
            removeSkill.GetComponent<removeSkill>().setCool(SkillPanelManager.GetComponent<SkillPanelManager>().selected);
        }

        //스킬6
        if (SkillPanelManager.GetComponent<SkillPanelManager>().skillText.text == "점수 보너스 : 1턴 동안 점수를 2배로 얻습니다.") 
        {
            scoreBonus.GetComponent<scoreBonus>().execute();
            scoreBonus.GetComponent<scoreBonus>().setCool(SkillPanelManager.GetComponent<SkillPanelManager>().selected);
        }
    }
}
