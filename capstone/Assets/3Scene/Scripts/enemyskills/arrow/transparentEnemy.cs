using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transparentEnemy : ArrowSkill
{
    public GameObject SkillPanelManagerEnemy; //��ų �г� ��ũ��Ʈ
    public GameManager gameManager;

    public GameObject target;
    public GameObject arrow;

    public bool skill = false; //��ų�� �ߵ� ���ΰ�?
    public int cool = 0; //��Ÿ��(��), �� ���� ������ �� ��ٷ��� �ϴ°��� ����
    public int num = -1; //��ų�� ���õǾ��� ��, ���� ���° ��ų���� ��üȭ, ban() �� pardon()���� ����

    public float transparency = 0.5f; //0�� ���� ����, 1�� ���� ������

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

    public void execute() { //��ų �ߵ�
        skill = true;
        gameManager.activatedArrowSkills.Add(this);

        SetTransparency(target, transparency);
        //SetTransparency(arrow, transparency);

        Debug.Log("���� ȭ��� ����");

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

    public void setCool(int selected, int cool_time) { //��Ÿ�� ����
        cool = cool_time; //��Ÿ�� (������ ���Խ�Ų ��, �׻� Ȧ���� ��)
        num = selected;
    }

    public void ban() { //��ų ���� �����
        SkillPanelManagerEnemy.GetComponent<SkillPanelManagerEnemy>().buttons[num] = false; //���� 1�� ��ų�̸� 1�� ��ų ��ư�� ��Ȱ��ȭ
    }

    public void pardon() { //��ų ���� ���
        SkillPanelManagerEnemy.GetComponent<SkillPanelManagerEnemy>().buttons[num] = true; //���� 1�� ��ų�̸� 1�� ��ų ��ư�� Ȱ��ȭ
    }
}
