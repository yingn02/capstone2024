using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static Unity.Burst.Intrinsics.X86.Avx;

public class writeScore : MonoBehaviour
{
    public TextMeshProUGUI p1; //�÷��̾��� ����1 (1��)
    public TextMeshProUGUI p2; //�÷��̾��� ����2 (2��)
    public TextMeshProUGUI p3; //�÷��̾��� ����3 (3��)
    public TextMeshProUGUI e1; //������ ����1 (4��)
    public TextMeshProUGUI e2; //������ ����2 (5��)
    public TextMeshProUGUI e3; //������ ����3 (6��)

    public TextMeshProUGUI pTotal; //�÷��̾��� ���� �� ����
    public TextMeshProUGUI eTotal; //������ ���� �� ����

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void write_score(int turn, int score) { //�� ������
        if (turn == 1) {
            p1.text = ""; p2.text = ""; p3.text = ""; e1.text = ""; e2.text = ""; e3.text = ""; //������ �ʱ�ȭ
            p1.text = score.ToString();
        } 
        else if (turn == 2) e1.text = score.ToString();
        else if (turn == 3) p2.text = score.ToString();
        else if (turn == 4) e2.text = score.ToString();
        else if (turn == 5) p3.text = score.ToString();
        else if (turn == 6) e3.text = score.ToString();
    }

    public void write_total(int p_total, int e_total) { //�� ���� ������
        if(p_total > 0) pTotal.text = p_total.ToString();
        if (e_total > 0) eTotal.text = e_total.ToString();
    }

    public void write_turn(bool player) { //������ ������ �����ǿ� ǥ�����ش�
        //if (p_total > 0) pTotal.text = p_total.ToString();
        //if (e_total > 0) eTotal.text = e_total.ToString();
    }

}
