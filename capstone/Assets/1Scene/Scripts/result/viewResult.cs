using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class viewResult : MonoBehaviour
{
    public GameObject victoryImg;//승리 이미지
    public GameObject defeatImg;//패배 이미지
    public GameObject drawImg;//무승부 이미지

    AudioSource resultSnd;//

    // Start is called before the first frame update
    void Start()
    {
        resultSnd = GameObject.Find("resultSnd").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void viewVictory() { //승리
        resultSnd.Play();
        defeatImg.gameObject.SetActive(false);
        drawImg.gameObject.SetActive(false);

        victoryImg.gameObject.SetActive(true);
    }

    public void viewDefeat() { //패배
        resultSnd.Play();
        victoryImg.gameObject.SetActive(false);
        drawImg.gameObject.SetActive(false);

        defeatImg.gameObject.SetActive(true);
    }

    public void viewDraw() { //무승부
        resultSnd.Play();
        victoryImg.gameObject.SetActive(false);
        defeatImg.gameObject.SetActive(false);

        drawImg.gameObject.SetActive(true);
    }

    public void viewNothing()
    { //아무것도 띄우지 않음
        victoryImg.gameObject.SetActive(false);
        defeatImg.gameObject.SetActive(false);
        drawImg.gameObject.SetActive(false);
    }
}
