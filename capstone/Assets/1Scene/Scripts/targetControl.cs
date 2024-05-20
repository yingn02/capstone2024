using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class targetControl : MonoBehaviour
{
    public GameObject parent;
    public float multiplier = 1;//과녁 확대/축소 수치 표시
    public Vector3 centerPosition;
    public bool moving = false;
    float speed;
    float range;

    AudioSource yellSnd; //고득점 함성 효과음


    // Start is called before the first frame update
    void Start()
    {
        yellSnd = GameObject.Find("yellSnd").GetComponent<AudioSource>();
        speed = 0.01f;
        range = 0.007f;
    }

    // Update is called once per frame
    void Update()
    {
        if(moving)
        {
            float newX = parent.transform.position.x + Mathf.PingPong(Time.time * speed, range * 2) - range;
            parent.transform.position = new Vector3(newX, parent.transform.position.y, parent.transform.position.z);
        }
        centerPosition = this.transform.position;
    }

    public int CalculateScore(float d)
    {// 거리에 따라 점수를 계산하는 메서드
        float distance = d / multiplier;
        // 거리에 따른 점수 계산, 중심과 가까울수록 높은 점수
        if (distance <= 0.11f) { yellSnd.Play(); return 10; }
        else if (distance <= 0.21f) { yellSnd.Play(); return 9; }
        else if (distance <= 0.31f) { yellSnd.Play(); return 8; }
        else if (distance <= 0.4f) return 7;
        else if (distance <= 0.5f) return 6;
        else if (distance <= 0.59f) return 5;
        else if (distance <= 0.69f) return 4;
        else if (distance <= 0.78f) return 3;
        else if (distance <= 0.88f) return 2;
        else if (distance <= 0.98f) return 1;
        else return 0;
    }

    //과녁 크기 변경(확대 or 축소)
    private void changeSize(int multiPlier)
    {
        multiplier = multiPlier;
        parent.transform.localScale = new Vector3(multiPlier, multiPlier, 1);
    }
}
