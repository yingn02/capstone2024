using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeSkill : MonoBehaviour
{
    public GameObject SkillPanelManager; //스킬 패널 스크립트
    public GameObject changeWind; //changeWind 스크립트
    public GameObject smallTargetEnemy; //스킬 스크립트1 (과녁 크기 감소)
    public GameObject movingTargetEnemy; //스킬 스크립트3 (과녁 움직이기)
    public GameObject transparentEnemy; //스킬 스크립트9 (투명 화살과 과녁)
    public targetControl target;

    public bool skill = false; //스킬이 발동 중인가? 
    public int cool = 0; //쿨타임(턴), 몇 턴을 앞으로 더 기다려야 하는가의 변수
    public int num = -1; //스킬이 선택되었을 때, 나는 몇번째 스킬인지 정체화, ban() 과 pardon()에서 쓰임

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void execute() { //스킬 발동
        skill = true;
        Debug.Log("스킬 무효화");
        typhoonBan(); //적팀이 썼던 '태풍' 무효화
        smallTargetBan(); //적팀이 썼던 '과녁 크기 감소' 무효화
        movingTargetBan(); //적팀이 썼던 '과녁 움직이기' 무효화
        transparentBan(); //적팀이 썼던 '투명 화살과 과녁' 무효화
        skill = false;
    }

    public void setCool(int selected, int cool_time) { //쿨타임 설정
        cool = cool_time; //쿨타임 (적턴을 포함시킨 수, 항상 홀수일 것)
        num = selected;
    }

    public void ban() { //스킬 선택 비허용
        if (num == 1) { //내가 1번 스킬이면 1번 스킬 버튼을 비활성화
            SkillPanelManager.GetComponent<SkillPanelManager>().buttonA.interactable = false; 
        }
        else if (num == 2)
        {
            SkillPanelManager.GetComponent<SkillPanelManager>().buttonB.interactable = false; 
        }
        else if (num == 3)
        {
            SkillPanelManager.GetComponent<SkillPanelManager>().buttonC.interactable = false; 
        }
    }

    public void pardon() { //스킬 선택 허용
        if (num == 1) { //내가 1번 스킬이면 1번 스킬 버튼을 활성화
            SkillPanelManager.GetComponent<SkillPanelManager>().buttonA.interactable = true;
        }
        else if (num == 2)
        {
            SkillPanelManager.GetComponent<SkillPanelManager>().buttonB.interactable = true; 
        }
        else if (num == 3)
        {
            SkillPanelManager.GetComponent<SkillPanelManager>().buttonC.interactable = true; 
        }
    }

    ////////////////////////////////////////////////스킬 무효화////////////////////////////////////////////////

    public void typhoonBan() {
        changeWind.GetComponent<changeWind>().isTyphoonEnemy = false;
        changeWind.GetComponent<changeWind>().isChangeEnemy = true;
    }

    public void smallTargetBan() {
        if (smallTargetEnemy.GetComponent<smallTargetEnemy>().skill == true) { //과녁이 축소 상태라면
            smallTargetEnemy.GetComponent<smallTargetEnemy>().disable();

            smallTargetEnemy.GetComponent<smallTargetEnemy>().skill = false;
        }
    }

    public void movingTargetBan() {
        if (movingTargetEnemy.GetComponent<movingTargetEnemy>().skill == true) { //과녁이 움직이는 상태라면
            movingTargetEnemy.GetComponent<movingTargetEnemy>().disable();

            movingTargetEnemy.GetComponent<movingTargetEnemy>().skill = false;
        }
    }

    public void transparentBan() {
        if (transparentEnemy.GetComponent<transparentEnemy>().skill == true) { //투명화 상태라면
            transparentEnemy.GetComponent<transparentEnemy>().disable();

            transparentEnemy.GetComponent<transparentEnemy>().skill = false;
        }
    }
}
