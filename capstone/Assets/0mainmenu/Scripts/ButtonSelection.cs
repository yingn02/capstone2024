using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonSelection : MonoBehaviour
{
    public Color selectedColor; // ���õ� ��ư�� ����
    private Color originalColor; // ������ ����

    private Button button; // ���� ��ư
    private bool isSelected = false; // ��ư�� ���õǾ����� ���θ� ��Ÿ���� �÷���
    private string buttonText; // ��ư�� �ؽ�Ʈ ���� ����

    private static List<string> selectedButtonTexts = new List<string>(); // ���õ� ��ư�� �ؽ�Ʈ ������ ������ ����Ʈ
    private const int maxSelectionCount = 3; // �ִ� ���� ������ ��ư�� ��

    void Start()
    {
        button = GetComponent<Button>(); // ���� ��ư ��������
        originalColor = button.colors.normalColor; // ������ ���� ����
        button.onClick.AddListener(OnClick); // Ŭ�� �̺�Ʈ�� �޼��� �߰�
        buttonText = GetComponentInChildren<Text>().text; // ��ư�� �ؽ�Ʈ ���� ��������
    }

    void OnClick()
    {
        if (isSelected)
        {
            // ��ư�� �̹� ���õǾ� ������ ������ ����ϰ� ������ �������� ����
            isSelected = false;
            ColorBlock colors = button.colors;
            colors.normalColor = originalColor; // ������ �������� ����
            button.colors = colors;
            selectedButtonTexts.Remove(buttonText); // ���õ� ��ư ����Ʈ���� ����
        }
        else
        {
            // �ִ� ���� ������ ���� �̳��̰�, ��ư�� ���õǾ� ���� ������ ���� ���·� �����ϰ� ���� ����
            if (selectedButtonTexts.Count < maxSelectionCount)
            {
                isSelected = true;
                ColorBlock colors = button.colors;
                colors.normalColor = selectedColor; // ���õ� �������� ����
                button.colors = colors;
                selectedButtonTexts.Add(buttonText); // ���õ� ��ư ����Ʈ�� �߰�
            }
        }
    }


    public static List<string> GetSelectedButtonTexts()
    {
        // ���õ� ��ư�� �ؽ�Ʈ ������ ��ȯ
        return selectedButtonTexts;
    }
}
