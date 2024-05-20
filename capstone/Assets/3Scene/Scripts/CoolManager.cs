using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolManager : MonoBehaviour
{
    public GameManager gameManager; //GameManager ��ũ��Ʈ, �÷��̾��� ���� �����ϱ� ����

    public GameObject smallTarget; //��ų ��ũ��Ʈ1 (���� ũ�� ����)
    public GameObject bigTarget; //��ų ��ũ��Ʈ2 (���� ũ�� ����)
    public GameObject movingTarget; //��ų ��ũ��Ʈ3 (���� �����̱�)
    public GameObject reduceCool; //��ų ��ũ��Ʈ4 (��Ÿ�� ����)
    public GameObject removeSkill; //��ų ��ũ��Ʈ5 (��ų ��ȿȭ)
    public GameObject scoreBonus; //��ų ��ũ��Ʈ6 (���� ���ʽ�)
    public GameObject bigArrow; //��ų ��ũ��Ʈ7 (ȭ�� �Ŵ�ȭ)
    public GameObject doubleArrow; //��ų ��ũ��Ʈ8 (����)
    public GameObject transparent; //��ų ��ũ��Ʈ9 (���� ȭ��� ����)
    public GameObject removeWind; //��ų ��ũ��Ʈ10 (ǳ�� ����)
    public GameObject typhoon; //��ų ��ũ��Ʈ11 (��ǳ)

    // Start is called before the first frame update
    void Start()
    {
        gameManager.skill = true; //��ų������� GameManager���� �˸�
    }

    // Update is called once per frame
    void Update()
    {
        //�� �����Ͽ� ��Ÿ���� ����
        if (gameManager.count_cool == true) {
            countCool(); 
            gameManager.count_cool = false;
        }

        //1
        if (smallTarget.GetComponent<smallTarget>().cool <= 0 && gameManager.playerTurn == true) {
            smallTarget.GetComponent<smallTarget>().pardon(); //��ų ���� ���
        }
        else
        {
            smallTarget.GetComponent<smallTarget>().ban(); //��ų ���� �����
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

    public void countCool() { //��� ��ų�� ���ؼ�, ��Ÿ�� 1���� �ѱ��. (cool--), (GameManager���� �̰��� ���ϸ��� ȣ��)
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
