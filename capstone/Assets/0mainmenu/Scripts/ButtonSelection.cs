using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ButtonSelection : MonoBehaviour
{
    public Color selectedColor; // ���õ��� �� ��
    public Color originalColor; // ���� ��

    private Button button; // ���� ��ư
    private bool isSelected = false;
    private string buttonText; // ��ư�� �ؽ�Ʈ ���� ����

    private static List<string> selectedButtonTexts = new List<string>(); // ���õ� ��ư�� �ؽ�Ʈ�� ������ ����Ʈ
    private const int maxSelectionCount = 3; // �ִ� ���� ������ ��ư�� ��

    public bool refresh = false;

    void Start()
    {
        button = GetComponent<Button>(); 
        originalColor = button.colors.normalColor; //���� ���� ����
        button.onClick.AddListener(OnClick); 
        buttonText = GetComponentInChildren<TMP_Text>().text; //��ư ���� ��������
    }

    void Update()
    {
        if (refresh) {
            selectedButtonTexts = new List<string>();

            button = GetComponent<Button>();
            originalColor = button.colors.normalColor;
            button.onClick.AddListener(OnClick);
            buttonText = GetComponentInChildren<TMP_Text>().text;

            refresh = false;
        }
    }

    void OnClick()
    {
        if (isSelected)
        {
            //�̹� ���õǾ� ������ ���� ���, ����������
            isSelected = false;
            ColorBlock colors = button.colors;
            colors.normalColor = originalColor; // ������ �������� ����
            button.colors = colors;
            selectedButtonTexts.Remove(buttonText); // ���õ� ��ư ����Ʈ���� ����
        }
        else
        {
            if (selectedButtonTexts.Count < maxSelectionCount)
            {
                isSelected = true;
                ColorBlock colors = button.colors;
                colors.normalColor = selectedColor; //���󺯰�
                button.colors = colors;
                selectedButtonTexts.Add(buttonText); //����Ʈ�� �߰�
            }
        }
    }


    public static List<string> GetSelectedButtonTexts()
    {
        //���õ� ��ư�� ������ ��ȯ
        return selectedButtonTexts;
    }
}
