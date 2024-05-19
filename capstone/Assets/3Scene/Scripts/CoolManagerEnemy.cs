using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolManagerEnemy : MonoBehaviour
{
    public GameObject reduceCoolEnemy; //스킬 스크립트4 (쿨타임 감소)
    public GameObject removeSkillEnemy; //스킬 스크립트5 (스킬 무효화)
    public GameObject scoreBonusEnemy; //스킬 스크립트6 (스킬 보너스)

    public GameManager gameManager; //GameManager 스크립트, 플레이어의 턴을 감지하기 위함

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //턴 감지하여 쿨타임을 센다
        if (gameManager.count_cool_enemy == true){
            countCoolEnemy();
            gameManager.count_cool_enemy = false;
        }

        //4
        if (reduceCoolEnemy.GetComponent<reduceCoolEnemy>().cool <= 0 && gameManager.playerTurn == true) { //쿨타임이 남아있으면 
            reduceCoolEnemy.GetComponent<reduceCoolEnemy>().pardon(); //스킬 선택 허용
        }
        else
        {
            reduceCoolEnemy.GetComponent<reduceCoolEnemy>().ban(); //스킬 선택 비허용
        }

        //5
        if (removeSkillEnemy.GetComponent<removeSkillEnemy>().cool <= 0 && gameManager.playerTurn == true) {
            removeSkillEnemy.GetComponent<removeSkillEnemy>().pardon();
        }
        else
        {
            removeSkillEnemy.GetComponent<removeSkillEnemy>().ban();
        }

        //6
        if (scoreBonusEnemy.GetComponent<scoreBonusEnemy>().cool <= 0 && gameManager.playerTurn == true) {
            scoreBonusEnemy.GetComponent<scoreBonusEnemy>().pardon();
        }
        else
        {
            scoreBonusEnemy.GetComponent<scoreBonusEnemy>().ban();
        }
    }
    public void countCoolEnemy() { //모든 스킬에 대해서, 쿨타임 1턴을 넘긴다. (cool--), (GameManager에서 이것을 매턴마다 호출)
        reduceCoolEnemy.GetComponent<reduceCoolEnemy>().cool--; //4 
        removeSkillEnemy.GetComponent<removeSkillEnemy>().cool--; //5
        scoreBonusEnemy.GetComponent<scoreBonusEnemy>().cool--; //6  
    }
}
