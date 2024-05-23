using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigArrowEnemy : ArrowSkill
{
    public GameObject SkillPanelManagerEnemy; //��ų �г� ��ũ��Ʈ
    public GameManager gameManager;

    public GameObject arrow;

    public bool skill = false; //��ų�� �ߵ� ���ΰ�?
    public int cool = 0; //��Ÿ��(��), �� ���� ������ �� ��ٷ��� �ϴ°��� ����
    public int num = -1; //��ų�� ���õǾ��� ��, ���� ���° ��ų���� ��üȭ, ban() �� pardon()���� ����

    // Start is called before the first frame update
    void Start()
    {
        activeTurns = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void execute() { //��ų �ߵ�
        skill = true;

        gameManager.activatedArrowSkills.Add(this);
        arrow.transform.localScale = new Vector3(0.5f, 3.0f, 3.0f);

        Debug.Log("ȭ�� �Ŵ�ȭE");
    }

    public override void disable()
    {
        skill = false;
        arrow = null;
        activeTurns = 1;
    }

    public void setCool(int selected, int cool_time) { //��Ÿ�� ����
        cool = cool_time; //��Ÿ�� (������ ���Խ�Ų ��, �׻� Ȧ���� ��)
        num = selected;
    }

    public void ban() { //��ų ���� �����
        SkillPanelManagerEnemy.GetComponent<SkillPanelManagerEnemy>().buttons[num] = false; //���� 1�� ��ų�̸� 1�� ��ų ��ư�� ��Ȱ��ȭ
    }

    public void pardon() { //��ų ���� ���
        SkillPanelManagerEnemy.GetComponent<SkillPanelManagerEnemy>().buttons[num] = true; //���� 1�� ��ų�̸� 1�� ��ų ��ư�� Ȱ��ȭ
    }
}
