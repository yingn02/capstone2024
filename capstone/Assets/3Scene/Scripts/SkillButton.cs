using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class SkillButton : MonoBehaviour
{
    public GameObject skillPanel;
    public GameObject SkillManager; //��ų �ߵ� ��ũ��Ʈ

    public void OnButtonClick()
    {
        if (skillPanel != null)
        {
            skillPanel.SetActive(!skillPanel.activeSelf);
        }
    }

    public void OnSelectClick() { //��ų ��� ��ư(����)�� ������ ��
        SkillManager.GetComponent<SkillManager>().skillOn(); //��ų ��� ��ư�� �������� Ȯ��
    }
}

