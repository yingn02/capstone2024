using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class SkillPanelManager : MonoBehaviour
{
    public TMP_Text skillText;
    public Button buttonA; //��ų1 ��ư
    public Button buttonB;
    public Button buttonC;

    public int selected = 1; //���° ��ų�� ���õǾ��°� (��ų���� ��Ÿ���� �ٸ��Ƿ�, SkillManager ��ũ��Ʈ���� ����� ���� �ʿ�)

    private List<string> skillList = new List<string>(); //��ų�ؽ�Ʈ ����Ȱ ����Ʈ

    void Start()
    {
        // ButtonSelection���� ���õ� ��ų �ؽ�Ʈ �ٽ� skillList�� ����
        skillList = ButtonSelection.GetSelectedButtonTexts();

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
}


