using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doubleArrow : ArrowSkill
{
    public GameObject SkillPanelManager; //��ų �г� ��ũ��Ʈ
    public GameManager gameManager;

    public bool skill = false; //��ų�� �ߵ� ���ΰ�? 
    public int cool = 0; //��Ÿ��(��), �� ���� ������ �� ��ٷ��� �ϴ°��� ����
    public int num = -1; //��ų�� ���õǾ��� ��, ���� ���° ��ų���� ��üȭ, ban() �� pardon()���� ����

    // Start is called before the first frame update
    void Start()
    {
        activeTurns = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void execute() { //��ų �ߵ�
        skill = true;

        gameManager.activatedArrowSkills.Add(this);

        Debug.Log("������");
    }

    public override void disable()
    {
        skill = false;
        activeTurns = 2;
    }

    public void setCool(int selected, int cool_time) { //��Ÿ�� ����
        cool = cool_time; //��Ÿ�� (������ ���Խ�Ų ��, �׻� Ȧ���� ��)
        num = selected;
    }

    public void ban() { //��ų ���� �����
        if (num == 1) { //���� 1�� ��ų�̸� 1�� ��ų ��ư�� ��Ȱ��ȭ
            SkillPanelManager.GetComponent<SkillPanelManager>().buttonA.interactable = false;
        }
        else if (num == 2)
        {
            SkillPanelManager.GetComponent<SkillPanelManager>().buttonB.interactable = false;
        }
        else if (num == 3)
        {
            SkillPanelManager.GetComponent<SkillPanelManager>().buttonC.interactable = false;
        }
    }

    public void pardon() { //��ų ���� ���
        if (num == 1) { //���� 1�� ��ų�̸� 1�� ��ų ��ư�� Ȱ��ȭ
            SkillPanelManager.GetComponent<SkillPanelManager>().buttonA.interactable = true;
        }
        else if (num == 2)
        {
            SkillPanelManager.GetComponent<SkillPanelManager>().buttonB.interactable = true;
        }
        else if (num == 3)
        {
            SkillPanelManager.GetComponent<SkillPanelManager>().buttonC.interactable = true;
        }
    }
}