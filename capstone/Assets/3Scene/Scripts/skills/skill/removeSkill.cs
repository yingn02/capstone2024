using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeSkill : MonoBehaviour
{
    public GameObject SkillPanelManager; //��ų �г� ��ũ��Ʈ
    public GameObject changeWind; //changeWind ��ũ��Ʈ
    public GameObject smallTargetEnemy; //��ų ��ũ��Ʈ1 (���� ũ�� ����)
    public GameObject movingTargetEnemy; //��ų ��ũ��Ʈ3 (���� �����̱�)
    public GameObject transparentEnemy; //��ų ��ũ��Ʈ9 (���� ȭ��� ����)
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
        Debug.Log("��ų ��ȿȭ");
        typhoonBan(); //������ ��� '��ǳ' ��ȿȭ
        smallTargetBan(); //������ ��� '���� ũ�� ����' ��ȿȭ
        movingTargetBan(); //������ ��� '���� �����̱�' ��ȿȭ
        transparentBan(); //������ ��� '���� ȭ��� ����' ��ȿȭ
        skill = false;
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

    ////////////////////////////////////////////////��ų ��ȿȭ////////////////////////////////////////////////

    public void typhoonBan() {
        changeWind.GetComponent<changeWind>().isTyphoonEnemy = false;
        changeWind.GetComponent<changeWind>().isChangeEnemy = true;
    }

    public void smallTargetBan() {
        if (smallTargetEnemy.GetComponent<smallTargetEnemy>().skill == true) { //������ ��� ���¶��
            smallTargetEnemy.GetComponent<smallTargetEnemy>().disable();

            smallTargetEnemy.GetComponent<smallTargetEnemy>().skill = false;
        }
    }

    public void movingTargetBan() {
        if (movingTargetEnemy.GetComponent<movingTargetEnemy>().skill == true) { //������ �����̴� ���¶��
            movingTargetEnemy.GetComponent<movingTargetEnemy>().disable();

            movingTargetEnemy.GetComponent<movingTargetEnemy>().skill = false;
        }
    }

    public void transparentBan() {
        if (transparentEnemy.GetComponent<transparentEnemy>().skill == true) { //����ȭ ���¶��
            transparentEnemy.GetComponent<transparentEnemy>().disable();

            transparentEnemy.GetComponent<transparentEnemy>().skill = false;
        }
    }
}
