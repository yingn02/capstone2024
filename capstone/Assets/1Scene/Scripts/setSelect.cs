using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setSelect : MonoBehaviour
{
    public GameObject SetSelectPanel; //세트수 선택 패널

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void viewSetSelect() { //패널 보이기
        SetSelectPanel.SetActive(true);
    }

    public void hideSetSelect() { //패널 숨기기
        SetSelectPanel.SetActive(false);
    }
}
