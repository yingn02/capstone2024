using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolManagerEnemy : MonoBehaviour
{
    public GameManager gameManager; //GameManager 스크립트, 플레이어의 턴을 감지하기 위함
    public GameObject changeWind; //changeWind 스크립트

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //턴 감지하여 쿨타임을 센다, 풍향도 초기화
        if (gameManager.count_cool_enemy == true) {
            countCoolEnemy();

            if (gameManager.playerTurn == true) {
                changeWind.GetComponent<changeWind>().isRemoveEnemy = false;
                changeWind.GetComponent<changeWind>().isChangeEnemy = true;
            }

            if (gameManager.playerTurn == false) {
                changeWind.GetComponent<changeWind>().isTyphoonEnemy = false;
                changeWind.GetComponent<changeWind>().isChangeEnemy = true;
            }

            gameManager.count_cool_enemy = false;
        }

        //1
        if (smallTargetEnemy.GetComponent<smallTargetEnemy>().cool <= 0 && gameManager.playerTurn == false){ //쿨타임이 남아있으면 
            smallTargetEnemy.GetComponent<smallTargetEnemy>().pardon(); //스킬 선택 허용
        }
        else
        {
            smallTargetEnemy.GetComponent<smallTargetEnemy>().ban(); //스킬 선택 비허용
        }

        //2
        if (bigTargetEnemy.GetComponent<bigTargetEnemy>().cool <= 0 && gameManager.playerTurn == false) {
            bigTargetEnemy.GetComponent<bigTargetEnemy>().pardon();
        }
        else
        {
            bigTargetEnemy.GetComponent<bigTargetEnemy>().ban();
        }

        //3
        if (movingTargetEnemy.GetComponent<movingTargetEnemy>().cool <= 0 && gameManager.playerTurn == false) {
            movingTargetEnemy.GetComponent<movingTargetEnemy>().pardon();
        }
        else
        {
            movingTargetEnemy.GetComponent<movingTargetEnemy>().ban();
        }

        //4
        if (reduceCoolEnemy.GetComponent<reduceCoolEnemy>().cool <= 0 && gameManager.playerTurn == false) {
            reduceCoolEnemy.GetComponent<reduceCoolEnemy>().pardon(); 
        }
        else
        {
            reduceCoolEnemy.GetComponent<reduceCoolEnemy>().ban();
        }

        //5
        if (removeSkillEnemy.GetComponent<removeSkillEnemy>().cool <= 0 && gameManager.playerTurn == false) {
            removeSkillEnemy.GetComponent<removeSkillEnemy>().pardon();
        }
        else
        {
            removeSkillEnemy.GetComponent<removeSkillEnemy>().ban();
        }

        //6
        if (scoreBonusEnemy.GetComponent<scoreBonusEnemy>().cool <= 0 && gameManager.playerTurn == false) {
            scoreBonusEnemy.GetComponent<scoreBonusEnemy>().pardon();
        }
        else
        {
            scoreBonusEnemy.GetComponent<scoreBonusEnemy>().ban();
        }

        //7
        if (bigArrowEnemy.GetComponent<bigArrowEnemy>().cool <= 0 && gameManager.playerTurn == false) {
            bigArrowEnemy.GetComponent<bigArrowEnemy>().pardon();
        }
        else
        {
            bigArrowEnemy.GetComponent<bigArrowEnemy>().ban();
        }

        //8
        if (doubleArrowEnemy.GetComponent<doubleArrowEnemy>().cool <= 0 && gameManager.playerTurn == false) {
            doubleArrowEnemy.GetComponent<doubleArrowEnemy>().pardon();
        }
        else
        {
            doubleArrowEnemy.GetComponent<doubleArrowEnemy>().ban();
        }

        //9
        if (transparentEnemy.GetComponent<transparentEnemy>().cool <= 0 && gameManager.playerTurn == false)
        {
            transparentEnemy.GetComponent<transparentEnemy>().pardon();
        }
        else
        {
            transparentEnemy.GetComponent<transparentEnemy>().ban();
        }

        //10
        if (removeWindEnemy.GetComponent<removeWindEnemy>().cool <= 0 && gameManager.playerTurn == false)
        {
            removeWindEnemy.GetComponent<removeWindEnemy>().pardon();
        }
        else
        {
            removeWindEnemy.GetComponent<removeWindEnemy>().ban();
        }

        //11
        if (typhoonEnemy.GetComponent<typhoonEnemy>().cool <= 0 && gameManager.playerTurn == false)
        {
            typhoonEnemy.GetComponent<typhoonEnemy>().pardon();
        }
        else
        {
            typhoonEnemy.GetComponent<typhoonEnemy>().ban();
        }

    }
    public void countCoolEnemy() { //모든 스킬에 대해서, 쿨타임 1턴을 넘긴다. (cool--), (GameManager에서 이것을 매턴마다 호출)
        smallTargetEnemy.GetComponent<smallTargetEnemy>().cool--; //1
        bigTargetEnemy.GetComponent<bigTargetEnemy>().cool--; //2
        movingTargetEnemy.GetComponent<movingTargetEnemy>().cool--; //3
        reduceCoolEnemy.GetComponent<reduceCoolEnemy>().cool--; //4 
        removeSkillEnemy.GetComponent<removeSkillEnemy>().cool--; //5
        scoreBonusEnemy.GetComponent<scoreBonusEnemy>().cool--; //6  
        bigArrowEnemy.GetComponent<bigArrowEnemy>().cool--; //7
        doubleArrowEnemy.GetComponent<doubleArrowEnemy>().cool--; //8
        transparentEnemy.GetComponent<transparentEnemy>().cool--; //9
        removeWindEnemy.GetComponent<removeWindEnemy>().cool--; //10
        typhoonEnemy.GetComponent<typhoonEnemy>().cool--; //11 
    }
}
