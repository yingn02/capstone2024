using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManagerEnemy : MonoBehaviour
{
    private List<int> skills = new List<int>(); //������ ���� ��ų ����Ʈ

    public GameManager gameManager; //GameManager ��ũ��Ʈ, �÷��̾��� ���� �����ϱ� ����
    public GameObject SkillPanelManager; //SkillPanelManager ��ũ��Ʈ, ������Ʈ�� �ִ� ��ų�� �� ������ �˾Ƴ��� ����
    public GameObject SkillPanelManagerEnemy; //SkillPanelManagerEnemy ��ũ��Ʈ, ������ ��ų ��ư�� ���� �� ������ �����ϱ� ����

    public GameObject reduceCoolEnemy; //��ų ��ũ��Ʈ4 (��Ÿ�� ����)
    public GameObject removeSkillEnemy; //��ų ��ũ��Ʈ5 (��ų ��ȿȭ)
    public GameObject scoreBonusEnemy; //��ų ��ũ��Ʈ6 (��ų ���ʽ�)

    public int selected = 0; //������ �������� �ϴ� ��ų ��ư�� �ε���
    public bool press = false; //��ų ��ư�� ������

    // Start is called before the first frame update
    void Start()
    {
        //������ ��ų 3���� ����. (�ߺ�X) ������ 3������ ���������� �ö� ������ 1���� �� �� ����
        while (skills.Count < 3)
        {
            int skill_num = Random.Range(1, SkillPanelManager.GetComponent<SkillPanelManager>().skill_length + 1); //������Ʈ�� �ִ� �� �߿��� ��� ��ų�� ���� ����

            if (!skills.Contains(skill_num))
            {
                skills.Add(skill_num);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //�� �ٲ��� �����Ͽ� ��ų ����� �õ�
        if (gameManager.enemy_try_skill == true) {
            if (gameManager.playerTurn == false) { //������ ������ �Ͽ����� ��ų�� ���ȴ�
                skillOn();
            }
            gameManager.enemy_try_skill = false;
        }
    }

    public void skillOn() { //����� ��ų�߿��� 1���� �������� ���� �ϰ�(��ư����), if������ �˸��� ��ų�� �ߵ� ��Ų��

        selected = Random.Range(0, skills.Count);

        if (SkillPanelManagerEnemy.GetComponent<SkillPanelManagerEnemy>().buttons[selected]) { //selected�� ������ �������� ��ų ��ư�� Ȱ��ȭ �Ǿ��ִٸ� 
            press = true; //�� ��ư�� ������
        }
        else if (!SkillPanelManagerEnemy.GetComponent<SkillPanelManagerEnemy>().buttons[selected]) { //��, ���� �������� �ϴ� ��ư�� ��Ȱ��ȭ��� �ٸ� ��ư�� ã�´�.
            for (int i = 0; i < skills.Count; i++) {
                selected = 0;

                if (SkillPanelManagerEnemy.GetComponent<SkillPanelManagerEnemy>().buttons[selected]) {
                    press = true;
                    break;
                }

                selected += 1;
            }
        }

        //��ų4
        if (skills[selected] == 4 && press) // ��Ÿ�� ����
        {
            reduceCoolEnemy.GetComponent<reduceCoolEnemy>().execute(); //��ų �ߵ�
            reduceCoolEnemy.GetComponent<reduceCool>().setCool(selected); //��Ÿ�� ����
            press = false;
        }

        //��ų5
        if (skills[selected] == 5 && press) //��ų ��ȿȭ
        {
            removeSkillEnemy.GetComponent<removeSkillEnemy>().execute();
            removeSkillEnemy.GetComponent<removeSkillEnemy>().setCool(selected);
            press = false;
        }

        //��ų6
        if (skills[selected] == 6 && press) //���� ���ʽ�
        {
            scoreBonusEnemy.GetComponent<scoreBonusEnemy>().execute();
            scoreBonusEnemy.GetComponent<scoreBonusEnemy>().setCool(selected);
            press = false;
        }
    }
}
