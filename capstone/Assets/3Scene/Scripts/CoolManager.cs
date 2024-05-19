using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolManager : MonoBehaviour
{
    public GameObject reduceCool; //��ų ��ũ��Ʈ4 (��Ÿ�� ����)
    public GameObject removeSkill; //��ų ��ũ��Ʈ5 (��ų ��ȿȭ)
    public GameObject scoreBonus; //��ų ��ũ��Ʈ6 (��ų ���ʽ�)

    public GameManager gameManager; //GameManager ��ũ��Ʈ, �÷��̾��� ���� �����ϱ� ����

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

        //4
        if (reduceCool.GetComponent<reduceCool>().cool <= 0 && gameManager.playerTurn == true) { //��Ÿ���� ���������� 
            reduceCool.GetComponent<reduceCool>().pardon(); //��ų ���� ���
        }
        else {
            reduceCool.GetComponent<reduceCool>().ban(); //��ų ���� �����
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

    public void countCool() { //��� ��ų�� ���ؼ�, ��Ÿ�� 1���� �ѱ��. (cool--), (GameManager���� �̰��� ���ϸ��� ȣ��)
        reduceCool.GetComponent<reduceCool>().cool--; //4 
        removeSkill.GetComponent<removeSkill>().cool--; //5
        scoreBonus.GetComponent<scoreBonus>().cool--; //6  
    }
}
