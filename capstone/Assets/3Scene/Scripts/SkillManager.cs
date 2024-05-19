using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public GameObject SkillPanelManager; //��ų �г� ��ũ��Ʈ

    public GameObject reduceCool; //��ų ��ũ��Ʈ4 (��Ÿ�� ����)
    public GameObject removeSkill; //��ų ��ũ��Ʈ5 (��ų ��ȿȭ)
    public GameObject scoreBonus; //��ų ��ũ��Ʈ6 (��ų ���ʽ�)

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void skillOn() { //text�� � ��ų�� ����� ������ �����Ͽ�, if������ �˸��� ��ų�� �ߵ� ��Ų��

        //��ų4
        if (SkillPanelManager.GetComponent<SkillPanelManager>().skillText.text == "��Ÿ�� ���� : �÷��̾��� ��ų ��Ÿ���� 1�� ���ҽ�ŵ�ϴ�.")
        {
            reduceCool.GetComponent<reduceCool>().execute(); //��ų �ߵ�
            reduceCool.GetComponent<reduceCool>().setCool(SkillPanelManager.GetComponent<SkillPanelManager>().selected); //��Ÿ�� ����
        }

        //��ų5
        if (SkillPanelManager.GetComponent<SkillPanelManager>().skillText.text == "��ų ��ȿȭ : �� ���� �ߵ� ���� ��ų�� ��ȿȭ �մϴ�.")
        {
            removeSkill.GetComponent<removeSkill>().execute();
            removeSkill.GetComponent<removeSkill>().setCool(SkillPanelManager.GetComponent<SkillPanelManager>().selected);
        }

        //��ų6
        if (SkillPanelManager.GetComponent<SkillPanelManager>().skillText.text == "���� ���ʽ� : 1�� ���� ������ 2��� ����ϴ�.") 
        {
            scoreBonus.GetComponent<scoreBonus>().execute();
            scoreBonus.GetComponent<scoreBonus>().setCool(SkillPanelManager.GetComponent<SkillPanelManager>().selected);
        }
    }
}
