using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static Unity.Burst.Intrinsics.X86.Avx;

public class writeScore : MonoBehaviour
{
    public TextMeshProUGUI p1; //플레이어의 점수1 (1턴)
    public TextMeshProUGUI p2; //플레이어의 점수2 (2턴)
    public TextMeshProUGUI p3; //플레이어의 점수3 (3턴)
    public TextMeshProUGUI e1; //적팀의 점수1 (4턴)
    public TextMeshProUGUI e2; //적팀의 점수2 (5턴)
    public TextMeshProUGUI e3; //적팀의 점수3 (6턴)

    public TextMeshProUGUI pTotal; //플레이어의 현재 턴 총점
    public TextMeshProUGUI eTotal; //적팀의 현재 턴 총점

    public TextMeshProUGUI cSet; //현재 세트
    public TextMeshProUGUI pSetScore; //플레이어의 세트점수
    public TextMeshProUGUI eSetScore; //적팀의 세트점수

    public GameObject turnMark;//누구의 턴인지 가리키는 표시

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void write_score(int turn, int score) { //턴 점수판
        if (turn == 1) {
            clear_score(); //점수판 초기화
            p1.text = score.ToString();
        }
        else if (turn == 2) e1.text = score.ToString();
        else if (turn == 3) p2.text = score.ToString();
        else if (turn == 4) e2.text = score.ToString();
        else if (turn == 5) p3.text = score.ToString();
        else if (turn == 6) e3.text = score.ToString();

        view_score(true);
    }

    public void write_total(int p_total, int e_total, int turn) { //턴 총점 점수판
        if (p_total >= 0 && turn >= 1) pTotal.text = p_total.ToString();
        if (e_total >= 0 && turn >= 2) eTotal.text = e_total.ToString();
    }

    public void write_turn(bool player) { //누구의 턴인지 점수판에 표시해준다
        if (player) {
            RectTransform rectTransform = turnMark.GetComponent<RectTransform>();
            rectTransform.anchoredPosition3D = new Vector3(35f, 260f, -30f);
        }
        else {
            RectTransform rectTransform = turnMark.GetComponent<RectTransform>();
            rectTransform.anchoredPosition3D = new Vector3(35f, 203f, -30f);
        }
    }
    public void write_set(int set, int limit) { //새로운 세트가 시작되면 현재 세트가 몇번째 세트인지 표시한다
        cSet.text = "SET " + set.ToString();

        //마지막 세트 끝나면 마지막 세트 표시를 유지
        if (set > limit) {
            cSet.text = "SET " + limit;
        }

        //새로운 세트가 시작되면 6턴까지의 점수판을 보여주고 n초후 점수판 초기화 할 것임
        //이것을 하지않으면 6턴의 점수가 표시되자마자 바로 점수판이 초기화되어서, 6턴의 점수를 육안으로 확인 불가할 정도임
        StartCoroutine(WaitAndClearScores()); 
    }
    public void clear_score() { //세트와 세트점수를 제외한 점수를 초기화
        p1.text = ""; p2.text = ""; p3.text = ""; e1.text = ""; e2.text = ""; e3.text = ""; pTotal.text = ""; eTotal.text = ""; //점수판 초기화
    }

    public void view_score(bool answer) { //세트와 세트점수를 제외한 점수를 공개할까요?, 세트 변경 때 잠시 숨기기 위해 만든 함수
        p1.gameObject.SetActive(answer);
        p2.gameObject.SetActive(answer);
        p3.gameObject.SetActive(answer);
        e1.gameObject.SetActive(answer);
        e2.gameObject.SetActive(answer);
        e3.gameObject.SetActive(answer);
        pTotal.gameObject.SetActive(answer);
        eTotal.gameObject.SetActive(answer);
    }

    public IEnumerator WaitAndClearScores() {
        yield return new WaitForSeconds(2); //2초 대기
        view_score(false); //점수 숨기기
    }

    public void write_set_score(int p_set_score, int e_set_score) { //세트 점수 점수판, 새 스테이지일 때만 초기화 할 것
        pSetScore.text = p_set_score.ToString();
        eSetScore.text = e_set_score.ToString();
    }




}
