using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPanelManagerEnemy : MonoBehaviour
{

    public List<bool> buttons = new List<bool>(); //적팀의 스킬 버튼 리스트, 플레이어의 스킬1 버튼과 비슷한 역할

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            buttons[i] = true;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
