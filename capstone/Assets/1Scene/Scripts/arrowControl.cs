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

    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Arrow"), LayerMask.NameToLayer("Arrow"));
        ChangeWind = GameObject.Find("changeWind").GetComponent<changeWind>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void fire(float diff, Vector3 dir)
    {
        Debug.Log("shoot");
        GetComponent<Rigidbody>().AddForce(ChangeWind.windVector * 100.0f, ForceMode.Force); //화살이 풍향의 영향을 받음
        GetComponent<Rigidbody>().AddForce(dir * speed * diff, ForceMode.Force); //화살이 나아가는 힘
        GetComponent<Rigidbody>().useGravity = true;
    }
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            //화살이 접촉한 지점의 위치를 가져오기
            Vector3 contactPoint = collision.contacts[0].point;

            // 과녁 중심
            Vector3 targetCenter = new Vector3(0.0f, 2.0f, 35.0f);

            // 과녁 중심과 접촉 지점 사이의 거리를 계산하여 점수를 업데이트
            float distance = Vector3.Distance(contactPoint, targetCenter);

            //점수 계산
            score = CalculateScore(distance);
        }
        else if (collision.gameObject.tag == "EnemyTarget")
        {
            //화살이 접촉한 지점의 위치를 가져오기
            Vector3 contactPoint = collision.contacts[0].point;

            // 과녁 중심
            Vector3 targetCenter = new Vector3(5.8f, 2.0f, 35.0f);

            // 과녁 중심과 접촉 지점 사이의 거리를 계산하여 점수를 업데이트
            float distance = Vector3.Distance(contactPoint, targetCenter);

            //점수 계산
            score = CalculateScore(distance);
        }

        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.freezeRotation = true;
        this.transform.parent = null;
    }


    private int CalculateScore(float distance)
    {// 거리에 따라 점수를 계산하는 메서드
        // 거리에 따른 점수 계산, 중심과 가까울수록 높은 점수
        if (distance <= 0.11f) return 10;
        else if (distance <= 0.21f) return 9;
        else if (distance <= 0.31f) return 8;
        else if (distance <= 0.4f) return 7;
        else if (distance <= 0.5f) return 6;
        else if (distance <= 0.59f) return 5;
        else if (distance <= 0.69f) return 4;
        else if (distance <= 0.78f) return 3;
        else if (distance <= 0.88f) return 2;
        else if (distance <= 0.98f) return 1;
        else return 0;
    }

}
