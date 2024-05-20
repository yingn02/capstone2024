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
    

    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Arrow"), LayerMask.NameToLayer("Arrow"));
        ChangeWind = GameObject.Find("changeWind").GetComponent<changeWind>();
        arrowSnd = GameObject.Find("arrowSnd").GetComponent<AudioSource>();
        
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
        if (collision.gameObject.tag == "Target")
        {
            score = 0;
            targetControl targetcontrol = collision.gameObject.GetComponent<targetControl>();

            //화살이 접촉한 지점의 위치를 가져오기
            Vector3 contactPoint = collision.contacts[0].point;
            Debug.Log(contactPoint);

            // 과녁 중심과 접촉 지점 사이의 거리를 계산하여 점수를 업데이트
            float distance = Vector3.Distance(contactPoint, targetcontrol.centerPosition);
            Debug.Log(distance);
            //점수 계산
            score += targetcontrol.CalculateScore(distance);
        }

        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.freezeRotation = true;
        this.transform.parent = null;
    }


    

}
