using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolManager : MonoBehaviour
{
    public GameManager gameManager; //GameManager 스크립트, 플레이어의 턴을 감지하기 위함

    public GameObject smallTarget; //스킬 스크립트1 (과녁 크기 감소)
    public GameObject bigTarget; //스킬 스크립트2 (과녁 크기 증가)
    public GameObject movingTarget; //스킬 스크립트3 (과녁 움직이기)
    public GameObject reduceCool; //스킬 스크립트4 (쿨타임 감소)
    public GameObject removeSkill; //스킬 스크립트5 (스킬 무효화)
    public GameObject scoreBonus; //스킬 스크립트6 (점수 보너스)
    public GameObject bigArrow; //스킬 스크립트7 (화살 거대화)
    public GameObject doubleArrow; //스킬 스크립트8 (더블샷)
    public GameObject transparent; //스킬 스크립트9 (투명 화살과 과녁)
    public GameObject removeWind; //스킬 스크립트10 (풍향 제거)
    public GameObject typhoon; //스킬 스크립트11 (태풍)

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

        //1
        if (smallTarget.GetComponent<smallTarget>().cool <= 0 && gameManager.playerTurn == true) {
            smallTarget.GetComponent<smallTarget>().pardon(); //스킬 선택 허용
        }
        else
        {
            smallTarget.GetComponent<smallTarget>().ban(); //스킬 선택 비허용
        }

        //2
        if (bigTarget.GetComponent<bigTarget>().cool <= 0 && gameManager.playerTurn == true) {
            bigTarget.GetComponent<bigTarget>().pardon();
        }
        else
        {
            bigTarget.GetComponent<bigTarget>().ban();
        }

        //3
        if (movingTarget.GetComponent<movingTarget>().cool <= 0 && gameManager.playerTurn == true) {
            movingTarget.GetComponent<movingTarget>().pardon();
        }
        else
        {
            movingTarget.GetComponent<movingTarget>().ban();
        }

        //4
        if (reduceCool.GetComponent<reduceCool>().cool <= 0 && gameManager.playerTurn == true) {  
            reduceCool.GetComponent<reduceCool>().pardon(); 
        }
        else {
            reduceCool.GetComponent<reduceCool>().ban(); 
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

        //7
        if (bigArrow.GetComponent<bigArrow>().cool <= 0 && gameManager.playerTurn == true) {
            bigArrow.GetComponent<bigArrow>().pardon();
        }
        else
        {
            bigArrow.GetComponent<bigArrow>().ban();
        }

        //8
        if (doubleArrow.GetComponent<doubleArrow>().cool <= 0 && gameManager.playerTurn == true) {
            doubleArrow.GetComponent<doubleArrow>().pardon();
        }
        else
        {
            doubleArrow.GetComponent<doubleArrow>().ban();
        }

        //9
        if (transparent.GetComponent<transparent>().cool <= 0 && gameManager.playerTurn == true) {
            transparent.GetComponent<transparent>().pardon();
        }
        else
        {
            transparent.GetComponent<transparent>().ban();
        }

        //10
        if (removeWind.GetComponent<removeWind>().cool <= 0 && gameManager.playerTurn == true) {
            removeWind.GetComponent<removeWind>().pardon();
        }
        else
        {
            removeWind.GetComponent<removeWind>().ban();
        }

        //11
        if (typhoon.GetComponent<typhoon>().cool <= 0 && gameManager.playerTurn == true) {
            typhoon.GetComponent<typhoon>().pardon();
        }
        else
        {
            typhoon.GetComponent<typhoon>().ban();
        }

    }

    public void countCool() { //모든 스킬에 대해서, 쿨타임 1턴을 넘긴다. (cool--), (GameManager에서 이것을 매턴마다 호출)
        smallTarget.GetComponent<smallTarget>().cool--; //1
        bigTarget.GetComponent<bigTarget>().cool--; //2
        movingTarget.GetComponent<movingTarget>().cool--; //3
        reduceCool.GetComponent<reduceCool>().cool--; //4 
        removeSkill.GetComponent<removeSkill>().cool--; //5
        scoreBonus.GetComponent<scoreBonus>().cool--; //6  
        bigArrow.GetComponent<bigArrow>().cool--; //7
        doubleArrow.GetComponent<doubleArrow>().cool--; //8
        transparent.GetComponent<transparent>().cool--; //9
        removeWind.GetComponent<removeWind>().cool--; //10
        typhoon.GetComponent<typhoon>().cool--; //11
    }

}
