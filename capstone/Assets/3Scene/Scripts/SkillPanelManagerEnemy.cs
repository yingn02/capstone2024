using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPanelManagerEnemy : MonoBehaviour
{

    public List<bool> buttons = new List<bool>(); //������ ��ų ��ư ����Ʈ, �÷��̾��� ��ų1 ��ư�� ����� ����

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            buttons[i] = true;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
