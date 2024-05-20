using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class SkillPanelManager : MonoBehaviour
{
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

    public TMP_Text skillText;
    public Button buttonA; //��ų1 ��ư
    public Button buttonB;
    public Button buttonC;

    public int selected = 0; //���° ��ų�� ���õǾ��°� (��ų���� ��Ÿ���� �ٸ��Ƿ�, SkillManager ��ũ��Ʈ���� ����� ���� �ʿ�)

    public List<string> skillList = new List<string>(); //��ų�ؽ�Ʈ ����Ȱ ����Ʈ

    void Start()
    {
        // ButtonSelection���� ���õ� ��ų �ؽ�Ʈ �ٽ� skillList�� ����
        skillList = ButtonSelection.GetSelectedButtonTexts();

        // �ʱ� ��ư ���� ���� (��ư & ��Ÿ�� ���� ����)
        smallTarget.GetComponent<smallTarget>().num = -1;
        bigTarget.GetComponent<bigTarget>().num = -1;
        movingTarget.GetComponent<movingTarget>().num = -1;

        reduceCool.GetComponent<reduceCool>().num = -1;
        removeSkill.GetComponent<removeSkill>().num = -1;
        scoreBonus.GetComponent<scoreBonus>().num = -1;

        bigArrow.GetComponent<bigArrow>().num = -1;
        doubleArrow.GetComponent<doubleArrow>().num = -1;
        transparent.GetComponent<transparent>().num = -1;

        removeWind.GetComponent<removeWind>().num = -1;
        typhoon.GetComponent<typhoon>().num = -1;

        initialSet();
        //

        // ���õ� ��ų ������ �ؽ�Ʈ ���
        if (skillList == null || skillList.Count == 0)
        {
            skillText.text = "";
            return;
        }

        buttonA.onClick.AddListener(OnButtonClickA);
        buttonB.onClick.AddListener(OnButtonClickB);
        buttonC.onClick.AddListener(OnButtonClickC);
    }

    void Update()
    {
        Debug.Log(selected);
    }

    public void OnButtonClickA()
    {
        skillText.text = skillList[0];
        selected = 1;
    }

    public void OnButtonClickB()
    {
        skillText.text = skillList[1]; 
        selected = 2;
    }

    public void OnButtonClickC()
    {
        skillText.text = skillList[2];
        selected = 3;
    }

    public void initialSet() { //�ʱ� ��ư ���� ���� (��ư & ��Ÿ�� ���� ����)
        for (int i = 0; i < 3; i++)
        {
            if (skillList[i] == "���� ũ�� ���� : ���� ũ�� ����") smallTarget.GetComponent<smallTarget>().setCool(i + 1, 0);
            else if (skillList[i] == "���� ũ�� ���� : ���� ũ�� ����") bigTarget.GetComponent<bigTarget>().setCool(i + 1, 0);
            else if (skillList[i] == "���� �����̱� : ���� �����̱�") movingTarget.GetComponent<movingTarget>().setCool(i + 1, 0);
            else if (skillList[i] == "��Ÿ�� ���� : �÷��̾��� ��� ��ų ��Ÿ���� 1�� �����Ѵ�.") reduceCool.GetComponent<reduceCool>().setCool(i + 1, 0);
            else if (skillList[i] == "��ų ��ȿȭ : �� ���� �ߵ� ���� ��� ��ų�� ��ȿȭ �Ѵ�.") removeSkill.GetComponent<removeSkill>().setCool(i + 1, 0);
            else if (skillList[i] == "���� ���ʽ� : ���� �Ͽ��� ������ 2��� ���� �� �ִ�.") scoreBonus.GetComponent<scoreBonus>().setCool(i + 1, 0);       
            else if (skillList[i] == "ȭ�� �Ŵ�ȭ : ȭ�� �Ŵ�ȭ") bigArrow.GetComponent<bigArrow>().setCool(i + 1, 0);
            else if (skillList[i] == "���� : ����") doubleArrow.GetComponent<doubleArrow>().setCool(i + 1, 0);
            else if (skillList[i] == "���� ȭ��� ���� : ���� ȭ��� ����") transparent.GetComponent<transparent>().setCool(i + 1, 0);
            else if (skillList[i] == "ǳ�� ����: ǳ�� ����") removeWind.GetComponent<removeWind>().setCool(i + 1, 0);
            else if (skillList[i] == "��ǳ : ��ǳ") typhoon.GetComponent<typhoon>().setCool(i + 1, 0);
        }

    }
}


