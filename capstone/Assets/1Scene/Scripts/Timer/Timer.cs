using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //bool timerActive = false;
    //public Text currentTimeText;

    float currentTime; //���� Ÿ�̸�
    float seeTime; //����ڿ��� ���̴� Ÿ�̸�, ȭ���� ���� �����ð� ������, �����ص� ��ȿ�� �Ǵ� ������ ��ġ�� ���ؼ� �ʿ���
    public float startMinutes;
    public TextMeshPro currentTimeText;
    public bool timer = false; //Ÿ�̸� ����

    public GameManager gameManager; //GameManager ��ũ��Ʈ, �÷��̾��� ���� �����ϱ� ����
    AudioSource timerSnd; // Ÿ�̸� �ӹ� ȿ����
    private bool alarmTriggered = false; // 5�� �˶��� �︮�� �ִ°�

    private void Start()
    {
        timerSnd = GameObject.Find("timerSnd").GetComponent<AudioSource>();
        currentTime = startMinutes;
        seeTime = startMinutes - 3.0f;
    }

    void Update()
    {
        /*if (timerActive == true)
        {
            currentTime = currentTime - Time.deltaTime;
        }*/

        if (gameManager.playerTurn == true && timer == false) { //�÷��̾��� ���̸�, Ÿ�̸Ӱ� ���� ������ Ų��
            timer = true; //Ÿ�̸� ���� �ѱ�
            currentTime = startMinutes;
            seeTime = startMinutes - 3.0f;
            alarmTriggered = false;
        }

        if (gameManager.playerTurn == false) { //�÷��̾��� ���� ��������, ������ Ÿ�̸Ӹ� ����
            timer = false; //Ÿ�̸� ���� ����
            timerSnd.Stop();
            //
        }

        ///////////////////////////////////////////currentTime///////////////////////////////////////////

        if (currentTime > 0 && timer == true) //Ÿ�̸� ������ ���� ���� ���� ������
        {
            currentTime = currentTime - Time.deltaTime;

            if (currentTime <= 0)
            {
                timer = false; //Ÿ�̸� ���� ����
                gameManager.Invoke("calculateScore", 0.0f); //��ȿ ó�� (0��)
                currentTime = 0;
            }

            //currentTimeText.text = currentTime.ToString("n2");
        }

        /*public void StartTimer()
        {
            timerActive = true;
        }

        public void StopTimer()
        {
            timerActive = false;
        }*/

        /////////////////////////////////////////////seeTime/////////////////////////////////////////////

        if (seeTime > 0 && timer == true) //Ÿ�̸� ������ ���� ���� ���� ������
        {
            seeTime = seeTime - Time.deltaTime;

            if (seeTime <= 5.0f && !alarmTriggered) // 5�� ���Ϸ� ��������, �˶��� ���� �︮�� �ʾҴٸ�
            {
                timerSnd.Play(); // �˶� �Ҹ� ���
                alarmTriggered = true;
            }

            if (seeTime <= 0)
            {   
                seeTime = 0;
            }

            currentTimeText.text = seeTime.ToString("n2");
        }
    }
    

}
