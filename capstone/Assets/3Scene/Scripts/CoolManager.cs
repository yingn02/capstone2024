using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolManager : MonoBehaviour
{
    public GameObject reduceCool; //스킬 스크립트4 (쿨타임 감소)
    public GameObject removeSkill; //스킬 스크립트5 (스킬 무효화)
    public GameObject scoreBonus; //스킬 스크립트6 (스킬 보너스)

    public GameManager gameManager; //GameManager 스크립트, 플레이어의 턴을 감지하기 위함

    // Start is called before the first frame update
    void Start()
    {
        gameManager.skill = true; //스킬모드임을 GameManager에게 알림
    }

    // Update is called once per frame
    void Update()
    {
        //턴 감지하여 쿨타임을 센다
        if (gameManager.count_cool == true) {
            countCool();
            gameManager.count_cool = false;
        }

        //4
        if (reduceCool.GetComponent<reduceCool>().cool <= 0 && gameManager.playerTurn == true) { //쿨타임이 남아있으면 
            reduceCool.GetComponent<reduceCool>().pardon(); //스킬 선택 허용
        }
        else {
            reduceCool.GetComponent<reduceCool>().ban(); //스킬 선택 비허용
        }

        //5
        if (removeSkill.GetComponent<removeSkill>().cool <= 0 && gameManager.playerTurn == true) {
            removeSkill.GetComponent<removeSkill>().pardon();
        }
        else
        {
            removeSkill.GetComponent<removeSkill>().ban();
        }

        //6
        if (scoreBonus.GetComponent<scoreBonus>().cool <= 0 && gameManager.playerTurn == true) {
            scoreBonus.GetComponent<scoreBonus>().pardon();
        }
        else {
            scoreBonus.GetComponent<scoreBonus>().ban();
        }
    }

    public void countCool() { //모든 스킬에 대해서, 쿨타임 1턴을 넘긴다. (cool--), (GameManager에서 이것을 매턴마다 호출)
        reduceCool.GetComponent<reduceCool>().cool--; //4 
        removeSkill.GetComponent<removeSkill>().cool--; //5
        scoreBonus.GetComponent<scoreBonus>().cool--; //6  
    }
}
