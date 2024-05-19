using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reduceCoolEnemy : MonoBehaviour
{
    public GameObject SkillPanelManagerEnemy; //스킬 패널 스크립트
    public GameObject CoolManagerEnemy; //쿨타임 스크립트

    public bool skill = false; //스킬이 발동 중인가?
    public int cool = 0; //쿨타임(턴), 몇 턴을 앞으로 더 기다려야 하는가의 변수
    public int num = 1; //스킬이 선택되었을 때, 나는 몇번째 스킬인지 정체화, ban() 과 pardon()에서 쓰임

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void execute() { //스킬 발동
        Debug.Log("쿨타임 감소E");
        skill = true;
        CoolManagerEnemy.GetComponent<CoolManagerEnemy>().countCoolEnemy(); //모든 스킬에 대해서, 쿨타일 1턴을 넘긴다. (cool--)
        CoolManagerEnemy.GetComponent<CoolManagerEnemy>().countCoolEnemy(); //플레이어의 턴에서는 스킬을 쓰면 안되므로 2번 작성했다
        skill = false;
    }
    public void setCool(int selected) { //쿨타임 설정
        cool = 5; //쿨타임 (적턴을 포함시킨 수, 항상 홀수일 것)
        num = selected;
    }
    public void ban() { //스킬 선택 비허용
        SkillPanelManagerEnemy.GetComponent<SkillPanelManagerEnemy>().buttons[num] = false; //내가 1번 스킬이면 1번 스킬 버튼을 비활성화
    }

    public void pardon() { //스킬 선택 허용
        SkillPanelManagerEnemy.GetComponent<SkillPanelManagerEnemy>().buttons[num] = true; //내가 1번 스킬이면 1번 스킬 버튼을 활성화
    }
}
