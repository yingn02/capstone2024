using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transparent : ArrowSkill
{
    public GameObject SkillPanelManager; //��ų �г� ��ũ��Ʈ
    public GameManager gameManager;

    public GameObject target;
    public GameObject arrow;

    public bool skill = false; //��ų�� �ߵ� ���ΰ�? 
    public int cool = 0; //��Ÿ��(��), �� ���� ������ �� ��ٷ��� �ϴ°��� ����
    public int num = -1; //��ų�� ���õǾ��� ��, ���� ���° ��ų���� ��üȭ, ban() �� pardon()���� ����

    public float transparency = 0.5f; //0�� ���� ����, 1�� ���� ������

    private Renderer originalTargetRenderer;
    private Renderer originalArrowRenderer;
    private Color originalTargetColor;
    private Color originalArrowColor;

    private Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        activeTurns = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void execute()
    { //��ų �ߵ�
        skill = true;
        gameManager.activatedArrowSkills.Add(this);

        SetTransparency(target, transparency);
        //SetTransparency(arrow, transparency);

        Debug.Log("���� ȭ��� ����");
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
            //originalTargetMaterial = target.GetComponent<Renderer>().material;
            originalTargetRenderer = obj.GetComponent<Renderer>();
            originalTargetColor = originalTargetRenderer.material.color;
            renderer = obj.GetComponent<Renderer>();
        }
        else if (obj.CompareTag("Arrow"))
        {
            //originalArrowMaterial = arrow.GetComponent<Renderer>().material;
            originalArrowRenderer = obj.GetComponentInChildren<Renderer>();
            originalArrowColor = originalArrowRenderer.material.color;
            renderer = obj.GetComponentInChildren<Renderer>();
        }

        //Renderer renderer = obj.GetComponent<Renderer>();

        if (renderer != null)
        {
            // ���� ������ �����ͼ� ���� ����
            Color color = renderer.material.color;
            color.a = transparency;
            renderer.material.color = color;

            // ���� ���� �����ϱ� ���� material�� shader ����
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
        if (target != null && originalTargetColor != null)
        {
            //target.GetComponent<Renderer>().material = originalTargetMaterial;
            renderer = target.GetComponent<Renderer>();
            renderer.material.color = originalTargetColor;
        }
        else
        {
            Debug.LogWarning("Target object or original material not found");
        }

        if (arrow != null && originalArrowColor != null)
        {
            //arrow.GetComponent<Renderer>().material = originalArrowMaterial;
            renderer = arrow.GetComponentInChildren<Renderer>();
            renderer.material.color = originalArrowColor;
        }
        else
        {
            Debug.LogWarning("Arrow object or original material not found");
        }
    }

    public void setCool(int selected, int cool_time) { //��Ÿ�� ����
        cool = cool_time; //��Ÿ�� (������ ���Խ�Ų ��, �׻� Ȧ���� ��)
        num = selected;
    }

    public void ban() { //��ų ���� �����
        if (num == 1) { //���� 1�� ��ų�̸� 1�� ��ų ��ư�� ��Ȱ��ȭ
            SkillPanelManager.GetComponent<SkillPanelManager>().buttonA.interactable = false;
        }
        else if (num == 2)
        {
            SkillPanelManager.GetComponent<SkillPanelManager>().buttonB.interactable = false;
        }
        else if (num == 3)
        {
            SkillPanelManager.GetComponent<SkillPanelManager>().buttonC.interactable = false;
        }
    }

    public void pardon() { //��ų ���� ���
        if (num == 1) { //���� 1�� ��ų�̸� 1�� ��ų ��ư�� Ȱ��ȭ
            SkillPanelManager.GetComponent<SkillPanelManager>().buttonA.interactable = true;
        }
        else if (num == 2)
        {
            SkillPanelManager.GetComponent<SkillPanelManager>().buttonB.interactable = true;
        }
        else if (num == 3)
        {
            SkillPanelManager.GetComponent<SkillPanelManager>().buttonC.interactable = true;
        }
    }
}
