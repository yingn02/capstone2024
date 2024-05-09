using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonSelection : MonoBehaviour
{
    public Color selectedColor; // 선택된 버튼의 배경색
    private Color originalColor; // 원래의 배경색

    private Button button; // 현재 버튼
    private bool isSelected = false; // 버튼이 선택되었는지 여부를 나타내는 플래그
    private string buttonText; // 버튼의 텍스트 내용 저장

    private static List<string> selectedButtonTexts = new List<string>(); // 선택된 버튼의 텍스트 내용을 저장할 리스트
    private const int maxSelectionCount = 3; // 최대 선택 가능한 버튼의 수

    void Start()
    {
        button = GetComponent<Button>(); // 현재 버튼 가져오기
        originalColor = button.colors.normalColor; // 원래의 배경색 저장
        button.onClick.AddListener(OnClick); // 클릭 이벤트에 메서드 추가
        buttonText = GetComponentInChildren<Text>().text; // 버튼의 텍스트 내용 가져오기
    }

    void OnClick()
    {
        if (isSelected)
        {
            // 버튼이 이미 선택되어 있으면 선택을 취소하고 원래의 배경색으로 변경
            isSelected = false;
            ColorBlock colors = button.colors;
            colors.normalColor = originalColor; // 원래의 배경색으로 변경
            button.colors = colors;
            selectedButtonTexts.Remove(buttonText); // 선택된 버튼 리스트에서 제거
        }
        else
        {
            // 최대 선택 가능한 개수 이내이고, 버튼이 선택되어 있지 않으면 선택 상태로 변경하고 색상 변경
            if (selectedButtonTexts.Count < maxSelectionCount)
            {
                isSelected = true;
                ColorBlock colors = button.colors;
                colors.normalColor = selectedColor; // 선택된 색상으로 변경
                button.colors = colors;
                selectedButtonTexts.Add(buttonText); // 선택된 버튼 리스트에 추가
            }
        }
    }


    public static List<string> GetSelectedButtonTexts()
    {
        // 선택된 버튼의 텍스트 내용을 반환
        return selectedButtonTexts;
    }
}
