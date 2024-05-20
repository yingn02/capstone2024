using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManagerEnemy : MonoBehaviour
{
    private List<int> skills = new List<int>(); //적팀의 현재 스킬 리스트

    public GameManager gameManager; //GameManager 스크립트, 플레이어의 턴을 감지하기 위함
    public GameObject SkillPanelManagerEnemy; //SkillPanelManagerEnemy 스크립트, 적팀이 스킬 버튼을 누를 수 있을지 결정하기 위함

    public GameObject smallTargetEnemy; //스킬 스크립트1 (과녁 크기 감소)
    public GameObject bigTargetEnemy; //스킬 스크립트2 (과녁 크기 증가)
    public GameObject movingTargetEnemy; //스킬 스크립트3 (과녁 움직이기)
    public GameObject reduceCoolEnemy; //스킬 스크립트4 (쿨타임 감소)
    public GameObject removeSkillEnemy; //스킬 스크립트5 (스킬 무효화)
    public GameObject scoreBonusEnemy; //스킬 스크립트6 (점수 보너스)
    public GameObject bigArrowEnemy; //스킬 스크립트7 (화살 거대화)
    public GameObject doubleArrowEnemy; //스킬 스크립트8 (더블샷)
    public GameObject transparentEnemy; //스킬 스크립트9 (투명 화살과 과녁)
    public GameObject removeWindEnemy; //스킬 스크립트10 (풍향 제거)
    public GameObject typhoonEnemy; //스킬 스크립트11 (태풍)

    public int selected = 0; //적팀이 누르고자 하는 스킬 버튼의 인덱스
    public bool press = false; //스킬 버튼을 누른다

    // Start is called before the first frame update
    void Start()
    {
        //적팀도 스킬 3개를 고른다. (중복X) 지금은 3개지만 스테이지가 올라갈 때마다 1개씩 더 고를 예정
        while (skills.Count < 3)
        {
            int skill_num = Random.Range(1, 11 + 1); //프로젝트에 있는 것 중에서 어느 스킬을 고를지 결정

            if (!skills.Contains(skill_num))
            {
                skills.Add(skill_num);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //턴 바뀜을 감지하여 스킬 사용을 시도
        if (gameManager.enemy_try_skill == true) {
            if (gameManager.playerTurn == false) { //하지만 적팀의 턴에서만 스킬이 사용된다
                skillOn();
            }
            gameManager.enemy_try_skill = false;
        }
    }

    public void skillOn() { //골랐던 스킬중에서 1개를 랜덤으로 고르게 하고(버튼으로), if문으로 알맞은 스킬을 발동 시킨다

        selected = Random.Range(0, skills.Count);

        if (SkillPanelManagerEnemy.GetComponent<SkillPanelManagerEnemy>().buttons[selected]) { //selected는 적팀이 누르려는 스킬 버튼이 활성화 되어있다면 
            press = true; //그 버튼을 눌러라
        }
        else if (!SkillPanelManagerEnemy.GetComponent<SkillPanelManagerEnemy>().buttons[selected]) { //단, 지금 누르고자 하는 버튼이 비활성화라면 다른 버튼을 찾는다.
            for (int i = 0; i < skills.Count; i++) {
                selected = 0;

                if (SkillPanelManagerEnemy.GetComponent<SkillPanelManagerEnemy>().buttons[selected]) {
                    press = true;
                    break;
                }

                selected += 1;
            }
        }

        //스킬1
        if (skills[selected] == 1 && press) // 과녁 크기 감소
        {
            smallTargetEnemy.GetComponent<smallTargetEnemy>().execute(); //스킬 발동
            smallTargetEnemy.GetComponent<smallTargetEnemy>().setCool(selected); //쿨타임 설정
            press = false;
        }

        //스킬2
        if (skills[selected] == 2 && press) // 과녁 크기 증가
        {
            bigTargetEnemy.GetComponent<bigTargetEnemy>().execute();
            bigTargetEnemy.GetComponent<bigTargetEnemy>().setCool(selected);
            press = false;
        }

        //스킬3
        if (skills[selected] == 3 && press) // 과녁 움직이기
        {
            movingTargetEnemy.GetComponent<movingTargetEnemy>().execute();
            movingTargetEnemy.GetComponent<movingTargetEnemy>().setCool(selected);
            press = false;
        }

        //스킬4
        if (skills[selected] == 4 && press)
        {
            reduceCoolEnemy.GetComponent<reduceCoolEnemy>().execute();
            reduceCoolEnemy.GetComponent<reduceCoolEnemy>().setCool(selected);
            press = false;
        }

        //스킬5
        if (skills[selected] == 5 && press) //스킬 무효화
        {
            removeSkillEnemy.GetComponent<removeSkillEnemy>().execute();
            removeSkillEnemy.GetComponent<removeSkillEnemy>().setCool(selected);
            press = false;
        }

        //스킬6
        if (skills[selected] == 6 && press) //점수 보너스
        {
            scoreBonusEnemy.GetComponent<scoreBonusEnemy>().execute();
            scoreBonusEnemy.GetComponent<scoreBonusEnemy>().setCool(selected);
            press = false;
        }

        //스킬7
        if (skills[selected] == 7 && press) // 화살 거대화
        {
            bigArrowEnemy.GetComponent<bigArrowEnemy>().execute();
            bigArrowEnemy.GetComponent<bigArrowEnemy>().setCool(selected);
            press = false;
        }

        //스킬8
        if (skills[selected] == 8 && press) // 더블샷
        {
            doubleArrowEnemy.GetComponent<doubleArrowEnemy>().execute();
            doubleArrowEnemy.GetComponent<doubleArrowEnemy>().setCool(selected);
            press = false;
        }

        //스킬9
        if (skills[selected] == 9 && press) // 투명 화살과 과녁
        {
            transparentEnemy.GetComponent<transparentEnemy>().execute();
            transparentEnemy.GetComponent<transparentEnemy>().setCool(selected);
            press = false;
        }

        //스킬10
        if (skills[selected] == 10 && press) // 풍향 제거
        {
            removeWindEnemy.GetComponent<removeWindEnemy>().execute();
            removeWindEnemy.GetComponent<removeWindEnemy>().setCool(selected);
            press = false;
        }

        //스킬11
        if (skills[selected] == 11 && press) // 태풍
        {
            typhoonEnemy.GetComponent<typhoonEnemy>().execute();
            typhoonEnemy.GetComponent<typhoonEnemy>().setCool(selected);
            press = false;
        }


    }
}
