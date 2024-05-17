using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float currentTime; //실제 타이머
    float seeTime; //사용자에게 보이는 타이머, 화살의 점수 판정시간 때문에, 명중해도 무효가 되는 문제를 고치기 위해서 필요함
    public float startMinutes;
    public TextMeshPro currentTimeText;
    public bool timer = false; //타이머 전원

    public GameManager gameManager; //GameManager 스크립트, 플레이어의 턴을 감지하기 위함
    AudioSource timerSnd; // 타이머 임박 효과음
    private bool alarmTriggered = false; // 5초 알람이 울리고 있는가

    private bool endFreezing = false;

    private void Start()
    {
        timerSnd = GameObject.Find("timerSnd").GetComponent<AudioSource>();
        currentTime = startMinutes;
        seeTime = startMinutes - 3.0f;
    }

    void Update()
    {

        if (!gameManager.practice && endFreezing)
        {
            if (gameManager.playerTurn == true && timer == false)
            { //플레이어의 턴이면, 타이머가 꺼져 있으면 킨다
                timer = true; //타이머 전원 켜기
                currentTime = startMinutes;
                seeTime = startMinutes - 3.0f;
                alarmTriggered = false;
            }

            if (gameManager.playerTurn == false)
            { //플레이어의 턴이 지나가면, 무조건 타이머를 끈다
                timer = false; //타이머 전원 끄기
                timerSnd.Stop();
                //
            }
        }

        

        ///////////////////////////////////////////currentTime///////////////////////////////////////////

        if (currentTime > 0 && timer == true) //타이머 전원이 켜져 있을 때만 동작함
        {
            currentTime = currentTime - Time.deltaTime;

            if (currentTime <= 0)
            {
                timer = false; //타이머 전원 끄기
                gameManager.timeOut(); // 플레이어에게서 화살을 빼앗음
                gameManager.Invoke("calculateScore", 0.2f); //무효 처리 (0점)
                currentTime = 0;
            }

        }

        /////////////////////////////////////////////seeTime/////////////////////////////////////////////

        if (seeTime > 0 && timer == true) //타이머 전원이 켜져 있을 때만 동작함
        {
            seeTime = seeTime - Time.deltaTime;

            if (seeTime <= 5.0f && !alarmTriggered) // 5초 이하로 내려갔고, 알람이 아직 울리지 않았다면
            {
                timerSnd.Play(); // 알람 소리 재생
                alarmTriggered = true;
            }

            if (seeTime <= 0)
            {
                seeTime = 0;
            }

            currentTimeText.text = seeTime.ToString("n2");
        }
    }
    public void end_freezing() { //타이머를 잠시 멈추게함 (ex. 튜토리얼)
        endFreezing = true;
    }

}