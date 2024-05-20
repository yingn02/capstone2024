using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManagerEnemy : MonoBehaviour
{
    private List<int> skills = new List<int>(); //������ ���� ��ų ����Ʈ

    public GameManager gameManager; //GameManager ��ũ��Ʈ, �÷��̾��� ���� �����ϱ� ����
    public GameObject SkillPanelManagerEnemy; //SkillPanelManagerEnemy ��ũ��Ʈ, ������ ��ų ��ư�� ���� �� ������ �����ϱ� ����

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

    public int selected = 0; //������ �������� �ϴ� ��ų ��ư�� �ε���
    public bool press = false; //��ų ��ư�� ������

    // Start is called before the first frame update
    void Start()
    {
        //������ ��ų 3���� ����. (�ߺ�X) ������ 3������ ���������� �ö� ������ 1���� �� �� ����
        while (skills.Count < 3)
        {
            int skill_num = Random.Range(1, 11 + 1); //������Ʈ�� �ִ� �� �߿��� ��� ��ų�� ���� ����

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

        //��ų1
        if (skills[selected] == 1 && press) // ���� ũ�� ����
        {
            smallTargetEnemy.GetComponent<smallTargetEnemy>().execute(); //��ų �ߵ�
            smallTargetEnemy.GetComponent<smallTargetEnemy>().setCool(selected); //��Ÿ�� ����
            press = false;
        }

        //��ų2
        if (skills[selected] == 2 && press) // ���� ũ�� ����
        {
            bigTargetEnemy.GetComponent<bigTargetEnemy>().execute();
            bigTargetEnemy.GetComponent<bigTargetEnemy>().setCool(selected);
            press = false;
        }

        //��ų3
        if (skills[selected] == 3 && press) // ���� �����̱�
        {
            movingTargetEnemy.GetComponent<movingTargetEnemy>().execute();
            movingTargetEnemy.GetComponent<movingTargetEnemy>().setCool(selected);
            press = false;
        }

        //��ų4
        if (skills[selected] == 4 && press)
        {
            reduceCoolEnemy.GetComponent<reduceCoolEnemy>().execute();
            reduceCoolEnemy.GetComponent<reduceCoolEnemy>().setCool(selected);
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

        //��ų7
        if (skills[selected] == 7 && press) // ȭ�� �Ŵ�ȭ
        {
            bigArrowEnemy.GetComponent<bigArrowEnemy>().execute();
            bigArrowEnemy.GetComponent<bigArrowEnemy>().setCool(selected);
            press = false;
        }

        //��ų8
        if (skills[selected] == 8 && press) // ����
        {
            doubleArrowEnemy.GetComponent<doubleArrowEnemy>().execute();
            doubleArrowEnemy.GetComponent<doubleArrowEnemy>().setCool(selected);
            press = false;
        }

        //��ų9
        if (skills[selected] == 9 && press) // ���� ȭ��� ����
        {
            transparentEnemy.GetComponent<transparentEnemy>().execute();
            transparentEnemy.GetComponent<transparentEnemy>().setCool(selected);
            press = false;
        }

        //��ų10
        if (skills[selected] == 10 && press) // ǳ�� ����
        {
            removeWindEnemy.GetComponent<removeWindEnemy>().execute();
            removeWindEnemy.GetComponent<removeWindEnemy>().setCool(selected);
            press = false;
        }

        //��ų11
        if (skills[selected] == 11 && press) // ��ǳ
        {
            typhoonEnemy.GetComponent<typhoonEnemy>().execute();
            typhoonEnemy.GetComponent<typhoonEnemy>().setCool(selected);
            press = false;
        }


    }
}
