using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using static System.Net.WebRequestMethods;
using static UnityEditor.Experimental.GraphView.GraphView;

public class arrowControl : MonoBehaviour
{
    private float speed = 7000f;
    public int score = 0;

    public changeWind ChangeWind; //풍향 스크립트
    AudioSource arrowSnd; // 화살 발사 효과음
    AudioSource yellSnd; //고득점 함성 효과음
    public bool player = true; //플레이어의 화살인지 여부, bowControl에서 가져와 grabPoint에서 수정됨

    public scoreBonus scoreBonus; //스킬 스크립트6 (스킬 보너스)
    public scoreBonusEnemy scoreBonusEnemy; //스킬 스크립트6 (스킬 보너스)

    public bigArrow bigArrow;
    public bigArrowEnemy bigArrowEnemy;

    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Arrow"), LayerMask.NameToLayer("Arrow"));

        ChangeWind = GameObject.Find("changeWind").GetComponent<changeWind>();
        arrowSnd = GameObject.Find("arrowSnd").GetComponent<AudioSource>();
        yellSnd = GameObject.Find("yellSnd").GetComponent<AudioSource>();

        scoreBonus = GameObject.Find("scoreBonus").GetComponent<scoreBonus>();
        scoreBonusEnemy = GameObject.Find("scoreBonusEnemy").GetComponent<scoreBonusEnemy>();

        bigArrow = GameObject.Find("bigArrow").GetComponent<bigArrow>();
        bigArrowEnemy = GameObject.Find("bigArrowEnemy").GetComponent<bigArrowEnemy>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void fire(float diff, Vector3 dir)
    {
        arrowSnd.Play();
        Debug.Log("shoot");
        GetComponent<Rigidbody>().AddForce(ChangeWind.windVector * 100.0f, ForceMode.Force); //화살이 풍향의 영향을 받음
        GetComponent<Rigidbody>().AddForce(dir * speed * diff, ForceMode.Force); //화살이 나아가는 힘
        GetComponent<Rigidbody>().useGravity = true;
    }
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.tag == "Target" && player)
        {
            targetControl targetcontrol = collision.gameObject.GetComponent<targetControl>();

            float final_distance = 0.99f;

            if (bigArrow.skill)
            {
                for (int i = 0; i <= collision.contacts.Length - 1; i++)
                {
                    //화살이 접촉한 지점의 위치를 가져오기
                    Vector3 contactPoints = collision.contacts[i].point;

                    // 과녁 중심과 접촉 지점 사이의 거리를 계산하여 점수를 업데이트
                    float distance = Vector3.Distance(contactPoints, targetcontrol.centerPosition);

                    if (final_distance > distance)
                        final_distance = distance;
                }
            }

            else
            {
                //화살이 접촉한 지점의 위치를 가져오기
                Vector3 contactPoint = collision.contacts[0].point;

                // 과녁 중심과 접촉 지점 사이의 거리를 계산하여 점수를 업데이트
                final_distance = Vector3.Distance(contactPoint, targetcontrol.centerPosition);
            }

            //점수 계산
            score += targetcontrol.CalculateScore(final_distance);
        }
        else if (collision.gameObject.tag == "EnemyTarget" && !player)
        {
            targetControl targetcontrol = collision.gameObject.GetComponent<targetControl>();

            float final_distance = 0.99f;

            if (bigArrowEnemy.skill)
            {
                for (int i = 0; i <= collision.contacts.Length - 1; i++)
                {
                    //화살이 접촉한 지점의 위치를 가져오기
                    Vector3 contactPoints = collision.contacts[i].point;

                    // 과녁 중심과 접촉 지점 사이의 거리를 계산하여 점수를 업데이트
                    float distance = Vector3.Distance(contactPoints, targetcontrol.centerPosition);

                    if (final_distance > distance)
                        final_distance = distance;
                }
            }

            else
            {
                //화살이 접촉한 지점의 위치를 가져오기
                Vector3 contactPoint = collision.contacts[0].point;

                // 과녁 중심과 접촉 지점 사이의 거리를 계산하여 점수를 업데이트
                final_distance = Vector3.Distance(contactPoint, targetcontrol.centerPosition);
            }

            //점수 계산
            score += targetcontrol.CalculateScore(final_distance);
        }

        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.freezeRotation = true;
        this.transform.parent = null;
    }




}