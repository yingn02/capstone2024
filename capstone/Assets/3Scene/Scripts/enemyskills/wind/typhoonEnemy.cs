using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class typhoonEnemy : MonoBehaviour
{
    public GameManager gameManager; //GameManager ��ũ��Ʈ, �÷��̾��� ���� �����ϱ� ����
    public GameObject SkillPanelManagerEnemy; //��ų �г� ��ũ��Ʈ
    public GameObject changeWind; //ǳ�� ��ũ��Ʈ

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
        //���� ���ʰ� ���� �� �÷��̾��� 1�ϸ� ��ǳ ����, ���� ������ CoolManager ��ũ��Ʈ���� ����
        if (skill == true)
        {
            if (gameManager.playerTurn == true)
            {
                changeWind.GetComponent<changeWind>().isTyphoonEnemy = true;
                changeWind.GetComponent<changeWind>().isChangeEnemy = true;
                skill = false;
            }
        }
    }

    public void execute() { //��ų �ߵ�
        skill = true; 
        Debug.Log("��ǳE");
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
}
