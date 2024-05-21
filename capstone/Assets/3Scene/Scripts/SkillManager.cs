using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public GameObject SkillPanelManager; //��ų �г� ��ũ��Ʈ

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

    public void skillOn() { //text�� � ��ų�� ����� ������ �����Ͽ�, if������ �˸��� ��ų�� �ߵ� ��Ų��

        //��ų1
        if (SkillPanelManager.GetComponent<SkillPanelManager>().skillText.text == "���� ũ�� ���� : ���� ũ�� ����")
        {
            smallTarget.GetComponent<smallTarget>().execute(); //��ų �ߵ�
            smallTarget.GetComponent<smallTarget>().setCool(SkillPanelManager.GetComponent<SkillPanelManager>().selected, 5); //��Ÿ�� ����
        }

        //��ų2
        if (SkillPanelManager.GetComponent<SkillPanelManager>().skillText.text == "���� ũ�� ���� : ���� ũ�� ����")
        {
            bigTarget.GetComponent<bigTarget>().execute();
            bigTarget.GetComponent<bigTarget>().setCool(SkillPanelManager.GetComponent<SkillPanelManager>().selected, 5);
        }

        //��ų3
        if (SkillPanelManager.GetComponent<SkillPanelManager>().skillText.text == "���� �����̱� : ���� �����̱�")
        {
            movingTarget.GetComponent<movingTarget>().execute();
            movingTarget.GetComponent<movingTarget>().setCool(SkillPanelManager.GetComponent<SkillPanelManager>().selected, 5);
        }

        //��ų4
        if (SkillPanelManager.GetComponent<SkillPanelManager>().skillText.text == "��Ÿ�� ���� : �÷��̾��� ��� ��ų ��Ÿ���� 1�� �����Ѵ�.")
        {
            reduceCool.GetComponent<reduceCool>().execute(); 
            reduceCool.GetComponent<reduceCool>().setCool(SkillPanelManager.GetComponent<SkillPanelManager>().selected, 5);
        }

        //��ų5
        if (SkillPanelManager.GetComponent<SkillPanelManager>().skillText.text == "��ų ��ȿȭ : �� ���� �ߵ� ���� ��� ��ų�� ��ȿȭ �Ѵ�.")
        {
            removeSkill.GetComponent<removeSkill>().execute();
            removeSkill.GetComponent<removeSkill>().setCool(SkillPanelManager.GetComponent<SkillPanelManager>().selected, 5);
        }

        //��ų6
        if (SkillPanelManager.GetComponent<SkillPanelManager>().skillText.text == "���� ���ʽ� : ���� �Ͽ��� ������ 2��� ���� �� �ִ�.") 
        {
            scoreBonus.GetComponent<scoreBonus>().execute();
            scoreBonus.GetComponent<scoreBonus>().setCool(SkillPanelManager.GetComponent<SkillPanelManager>().selected, 5);
        }

        //��ų7
        if (SkillPanelManager.GetComponent<SkillPanelManager>().skillText.text == "ȭ�� �Ŵ�ȭ : ȭ�� �Ŵ�ȭ")
        {
            bigArrow.GetComponent<bigArrow>().execute();
            bigArrow.GetComponent<bigArrow>().setCool(SkillPanelManager.GetComponent<SkillPanelManager>().selected, 5);
        }

        //��ų8
        if (SkillPanelManager.GetComponent<SkillPanelManager>().skillText.text == "���� : ����")
        {
            doubleArrow.GetComponent<doubleArrow>().execute();
            doubleArrow.GetComponent<doubleArrow>().setCool(SkillPanelManager.GetComponent<SkillPanelManager>().selected, 5);
        }

        //��ų9
        if (SkillPanelManager.GetComponent<SkillPanelManager>().skillText.text == "���� ȭ��� ���� : ���� ȭ��� ����")
        {
            transparent.GetComponent<transparent>().execute();
            transparent.GetComponent<transparent>().setCool(SkillPanelManager.GetComponent<SkillPanelManager>().selected, 5);
        }

        //��ų10
        if (SkillPanelManager.GetComponent<SkillPanelManager>().skillText.text == "ǳ�� ���� : ǳ�� ����")
        {
            removeWind.GetComponent<removeWind>().execute();
            removeWind.GetComponent<removeWind>().setCool(SkillPanelManager.GetComponent<SkillPanelManager>().selected, 5);
        }

        //��ų11
        if (SkillPanelManager.GetComponent<SkillPanelManager>().skillText.text == "��ǳ : ��ǳ")
        {
            typhoon.GetComponent<typhoon>().execute();
            typhoon.GetComponent<typhoon>().setCool(SkillPanelManager.GetComponent<SkillPanelManager>().selected, 5);
        }
    }
}
