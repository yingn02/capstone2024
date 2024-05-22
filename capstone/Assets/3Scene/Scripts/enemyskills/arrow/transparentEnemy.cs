using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transparentEnemy : ArrowSkill
{
    public GameObject SkillPanelManagerEnemy; //스킬 패널 스크립트
    public GameManager gameManager;

    public GameObject target;
    public GameObject arrow;

    public bool skill = false; //스킬이 발동 중인가?
    public int cool = 0; //쿨타임(턴), 몇 턴을 앞으로 더 기다려야 하는가의 변수
    public int num = -1; //스킬이 선택되었을 때, 나는 몇번째 스킬인지 정체화, ban() 과 pardon()에서 쓰임

    public float transparency = 0.5f; //0은 완전 투명, 1은 완전 불투명

    private Material originalTargetMaterial;
    private Material originalArrowMaterial;

    // Start is called before the first frame update
    void Start()
    {
        activeTurns = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void execute() { //스킬 발동
        skill = true;
        gameManager.activatedArrowSkills.Add(this);

        SetTransparency(target, transparency);
        //SetTransparency(arrow, transparency);

        Debug.Log("투명 화살과 과녁");

        skill = false;
    }

    public override void disable()
    {
        RestoreOriginalState();
        skill = false;
        arrow = null;
        activeTurns = 2;
    }

    public void SetTransparency(GameObject obj, float transparency)
    {
        if ((obj.CompareTag("Target")) || (obj.CompareTag("EnemyTarget")))
        {
            originalTargetMaterial = target.GetComponent<Renderer>().material;
        }
        else if (obj.CompareTag("Arrow"))
        {
            originalArrowMaterial = arrow.GetComponent<Renderer>().material;
        }

        Renderer renderer = obj.GetComponent<Renderer>();

        if (renderer != null)
        {
            // 현재 색상을 가져와서 투명도 변경
            Color color = renderer.material.color;
            color.a = transparency;
            renderer.material.color = color;

            // 알파 값을 적용하기 위해 material의 shader 설정
            renderer.material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            renderer.material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            renderer.material.SetInt("_ZWrite", 0);
            renderer.material.DisableKeyword("_ALPHATEST_ON");
            renderer.material.EnableKeyword("_ALPHABLEND_ON");
            renderer.material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            renderer.material.renderQueue = 3000;
        }
    }

    public void RestoreOriginalState()
    {
        if (target != null && originalTargetMaterial != null)
        {
            target.GetComponent<Renderer>().material = originalTargetMaterial;
        }
        else
        {
            Debug.LogWarning("Target object or original material not found");
        }

        if (arrow != null && originalArrowMaterial != null)
        {
            arrow.GetComponent<Renderer>().material = originalArrowMaterial;
        }
        else
        {
            Debug.LogWarning("Arrow object or original material not found");
        }
    }

    public void setCool(int selected, int cool_time) { //쿨타임 설정
        cool = cool_time; //쿨타임 (적턴을 포함시킨 수, 항상 홀수일 것)
        num = selected;
    }

    public void ban() { //스킬 선택 비허용
        SkillPanelManagerEnemy.GetComponent<SkillPanelManagerEnemy>().buttons[num] = false; //내가 1번 스킬이면 1번 스킬 버튼을 비활성화
    }

    public void pardon() { //스킬 선택 허용
        SkillPanelManagerEnemy.GetComponent<SkillPanelManagerEnemy>().buttons[num] = true; //내가 1번 스킬이면 1번 스킬 버튼을 활성화
    }
}
