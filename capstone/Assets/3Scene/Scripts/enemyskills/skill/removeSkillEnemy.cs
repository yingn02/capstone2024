using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeSkillEnemy : MonoBehaviour
{
    public GameObject SkillPanelManagerEnemy; //��ų �г� ��ũ��Ʈ
    public GameObject changeWind; //changeWind ��ũ��Ʈ
    public GameObject smallTarget; //��ų ��ũ��Ʈ1 (���� ũ�� ����)
    public GameObject movingTarget; //��ų ��ũ��Ʈ3 (���� �����̱�)
    public GameObject transparent; //��ų ��ũ��Ʈ9 (���� ȭ��� ����)
    public targetControl target;

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
        skill = true;
        Debug.Log("��ų ��ȿȭE");
        typhoonBan(); //�÷��̾ ��� '��ǳ' ��ȿȭ
        smallTargetBan(); //�÷��̾ ��� '���� ũ�� ����' ��ȿȭ
        movingTargetBan(); //�÷��̾ ��� '���� �����̱�' ��ȿȭ
        transparentBan(); //�÷��̾ ��� '���� ȭ��� ����' ��ȿȭ
        skill = false;
    }

    public void setCool(int selected, int cool_time) { //��Ÿ�� ����
        cool = cool_time; //��Ÿ�� (�÷��̾��� ���� ���Խ�Ų ��, �׻� Ȧ���� ��)
        num = selected;
    }

    public void ban() { //��ų ���� �����
        SkillPanelManagerEnemy.GetComponent<SkillPanelManagerEnemy>().buttons[num] = false; //���� 1�� ��ų�̸� 1�� ��ų ��ư�� ��Ȱ��ȭ
    }

    public void pardon() { //��ų ���� ���
        SkillPanelManagerEnemy.GetComponent<SkillPanelManagerEnemy>().buttons[num] = true; //���� 1�� ��ų�̸� 1�� ��ų ��ư�� Ȱ��ȭ
    }

    ////////////////////////////////////////////////��ų ��ȿȭ////////////////////////////////////////////////
    
    public void typhoonBan() {
        changeWind.GetComponent<changeWind>().isTyphoon = false;
        changeWind.GetComponent<changeWind>().isChange = true;
    }

    public void smallTargetBan() {
        if (smallTarget.GetComponent<smallTarget>().skill == true) { //������ ��� ���¶��
            smallTarget.GetComponent<smallTarget>().disable();

            smallTarget.GetComponent<smallTarget>().skill = false;
        }
    }

    public void movingTargetBan() {
        if (movingTarget.GetComponent<movingTarget>().skill == true) { //������ �����̴� ���¶��
            movingTarget.GetComponent<movingTarget>().disable();

            movingTarget.GetComponent<movingTarget>().skill = false;
        }
    }

    public void transparentBan() {
        if (transparent.GetComponent<transparent>().skill == true) { //����ȭ ���¶��
            transparent.GetComponent<transparent>().disable();

            transparent.GetComponent<transparent>().skill = false;
        }
    }
}
