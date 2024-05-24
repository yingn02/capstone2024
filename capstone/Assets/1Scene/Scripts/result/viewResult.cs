using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class viewResult : MonoBehaviour
{
    public GameObject victoryImg;//�¸� �̹���
    public GameObject defeatImg;//�й� �̹���
    public GameObject drawImg;//���º� �̹���

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

    public void viewVictory() { //�¸�
        resultSnd.Play();
        defeatImg.gameObject.SetActive(false);
        drawImg.gameObject.SetActive(false);

        victoryImg.gameObject.SetActive(true);
    }

    public void viewDefeat() { //�й�
        resultSnd.Play();
        victoryImg.gameObject.SetActive(false);
        drawImg.gameObject.SetActive(false);

        defeatImg.gameObject.SetActive(true);
    }

    public void viewDraw() { //���º�
        resultSnd.Play();
        victoryImg.gameObject.SetActive(false);
        defeatImg.gameObject.SetActive(false);

        drawImg.gameObject.SetActive(true);
    }

    public void viewNothing()
    { //�ƹ��͵� ����� ����
        victoryImg.gameObject.SetActive(false);
        defeatImg.gameObject.SetActive(false);
        drawImg.gameObject.SetActive(false);
    }
}
