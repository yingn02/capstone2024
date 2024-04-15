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
            p1.text = ""; p2.text = ""; p3.text = ""; e1.text = ""; e2.text = ""; e3.text = ""; //점수판 초기화
            p1.text = score.ToString();
        } 
        else if (turn == 2) e1.text = score.ToString();
        else if (turn == 3) p2.text = score.ToString();
        else if (turn == 4) e2.text = score.ToString();
        else if (turn == 5) p3.text = score.ToString();
        else if (turn == 6) e3.text = score.ToString();
    }

    public void write_total(int p_total, int e_total) { //턴 총점 점수판
        if(p_total > 0) pTotal.text = p_total.ToString();
        if (e_total > 0) eTotal.text = e_total.ToString();
    }

    public void write_turn(bool player) { //누구의 턴인지 점수판에 표시해준다
        //if (p_total > 0) pTotal.text = p_total.ToString();
        //if (e_total > 0) eTotal.text = e_total.ToString();
    }

}
