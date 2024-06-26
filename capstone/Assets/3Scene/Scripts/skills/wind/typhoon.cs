using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class typhoon : MonoBehaviour
{
    public GameManager gameManager; //GameManager 스크립트, 플레이어의 턴을 감지하기 위함
    public GameObject SkillPanelManager; //스킬 패널 스크립트
    public GameObject changeWind; //풍향 스크립트

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
        //플레이어 차례가 지난 후 적팀의 1턴만 태풍 적용, 원상 복구는 CoolManager 스크립트에서 관리
        if (skill == true)
        {
            if (gameManager.playerTurn == false) {
                changeWind.GetComponent<changeWind>().isTyphoon = true;
                changeWind.GetComponent<changeWind>().isChange = true;
                skill = false;
            }
        }
    }

    public void execute() { //스킬 발동
        skill = true;
        Debug.Log("태풍");
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
}
