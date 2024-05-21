using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Debug = UnityEngine.Debug;
using TMPro;
using UnityEngine;

public class changeWind : MonoBehaviour
{
    public GameObject ArrowControl; //ȭ�� ������ ��ũ��Ʈ

    public GameObject windDirection; //ǳ�� ǥ��
    public Vector3 windVector; // �ٶ��� �� ���͸� arrowControl ��ũ��Ʈ�� ������ ����
    public Vector3 imgWindVector; //�ٶ��� �� ���͸� �����ͼ� UI�� ǥ���� ����
    public float changeTime = 3.0f; //ǳ���� 3�ʸ��� ��ȭ
    public float changePassTime = 0.0f; //���� �������� ���� ����

    public bool isRemove = false; //ǳ���� �����ϰڴ°� (removeWind ��ũ��Ʈ���� ����)
    public bool isTyphoon = false; //ǳ���� ������ 2��� ������Ű�ڴ°� (typhoon ��ũ��Ʈ���� ����)
    public bool isRemoveEnemy = false; //ǳ���� �����ϰڴ°� (removeWindEnemy ��ũ��Ʈ���� ����)
    public bool isTyphoonEnemy = false; //ǳ���� ������ 2��� ������Ű�ڴ°� (typhoonEnemy ��ũ��Ʈ���� ����)
    public bool isChange = false; //ǳ���� ��� ������Ʈ�϶� (��ų ������ �ʿ�)
    public bool isChangeEnemy = false; //ǳ���� ��� ������Ʈ�϶� (��ų ������ �ʿ�)

    private float x; // ���� �Ǵ� ������ �ٶ�
    private float y; // �� �Ǵ� �Ʒ� �ٶ��� ��������
    private float z; // �� �Ǵ� �� �ٶ�, �� ���� �̹� arrowControl ��ũ��Ʈ�� diff���� �����ϹǷ� ��������

    // Start is called before the first frame update
    void Start()
    {
        view_wind(); // ������ ǳ�� ǥ��
    }

    // Update is called once per frame
    void Update()
    {
        if (isChange) {
            view_wind();
            isChange = false;
        }

        if (isChangeEnemy)
        {
            view_wind();
            isChangeEnemy = false;
        }

        if (changePassTime >= changeTime) { //ǳ���� �ٲ��� 3�ʰ� ������
            view_wind();//ǳ���� �缳���ϰ� UI�� ������Ʈ
            changePassTime = 0.0f;
        }
        else { 
            changePassTime += Time.deltaTime;
        }

        Debug.Log("���� ǳ�� ���� - " + "x" + x + "/" + "y" + y + "/" + "z" + z + "/");
    }

    public void view_wind() { //ǳ���� �缳���ϰ� UI�� ������Ʈ
        // ǳ���� �������� ����
        windVector = random_wind(); 
        imgWindVector = windVector;

        //z���� �ٶ��� �����Ͽ�����, �̹��� �����δ� ǥ���� �ʿ䰡 �ִ�. �������� ǥ���� ����
        if (Random.Range(-1.0f, 1.0f) < 0) {
            imgWindVector.z *= -1.0f;
        } 

        // x�� z ������Ʈ�� ����Ͽ� ��� ���� ���
        float angle = Mathf.Atan2(imgWindVector.z, imgWindVector.x) * Mathf.Rad2Deg;

        //ȭ��ǥ �̹��� ȸ��
        windDirection.transform.rotation = Quaternion.Euler(-45, -30+180, 90-angle);
    }

    public Vector3 random_wind() { //ǳ���� �������� �����ϰ� ���͸� ��ȯ
        x = Random.Range(-1.0f, 1.0f); // ���� �Ǵ� ������ �ٶ�
        y = Random.Range(0.0f, 0.0f); // �� �Ǵ� �Ʒ� �ٶ��� ��������
        z = Random.Range(0.3f, 0.3f); // �� �Ǵ� �� �ٶ�, �� ���� �̹� arrowControl ��ũ��Ʈ�� diff���� �����ϹǷ� ��������

        //�ٶ� ���� ���� (ǳ�� ���� ��ų)
        if (isRemove) { x *= 0; y *= 0; z *= 0; }
        else if(isTyphoon) { x *= 2; y *= 2; z *= 2; }

        if (isRemoveEnemy) { x *= 0; y *= 0; z *= 0; }
        else if (isTyphoonEnemy) { x *= 2; y *= 2; z *= 2; }

        Vector3 newWind = new Vector3(x, y, z);

        return newWind;
    }

}
