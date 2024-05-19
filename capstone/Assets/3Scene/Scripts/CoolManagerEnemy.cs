using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolManagerEnemy : MonoBehaviour
{
    public GameObject reduceCoolEnemy; //��ų ��ũ��Ʈ4 (��Ÿ�� ����)
    public GameObject removeSkillEnemy; //��ų ��ũ��Ʈ5 (��ų ��ȿȭ)
    public GameObject scoreBonusEnemy; //��ų ��ũ��Ʈ6 (��ų ���ʽ�)

    public GameManager gameManager; //GameManager ��ũ��Ʈ, �÷��̾��� ���� �����ϱ� ����

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�� �����Ͽ� ��Ÿ���� ����
        if (gameManager.count_cool_enemy == true){
            countCoolEnemy();
            gameManager.count_cool_enemy = false;
        }

        //4
        if (reduceCoolEnemy.GetComponent<reduceCoolEnemy>().cool <= 0 && gameManager.playerTurn == true) { //��Ÿ���� ���������� 
            reduceCoolEnemy.GetComponent<reduceCoolEnemy>().pardon(); //��ų ���� ���
        }
        else
        {
            reduceCoolEnemy.GetComponent<reduceCoolEnemy>().ban(); //��ų ���� �����
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
    public void countCoolEnemy() { //��� ��ų�� ���ؼ�, ��Ÿ�� 1���� �ѱ��. (cool--), (GameManager���� �̰��� ���ϸ��� ȣ��)
        reduceCoolEnemy.GetComponent<reduceCoolEnemy>().cool--; //4 
        removeSkillEnemy.GetComponent<removeSkillEnemy>().cool--; //5
        scoreBonusEnemy.GetComponent<scoreBonusEnemy>().cool--; //6  
    }
}
