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

    public changeWind ChangeWind; //ǳ�� ��ũ��Ʈ

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
    public void fire(float diff)
    {
        Debug.Log("shoot");

        GetComponent<Rigidbody>().AddForce(ChangeWind.windVector * 100.0f, ForceMode.Force); //ȭ���� ǳ���� ������ ����
        GetComponent<Rigidbody>().AddForce(transform.right * speed * diff, ForceMode.Force); //ȭ���� ���ư��� ��
        GetComponent<Rigidbody>().useGravity = true;
    }
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.tag == "Target") {
            //ȭ���� ������ ������ ��ġ�� ��������
            Vector3 contactPoint = collision.contacts[0].point;

            // ���� �߽�
            Vector3 targetCenter = new Vector3(0.0f, 2.0f, 35.0f);

            // ���� �߽ɰ� ���� ���� ������ �Ÿ��� ����Ͽ� ������ ������Ʈ
            float distance = Vector3.Distance(contactPoint, targetCenter);

            //���� ���
            score = CalculateScore(distance);  
        }
        else if (collision.gameObject.tag == "EnemyTarget") {
            //ȭ���� ������ ������ ��ġ�� ��������
            Vector3 contactPoint = collision.contacts[0].point;

            // ���� �߽�
            Vector3 targetCenter = new Vector3(5.8f, 2.0f, 35.0f);

            // ���� �߽ɰ� ���� ���� ������ �Ÿ��� ����Ͽ� ������ ������Ʈ
            float distance = Vector3.Distance(contactPoint, targetCenter);

            //���� ���
            score = CalculateScore(distance);
        }

        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.freezeRotation = true;
        this.transform.parent = null;
    }

    
    private int CalculateScore(float distance) {// �Ÿ��� ���� ������ ����ϴ� �޼���
        // �Ÿ��� ���� ���� ���, �߽ɰ� �������� ���� ����
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
