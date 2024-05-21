using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolManagerEnemy : MonoBehaviour
{
    public GameManager gameManager; //GameManager ��ũ��Ʈ, �÷��̾��� ���� �����ϱ� ����
    public GameObject changeWind; //changeWind ��ũ��Ʈ

    public GameObject smallTargetEnemy; //��ų ��ũ��Ʈ1 (���� ũ�� ����)
    public GameObject bigTargetEnemy; //��ų ��ũ��Ʈ2 (���� ũ�� ����)
    public GameObject movingTargetEnemy; //��ų ��ũ��Ʈ3 (���� �����̱�)
    public GameObject reduceCoolEnemy; //��ų ��ũ��Ʈ4 (��Ÿ�� ����)
    public GameObject removeSkillEnemy; //��ų ��ũ��Ʈ5 (��ų ��ȿȭ)
    public GameObject scoreBonusEnemy; //��ų ��ũ��Ʈ6 (���� ���ʽ�)
    public GameObject bigArrowEnemy; //��ų ��ũ��Ʈ7 (ȭ�� �Ŵ�ȭ)
    public GameObject doubleArrowEnemy; //��ų ��ũ��Ʈ8 (����)
    public GameObject transparentEnemy; //��ų ��ũ��Ʈ9 (���� ȭ��� ����)
    public GameObject removeWindEnemy; //��ų ��ũ��Ʈ10 (ǳ�� ����)
    public GameObject typhoonEnemy; //��ų ��ũ��Ʈ11 (��ǳ)

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�� �����Ͽ� ��Ÿ���� ����, ǳ�⵵ �ʱ�ȭ
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
        if (smallTargetEnemy.GetComponent<smallTargetEnemy>().cool <= 0 && gameManager.playerTurn == false){ //��Ÿ���� ���������� 
            smallTargetEnemy.GetComponent<smallTargetEnemy>().pardon(); //��ų ���� ���
        }
        else
        {
            smallTargetEnemy.GetComponent<smallTargetEnemy>().ban(); //��ų ���� �����
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
    public void countCoolEnemy() { //��� ��ų�� ���ؼ�, ��Ÿ�� 1���� �ѱ��. (cool--), (GameManager���� �̰��� ���ϸ��� ȣ��)
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
