using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetControl : MonoBehaviour
{
    public GameObject parent;
    public int tmp_score = 0;
    public float multiplier = 1;//과녁 확대/축소 수치 표시
    public Vector3 centerPosition;

    public bool moving = false;
    float speed;
    float range;

    public AudioSource yellSnd; //고득점 함성 효과음

    public scoreBonus scoreBonus; //스킬 스크립트6 (스킬 보너스)
    public scoreBonusEnemy scoreBonusEnemy; //스킬 스크립트6 (스킬 보너스)
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.01f;
        range = 0.007f;
        yellSnd = GameObject.Find("yellSnd").GetComponent<AudioSource>();

        scoreBonus = GameObject.Find("scoreBonus").GetComponent<scoreBonus>();
        scoreBonusEnemy = GameObject.Find("scoreBonusEnemy").GetComponent<scoreBonusEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            float newX = parent.transform.position.x + Mathf.PingPong(Time.time * speed, range * 2) - range;
            parent.transform.position = new Vector3(newX, parent.transform.position.y, parent.transform.position.z);
        }
        centerPosition = this.transform.position;
    }


    public int CalculateScore(float d)
    {// 거리에 따라 점수를 계산하는 함수
        float distance = d/multiplier;
        // 거리에 따른 점수 계산, 중심과 가까울수록 높은 점수
        if (distance <= 0.11f)
        {
            if (scoreBonus.skill == true) { yellSnd.Play(); scoreBonus.skill = false; return (10 * 2); }
            else if (scoreBonusEnemy.skill == true) { yellSnd.Play(); scoreBonusEnemy.skill = false; return (10 * 2); }
            else { yellSnd.Play(); return 10; }
        }
        else if (distance <= 0.21f)
        {
            if (scoreBonus.skill == true) { yellSnd.Play(); scoreBonus.skill = false; return (9 * 2); }
            else if (scoreBonusEnemy.skill == true) { yellSnd.Play(); scoreBonusEnemy.skill = false; return (9 * 2); }
            else { yellSnd.Play(); return 9; }
        }
        else if (distance <= 0.31f)
        {
            if (scoreBonus.skill == true) { yellSnd.Play(); scoreBonus.skill = false; return (8 * 2); }
            else if (scoreBonusEnemy.skill == true) { yellSnd.Play(); scoreBonusEnemy.skill = false; return (8 * 2); }
            else { yellSnd.Play(); return 8; }
        }
        else if (distance <= 0.4f)
        {
            if (scoreBonus.skill == true) { scoreBonus.skill = false; return (7 * 2); }
            else if (scoreBonusEnemy.skill == true) { scoreBonusEnemy.skill = false; return (7 * 2); }
            else { return 7; }
        }
        else if (distance <= 0.5f)
        {
            if (scoreBonus.skill == true) { scoreBonus.skill = false; return (6 * 2); }
            else if (scoreBonusEnemy.skill == true) { scoreBonusEnemy.skill = false; return (6 * 2); }
            else { return 6; }
        }
        else if (distance <= 0.59f)
        {
            if (scoreBonus.skill == true) { scoreBonus.skill = false; return (5 * 2); }
            else if (scoreBonusEnemy.skill == true) { scoreBonusEnemy.skill = false; return (5 * 2); }
            else { return 5; }
        }
        else if (distance <= 0.69f)
        {
            if (scoreBonus.skill == true) { scoreBonus.skill = false; return (4 * 2); }
            else if (scoreBonusEnemy.skill == true) { scoreBonusEnemy.skill = false; return (4 * 2); }
            else { return 4; }
        }
        else if (distance <= 0.78f)
        {
            if (scoreBonus.skill == true) { scoreBonus.skill = false; return (3 * 2); }
            else if (scoreBonusEnemy.skill == true) { scoreBonusEnemy.skill = false; return (3 * 2); }
            else { return 3; }
        }
        else if (distance <= 0.88f)
        {
            if (scoreBonus.skill == true) { scoreBonus.skill = false; return (2 * 2); }
            else if (scoreBonusEnemy.skill == true) { scoreBonusEnemy.skill = false; return (2 * 2); }
            else { return 2; }
        }
        else if (distance <= 0.98f)
        {
            if (scoreBonus.skill == true) { scoreBonus.skill = false; return (1 * 2); }
            else if (scoreBonusEnemy.skill == true) { scoreBonusEnemy.skill = false; return (1 * 2); }
            else { return 1; }
        }
        else
        {
            if (scoreBonus.skill == true) { scoreBonus.skill = false; return 0; }
            else if (scoreBonusEnemy.skill == true) { scoreBonusEnemy.skill = false; return 0; }
            else { return 0; }
        }

    }

    //과녁 크기 변경(확대 or 축소)
    public void changeSize(float multiPlier)
    {
        multiplier = multiPlier;
        parent.transform.localScale = new Vector3(multiPlier, multiPlier, 1);
    }
}