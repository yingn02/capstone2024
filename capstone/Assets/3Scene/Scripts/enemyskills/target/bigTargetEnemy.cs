using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigTargetEnemy : MonoBehaviour
{
    public GameObject SkillPanelManagerEnemy; //��ų �г� ��ũ��Ʈ

    public bool skill = false; //��ų�� �ߵ� ���ΰ�?
    public int cool = 0; //��Ÿ��(��), �� ���� ������ �� ��ٷ��� �ϴ°��� ����
    public int num = -1; //��ų�� ���õǾ��� ��, ���� ���° ��ų���� ��üȭ, ban() �� pardon()���� ����

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void execute() { //��ų �ߵ�
        Debug.Log("���� ũ�� ����E");
        skill = true;
        skill = false;
    }

    public void setCool(int selected) { //��Ÿ�� ����
        cool = 5; //��Ÿ�� (������ ���Խ�Ų ��, �׻� Ȧ���� ��)
        num = selected;
    }

    public void ban() { //��ų ���� �����
        SkillPanelManagerEnemy.GetComponent<SkillPanelManagerEnemy>().buttons[num] = false; //���� 1�� ��ų�̸� 1�� ��ų ��ư�� ��Ȱ��ȭ
    }

    public void pardon() { //��ų ���� ���
        SkillPanelManagerEnemy.GetComponent<SkillPanelManagerEnemy>().buttons[num] = true; //���� 1�� ��ų�̸� 1�� ��ų ��ư�� Ȱ��ȭ
    }
}
