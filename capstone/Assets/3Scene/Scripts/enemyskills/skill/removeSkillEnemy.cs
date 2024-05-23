using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeSkillEnemy : MonoBehaviour
{
    public GameObject SkillPanelManagerEnemy; //스킬 패널 스크립트
    public GameObject changeWind; //changeWind 스크립트
    public GameObject smallTarget; //스킬 스크립트1 (과녁 크기 감소)
    public GameObject movingTarget; //스킬 스크립트3 (과녁 움직이기)
    public GameObject transparent; //스킬 스크립트9 (투명 화살과 과녁)
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
        Debug.Log("스킬 무효화E");
        typhoonBan(); //플레이어가 썼던 '태풍' 무효화
        smallTargetBan(); //플레이어가 썼던 '과녁 크기 감소' 무효화
        movingTargetBan(); //플레이어가 썼던 '과녁 움직이기' 무효화
        transparentBan(); //플레이어가 썼던 '투명 화살과 과녁' 무효화
        skill = false;
    }

    public void setCool(int selected, int cool_time) { //쿨타임 설정
        cool = cool_time; //쿨타임 (플레이어의 턴을 포함시킨 수, 항상 홀수일 것)
        num = selected;
    }

    public void ban() { //스킬 선택 비허용
        SkillPanelManagerEnemy.GetComponent<SkillPanelManagerEnemy>().buttons[num] = false; //내가 1번 스킬이면 1번 스킬 버튼을 비활성화
    }

    public void pardon() { //스킬 선택 허용
        SkillPanelManagerEnemy.GetComponent<SkillPanelManagerEnemy>().buttons[num] = true; //내가 1번 스킬이면 1번 스킬 버튼을 활성화
    }

    ////////////////////////////////////////////////스킬 무효화////////////////////////////////////////////////
    
    public void typhoonBan() {
        changeWind.GetComponent<changeWind>().isTyphoon = false;
        changeWind.GetComponent<changeWind>().isChange = true;
    }

    public void smallTargetBan() {
        if (smallTarget.GetComponent<smallTarget>().skill == true) { //과녁이 축소 상태라면
            smallTarget.GetComponent<smallTarget>().disable();

            smallTarget.GetComponent<smallTarget>().skill = false;
        }
    }

    public void movingTargetBan() {
        if (movingTarget.GetComponent<movingTarget>().skill == true) { //과녁이 움직이는 상태라면
            movingTarget.GetComponent<movingTarget>().disable();

            movingTarget.GetComponent<movingTarget>().skill = false;
        }
    }

    public void transparentBan() {
        if (transparent.GetComponent<transparent>().skill == true) { //투명화 상태라면
            transparent.GetComponent<transparent>().disable();

            transparent.GetComponent<transparent>().skill = false;
        }
    }
}
