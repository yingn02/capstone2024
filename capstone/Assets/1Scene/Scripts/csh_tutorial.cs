using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class csh_tutorial : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    public int script;
    public GameObject next_button;
    public GameObject prev_button;
    public GameObject end_button;
    public GameObject tutorial_panel;
    public bool tutorial2 = false;
    public bool tutorial3 = false;
    public bool tutorial4 = false;
    public bool tutorial5 = false;
    public bool tutorial6 = false;
    public bool tutorial7 = false;
    public float img_time = 0.0f;
    public GameObject tutorial_img1;
    public GameObject tutorial_img2_1;
    public GameObject tutorial_img2_2;
    public GameObject tutorial_img3_1;
    public GameObject tutorial_img3_2;
    public GameObject tutorial_img4_1;
    public GameObject tutorial_img4_2;
    public GameObject tutorial_img5_1;
    public GameObject tutorial_img5_2;
    public GameObject tutorial_img6_1;
    public GameObject tutorial_img6_2;
    public GameObject tutorial_img7_1;
    public GameObject tutorial_img7_2;
    public GameObject tutorial_img8;
    public GameObject tutorial_img9;
    public GameObject tutorial_img10;
    public GameObject tutorial_img11;
    public GameObject tutorial_img12;
    public GameObject tutorial_img13;
    public GameObject tutorial_img14;

    // Start is called before the first frame update
    void Start() {
        viewButton(); //버튼 숨기고 보이기 관리
        viewImg(); //이미지 숨기고 보이기 관리
        tmp = GetComponent<TextMeshProUGUI>();
        script = 0;
        tmp.text = "양궁 체험장에 오신 것을 환영합니다!";
    }
    // Update is called once per frame
    void Update() {
        if (tutorial2) { tutorial_gif(tutorial_img2_1, tutorial_img2_2); }
        else if (tutorial3) { tutorial_gif(tutorial_img3_1, tutorial_img3_2); }
        else if (tutorial4) { tutorial_gif(tutorial_img4_1, tutorial_img4_2); }
        else if (tutorial5) { tutorial_gif(tutorial_img5_1, tutorial_img5_2); }
        else if (tutorial6) { tutorial_gif(tutorial_img6_1, tutorial_img6_2); }
        else if (tutorial7) { tutorial_gif(tutorial_img7_1, tutorial_img7_2); }
    }
    public void prevButton()
    {
        if (this.gameObject.activeSelf) { //'이전' 버튼 눌리면 
            script--;
            changeScript();//대사 바꾸기
            viewButton(); //버튼 숨기고 보이기 관리
            viewImg(); //이미지 숨기고 보이기 관리

        }
    }
    public void nextButton() {
        if (this.gameObject.activeSelf) { //'다음' 버튼 눌리면 
            script++;
            changeScript(); //대사 바꾸기
            viewButton(); //버튼 숨기고 보이기 관리
            viewImg(); //이미지 숨기고 보이기 관리
        }
    }
    public void endButton() {
        if (this.gameObject.activeSelf) { //'다음' 버튼 눌리면 
            tutorial_panel.SetActive(false); //대화창 닫기
        }
    }
    public void viewButton() {
        if (script <= 0) { prev_button.SetActive(false); next_button.SetActive(true); end_button.SetActive(false); } //맨 처음 대사가 나올 때
        else if (script > 0 && script < 25) { prev_button.SetActive(true); next_button.SetActive(true); end_button.SetActive(false); } // 중간 대사
        else if (script >= 25) { prev_button.SetActive(true); next_button.SetActive(false); end_button.SetActive(true); } //맨 마지막 대사가 나올 때
    }
    public void viewImg() {
        //이미지 숨기기 (기존 이미지 삭제)
        tutorial_img1.SetActive(false);
        tutorial2 = false; tutorial_img2_1.SetActive(false); tutorial_img2_2.SetActive(false);
        tutorial3 = false; tutorial_img3_1.SetActive(false); tutorial_img3_2.SetActive(false);
        tutorial4 = false; tutorial_img4_1.SetActive(false); tutorial_img4_2.SetActive(false);
        tutorial5 = false; tutorial_img5_1.SetActive(false); tutorial_img5_2.SetActive(false);
        tutorial6 = false; tutorial_img6_1.SetActive(false); tutorial_img6_2.SetActive(false);
        tutorial7 = false; tutorial_img7_1.SetActive(false); tutorial_img7_2.SetActive(false);
        tutorial_img8.SetActive(false);
        tutorial_img9.SetActive(false);
        tutorial_img10.SetActive(false);
        tutorial_img11.SetActive(false);
        tutorial_img12.SetActive(false);
        tutorial_img13.SetActive(false);
        tutorial_img14.SetActive(false);

        //이미지 보이기
        if (script == 3) { tutorial_img1.SetActive(true); }
        else if (script == 4) { tutorial_img1.SetActive(true); }
        else if (script == 5) { 
            tutorial2 = true; //gif 효과 
            tutorial_img2_1.SetActive(true);
        }
        else if (script == 6) {
            tutorial3 = true; //gif 효과 
            tutorial_img3_1.SetActive(true);
        }
        else if (script == 7) {
            tutorial4 = true; //gif 효과 
            tutorial_img4_1.SetActive(true);
        }
        else if (script == 8) {
            tutorial5 = true; //gif 효과 
            tutorial_img5_1.SetActive(true);
        }
        else if (script == 9) {
            tutorial6 = true; //gif 효과 
            tutorial_img6_1.SetActive(true);
        }
        else if (script == 10)
        {
            tutorial7 = true; //gif 효과 
            tutorial_img7_1.SetActive(true);
        }
        else if (script == 11) { tutorial_img8.SetActive(true); }
        else if (script == 12) { tutorial_img9.SetActive(true); }
        else if (script == 13) { tutorial_img10.SetActive(true); }
        else if (script == 14) { tutorial_img11.SetActive(true); }
        else if (script == 15) { tutorial_img12.SetActive(true); }
        else if (script == 16) { tutorial_img13.SetActive(true); }
        else if (script == 17) { tutorial_img13.SetActive(true); }
        else if (script == 18) { tutorial_img14.SetActive(true); }

    }
    public void tutorial_gif(GameObject tutorial_imgn_1, GameObject tutorial_imgn_2) {
        img_time += Time.deltaTime;
        if (img_time >= 0.5f) {
            tutorial_imgn_1.SetActive(!tutorial_imgn_1.activeSelf);
            tutorial_imgn_2.SetActive(!tutorial_imgn_2.activeSelf);
            img_time = 0.0f;
        }
    }
    public void setY1() { // 텍스트의 길이에 따라 높이가 변화하는 것을 방지
        Vector3 pos = tmp.rectTransform.anchoredPosition; //Label 위치
        pos.y = 60f; // y좌표
        tmp.rectTransform.anchoredPosition = pos; // 새 위치를 적용
    }
    public void setY2() { // 텍스트의 길이에 따라 높이가 변화하는 것을 방지
        Vector3 pos = tmp.rectTransform.anchoredPosition; //Label 위치
        pos.y = 41f; // y좌표
        tmp.rectTransform.anchoredPosition = pos; // 새 위치를 적용
    }
    public void changeScript() {
        if (script == 0) { setY1(); tmp.text = "양궁 체험장에 오신 것을 환영합니다!"; }
        else if (script == 1) { setY1(); tmp.text = "이곳은 스포츠 종목인 '양궁'을 체험할 수 있는 공간입니다."; }
        else if (script == 2) { setY1(); tmp.text = "먼저, 양궁의 규칙을 간단히 소개해드리겠습니다."; }
        else if (script == 3) { setY2(); tmp.text = "양궁이란, 활로 화살을 발사하여 일정 거리 이상 떨어진 과녁을 맞히는 스포츠입니다."; }
        else if (script == 4) { setY1(); tmp.text = "화살이 과녁의 정중앙에 가깝게 명중할수록, 높은 점수를 획득할 수 있습니다."; }
        else if (script == 5) { setY1(); tmp.text = "가운데에 위치한 노란색 구역은 10~9점,"; }
        else if (script == 6) { setY1(); tmp.text = "그 밖에 위치한 빨간색 구역은 8~7점,"; }
        else if (script == 7) { setY1(); tmp.text = "그 밖에 위치한 파란색 구역은 6~5점,"; }
        else if (script == 8) { setY1(); tmp.text = "그 밖에 위치한 검은색 구역은 4~3점,"; }
        else if (script == 9) { setY1(); tmp.text = "그 밖에 위치한 하얀색 구역은 2~1점,"; }
        else if (script == 10) { setY1(); tmp.text = "그 밖에 나머지 구역은 0점으로 처리됩니다."; }
        else if (script == 11) { setY1(); tmp.text = "양궁의 규칙은 '올림픽 라운드 개인전'을 기준으로 진행하도록 하겠습니다."; }
        else if (script == 12) { setY2(); tmp.text = "'올림픽 라운드 개인전'이란, 각 팀에서 1명씩 출전하여 3발씩 여러 세트를 쏘는 규칙입니다."; }
        else if (script == 13) { setY2(); tmp.text = "1인당 1발씩 번갈아가며 쏴서 총 3발씩 쏘면 한 세트가 끝난 것이고, 세트에서 승리하면 2점, 무승부는 1점, 패배는 0점을 획득합니다."; }
        else if (script == 14) { setY2(); tmp.text = "모든 세트가 끝난 후 세트 점수가 더 높은 팀이 승리합니다. 단, 승리에 필요한 최소 세트 점수는 6점 입니다."; }
        else if (script == 15) { setY1(); tmp.text = "모든 세트가 끝난 후에도 양 팀의 점수가 동점일 경우, 슛오프를 진행합니다."; }
        else if (script == 16) { setY2(); tmp.text = "슛오프란, 1인당 1발씩 번갈아가며 쏴서 점수가 더 높은 팀이 승리하는 세트입니다."; }
        else if (script == 17) { setY1(); tmp.text = "3발의 점수를 합산하지 않고 1발씩 승부하여 겨룹니다."; }
        else if (script == 18) { setY1(); tmp.text = "만약 슛오프의 점수도 동점일 경우, 과녁의 중심에 더 가깝게 쏜 팀이 승리합니다."; }
        else if (script == 19) { setY1(); tmp.text = "이것으로 양궁의 규칙을 간단히 알아보았습니다."; }
        else if (script == 20) { setY1(); tmp.text = "다음은 양궁의 발사 동작을 알아보도록 하겠습니다."; }
        else if (script == 21) { setY2(); tmp.text = "먼저, 양발이 과녁의 중심과 일직선이 되도록 서고, 양발의 간격은 어깨 너비 정도로 유지합니다."; }
        else if (script == 22) { setY1(); tmp.text = "그 다음 활에 화살을 끼우고, 화살의 깃이 위치한 활의 시위를 당깁니다."; }
        else if (script == 23) { setY2(); tmp.text = "활 시위를 당기는 손을 턱이나 볼쪽에 댄 상태로 과녁에 조준한 후, 손을 놓아 발사합니다."; }
        else if (script == 24) { setY1(); tmp.text = "단, 발사 시간은 20초로 제한되오니 주의바랍니다."; }
        else if (script == 25) { setY1(); tmp.text = "이상으로 튜토리얼을 마치겠습니다."; }
    }

}
