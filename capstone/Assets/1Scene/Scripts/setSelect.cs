using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setSelect : MonoBehaviour
{
    public GameObject SetSelectPanel; //��Ʈ�� ���� �г�

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void viewSetSelect() { //�г� ���̱�
        SetSelectPanel.SetActive(true);
    }

    public void hideSetSelect() { //�г� �����
        SetSelectPanel.SetActive(false);
    }
}
