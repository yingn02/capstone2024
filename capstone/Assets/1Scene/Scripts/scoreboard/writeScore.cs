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

    public TextMeshProUGUI cSet; //���� ��Ʈ
    public TextMeshProUGUI pSetScore; //�÷��̾��� ��Ʈ����
    public TextMeshProUGUI eSetScore; //������ ��Ʈ����

    public GameObject turnMark;//������ ������ ����Ű�� ǥ��

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
            clear_score(); //������ �ʱ�ȭ
            p1.text = score.ToString();
        }
        else if (turn == 2) e1.text = score.ToString();
        else if (turn == 3) p2.text = score.ToString();
        else if (turn == 4) e2.text = score.ToString();
        else if (turn == 5) p3.text = score.ToString();
        else if (turn == 6) e3.text = score.ToString();

        view_score(true);
    }

    public void write_total(int p_total, int e_total, int turn) { //�� ���� ������
        if (p_total >= 0 && turn >= 1) pTotal.text = p_total.ToString();
        if (e_total >= 0 && turn >= 2) eTotal.text = e_total.ToString();
    }

    public void write_turn(bool player) { //������ ������ �����ǿ� ǥ�����ش�
        if (player) {
            RectTransform rectTransform = turnMark.GetComponent<RectTransform>();
            rectTransform.anchoredPosition3D = new Vector3(35f, 260f, -30f);
        }
        else {
            RectTransform rectTransform = turnMark.GetComponent<RectTransform>();
            rectTransform.anchoredPosition3D = new Vector3(35f, 203f, -30f);
        }
    }
    public void write_set(int set, int limit) { //���ο� ��Ʈ�� ���۵Ǹ� ���� ��Ʈ�� ���° ��Ʈ���� ǥ���Ѵ�
        cSet.text = "SET " + set.ToString();

        //������ ��Ʈ ������ ������ ��Ʈ ǥ�ø� ����
        if (set > limit) {
            cSet.text = "SET " + limit;
        }

        //���ο� ��Ʈ�� ���۵Ǹ� 6�ϱ����� �������� �����ְ� n���� ������ �ʱ�ȭ �� ����
        //�̰��� ���������� 6���� ������ ǥ�õ��ڸ��� �ٷ� �������� �ʱ�ȭ�Ǿ, 6���� ������ �������� Ȯ�� �Ұ��� ������
        StartCoroutine(WaitAndClearScores()); 
    }
    public void clear_score() { //��Ʈ�� ��Ʈ������ ������ ������ �ʱ�ȭ
        p1.text = ""; p2.text = ""; p3.text = ""; e1.text = ""; e2.text = ""; e3.text = ""; pTotal.text = ""; eTotal.text = ""; //������ �ʱ�ȭ
    }

    public void view_score(bool answer) { //��Ʈ�� ��Ʈ������ ������ ������ �����ұ��?, ��Ʈ ���� �� ��� ����� ���� ���� �Լ�
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
        yield return new WaitForSeconds(2); //2�� ���
        view_score(false); //���� �����
    }

    public void write_set_score(int p_set_score, int e_set_score) { //��Ʈ ���� ������, �� ���������� ���� �ʱ�ȭ �� ��
        pSetScore.text = p_set_score.ToString();
        eSetScore.text = e_set_score.ToString();
    }




}
