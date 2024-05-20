using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public targetControl target;
    public targetControl Enemytarget;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UseSkill(string skillName)
    {
        if (gameManager.currentSkill != "none") return;

        var method = this.GetType().GetMethod(skillName, BindingFlags.NonPublic | BindingFlags.Instance);
        if (method != null)
        {
            gameManager.currentSkill = skillName;
            
            method.Invoke(this, null);
        }
        else
        {
            Debug.Log("Skill not found - " + skillName);
        }
    }
    public void disableSkill(string skillName)
    {
        var method = this.GetType().GetMethod("disable"+skillName, BindingFlags.NonPublic | BindingFlags.Instance);
        if (method != null)
        {
            gameManager.currentSkill = skillName;

            method.Invoke(this, null);
        }
        else
        {
            Debug.Log("Skill not found - " + skillName);
        }
    }
    void bigTarget()
    {
        //자신에게 유리한 스킬은 즉시 발동
        gameManager.skillActivated = true;

        if (gameManager.playerTurn)
        {
            target.parent.transform.localScale = new Vector3(2, 2, 1);
        }
        else
        {
            Enemytarget.parent.transform.localScale = new Vector3(2, 2, 1);
        }
    }
    void disablebigTarget()
    {
        target.parent.transform.localScale = new Vector3(1, 1, 1);
        Enemytarget.parent.transform.localScale = new Vector3(1, 1, 1);
    }

    void smallTarget()
    {
        if (!gameManager.playerTurn)
        {
            target.parent.transform.localScale = new Vector3(0.5f, 0.5f, 1);
        }
        else
        {
            Enemytarget.parent.transform.localScale = new Vector3(0.5f, 0.5f, 1);
        }
    }
    void disablesmallTarget()
    {
        target.parent.transform.localScale = new Vector3(1, 1, 1);
        Enemytarget.parent.transform.localScale = new Vector3(1, 1, 1);
    }
    void movingTarget()
    {
        if (!gameManager.playerTurn)
        {
            target.moving = true;
        }
        else
        {
            Enemytarget.moving = true;
        }
    }
    void disablemovingTarget()
    {
        target.moving = false;
        Enemytarget.moving = false;
        target.parent.transform.position = new Vector3(0, 0, 0);
        Enemytarget.parent.transform.position = new Vector3(5.8f, 0, 0);
    }
}
