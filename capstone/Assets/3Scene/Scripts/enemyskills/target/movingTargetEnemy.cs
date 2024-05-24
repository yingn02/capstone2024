using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingTargetEnemy : TargetSkill
{
    public GameObject SkillPanelManagerEnemy; //스킬 패널 스크립트
    public GameManager gameManager;
    public targetControl target;

    public bool skill = false; //스킬이 발동 중인가?
    public int cool = 0; //쿨타임(턴), 몇 턴을 앞으로 더 기다려야 하는가의 변수
    public int num = -1; //스킬이 선택되었을 때, 나는 몇번째 스킬인지 정체화, ban() 과 pardon()에서 쓰임

    // Start is called before the first frame update
    void Start()
    {
        activeTurns = 2;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void disable()
    {
        activeTurns = 2;
        target.moving = false;
        target.parent.transform.position = new Vector3(0f, 0, 0);
        skill = false;
    }
    public void execute() { //스킬 발동
        skill = true;
        gameManager.activatedTargetSkills.Add(this);
        target.moving = true;
        Debug.Log("과녁 움직이기E");
    }

    public void setCool(int selected, int c) { //쿨타임 설정
        cool = c; //쿨타임 (플레이어의 턴을 포함시킨 수, 항상 홀수일 것)
        num = selected;
    }

    public void ban() { //스킬 선택 비허용
        SkillPanelManagerEnemy.GetComponent<SkillPanelManagerEnemy>().buttons[num] = false; //내가 1번 스킬이면 1번 스킬 버튼을 비활성화
    }

    public void pardon() { //스킬 선택 허용
        SkillPanelManagerEnemy.GetComponent<SkillPanelManagerEnemy>().buttons[num] = true; //내가 1번 스킬이면 1번 스킬 버튼을 활성화
    }
}