using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreBonus : MonoBehaviour
{
    public bool skill = false; //arrowControl 스크립트에서 이것을 감지하고 관리함

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void execute() { //스킬 발동
        Debug.Log("스킬 보너스"); 
        skill = true; 
    }
}
