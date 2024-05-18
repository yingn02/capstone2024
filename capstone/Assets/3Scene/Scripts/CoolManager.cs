using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolManager : MonoBehaviour
{
    public GameObject reduceCool; //스킬 스크립트4 (쿨타임 감소)
    public GameObject scoreBonus; //스킬 스크립트6 (스킬 보너스)
    public GameManager gameManager; //GameManager 스크립트, 플레이어의 턴을 감지하기 위함

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //4
        if (reduceCool.GetComponent<reduceCool>().cool <= 0 && gameManager.playerTurn == true) { //쿨타임이 남아있으면 
            reduceCool.GetComponent<reduceCool>().pardon(); //스킬 선택 허용
        }
        else {
            reduceCool.GetComponent<reduceCool>().ban(); //스킬 선택 비허용
        }

        //6
        if (scoreBonus.GetComponent<scoreBonus>().cool <= 0 && gameManager.playerTurn == true) {
            scoreBonus.GetComponent<scoreBonus>().pardon();
        }
        else {
            scoreBonus.GetComponent<scoreBonus>().ban();
        }
    }

    public void countCool() { //모든 스킬에 대해서, 쿨타일 1턴을 넘긴다. (cool--), (GameManager에서 이것을 매턴마다 호출)
        reduceCool.GetComponent<reduceCool>().cool--;//4 
        scoreBonus.GetComponent<scoreBonus>().cool--; //6  
    }
}
