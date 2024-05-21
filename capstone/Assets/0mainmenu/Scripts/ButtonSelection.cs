using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ButtonSelection : MonoBehaviour
{
    public Color selectedColor; // 선택됐을 때 색
    public Color originalColor; // 원래 색

    private Button button; // 현재 버튼
    private bool isSelected = false;
    private string buttonText; // 버튼의 텍스트 내용 저장

    private static List<string> selectedButtonTexts = new List<string>(); // 선택된 버튼의 텍스트를 저장할 리스트
    private const int maxSelectionCount = 3; // 최대 선택 가능한 버튼의 수

    public bool refresh = false;

    void Start()
    {
        button = GetComponent<Button>(); 
        originalColor = button.colors.normalColor; //지금 배경색 저장
        button.onClick.AddListener(OnClick); 
        buttonText = GetComponentInChildren<TMP_Text>().text; //버튼 내용 가져오기
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
            //이미 선택되어 있으면 선택 취소, 원래색으로
            isSelected = false;
            ColorBlock colors = button.colors;
            colors.normalColor = originalColor; // 원래의 배경색으로 변경
            button.colors = colors;
            selectedButtonTexts.Remove(buttonText); // 선택된 버튼 리스트에서 제거
        }
        else
        {
            if (selectedButtonTexts.Count < maxSelectionCount)
            {
                isSelected = true;
                ColorBlock colors = button.colors;
                colors.normalColor = selectedColor; //색상변경
                button.colors = colors;
                selectedButtonTexts.Add(buttonText); //리스트에 추가
            }
        }
    }


    public static List<string> GetSelectedButtonTexts()
    {
        //선택된 버튼의 내용을 반환
        return selectedButtonTexts;
    }
}
