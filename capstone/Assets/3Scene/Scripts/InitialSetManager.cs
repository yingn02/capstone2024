using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialSetManager : MonoBehaviour
{
    //private List<string> skillList2 = new List<string>(); //��ų�ؽ�Ʈ ����Ʈ�� SkillManager���� ������
    
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

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void initialSet(List<string> skillList) { //�ʱ� ��ư ���� ���� (��Ÿ�� ���� ����)
        for (int i = 0; i < 3; i++)
        {
            if (skillList[i] == "���� ũ�� ���� : ���� ũ�� ����") smallTarget.GetComponent<smallTarget>().setCool(i, 0); //��Ÿ�� ����
            else if (skillList[i] == "���� ũ�� ���� : ���� ũ�� ����") bigTarget.GetComponent<bigTarget>().setCool(i, 0);
            else if (skillList[i] == "���� �����̱� : ���� �����̱�") movingTarget.GetComponent<movingTarget>().setCool(i, 0);

            else if (skillList[i] == "��Ÿ�� ���� : ��Ÿ�� ���� : �÷��̾��� ��� ��ų ��Ÿ���� 1�� �����Ѵ�.") reduceCool.GetComponent<reduceCool>().setCool(i, 0);
            else if (skillList[i] == "��ų ��ȿȭ : �� ���� �ߵ� ���� ��� ��ų�� ��ȿȭ �Ѵ�.") removeSkill.GetComponent<removeSkill>().setCool(i, 0);
            else if (skillList[i] == "���� ���ʽ� : ���� �Ͽ��� ������ 2��� ���� �� �ִ�.") scoreBonus.GetComponent<scoreBonus>().setCool(i, 0);

            else if (skillList[i] == "ȭ�� �Ŵ�ȭ : ȭ�� �Ŵ�ȭ") bigArrow.GetComponent<bigArrow>().setCool(i, 0);
            else if (skillList[i] == "���� : ����") doubleArrow.GetComponent<doubleArrow>().setCool(i, 0);
            else if (skillList[i] == "���� ȭ��� ���� : ���� ȭ��� ����") transparent.GetComponent<transparent>().setCool(i, 0);

            else if (skillList[i] == "ǳ�� ����: ǳ�� ����") removeWind.GetComponent<removeWind>().setCool(i, 0);
            else if (skillList[i] == "��ǳ : ��ǳ") typhoon.GetComponent<typhoon>().setCool(i, 0);
        }
    }
    
}
