using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class csh_tutorial : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    public int script;
    public GameObject next_button;
    public GameObject prev_button;
    public GameObject end_button;
    public GameObject tutorial_panel;
    public bool tutorial2 = false;
    public bool tutorial3 = false;
    public bool tutorial4 = false;
    public bool tutorial5 = false;
    public bool tutorial6 = false;
    public bool tutorial7 = false;
    public float img_time = 0.0f;
    public GameObject tutorial_img1;
    public GameObject tutorial_img2_1;
    public GameObject tutorial_img2_2;
    public GameObject tutorial_img3_1;
    public GameObject tutorial_img3_2;
    public GameObject tutorial_img4_1;
    public GameObject tutorial_img4_2;
    public GameObject tutorial_img5_1;
    public GameObject tutorial_img5_2;
    public GameObject tutorial_img6_1;
    public GameObject tutorial_img6_2;
    public GameObject tutorial_img7_1;
    public GameObject tutorial_img7_2;
    public GameObject tutorial_img8;
    public GameObject tutorial_img9;
    public GameObject tutorial_img10;
    public GameObject tutorial_img11;
    public GameObject tutorial_img12;
    public GameObject tutorial_img13;
    public GameObject tutorial_img14;

    // Start is called before the first frame update
    void Start() {
        viewButton(); //��ư ����� ���̱� ����
        viewImg(); //�̹��� ����� ���̱� ����
        tmp = GetComponent<TextMeshProUGUI>();
        script = 0;
        tmp.text = "��� ü���忡 ���� ���� ȯ���մϴ�!";
    }
    // Update is called once per frame
    void Update() {
        if (tutorial2) { tutorial_gif(tutorial_img2_1, tutorial_img2_2); }
        else if (tutorial3) { tutorial_gif(tutorial_img3_1, tutorial_img3_2); }
        else if (tutorial4) { tutorial_gif(tutorial_img4_1, tutorial_img4_2); }
        else if (tutorial5) { tutorial_gif(tutorial_img5_1, tutorial_img5_2); }
        else if (tutorial6) { tutorial_gif(tutorial_img6_1, tutorial_img6_2); }
        else if (tutorial7) { tutorial_gif(tutorial_img7_1, tutorial_img7_2); }
    }
    public void prevButton()
    {
        if (this.gameObject.activeSelf) { //'����' ��ư ������ 
            script--;
            changeScript();//��� �ٲٱ�
            viewButton(); //��ư ����� ���̱� ����
            viewImg(); //�̹��� ����� ���̱� ����

        }
    }
    public void nextButton() {
        if (this.gameObject.activeSelf) { //'����' ��ư ������ 
            script++;
            changeScript(); //��� �ٲٱ�
            viewButton(); //��ư ����� ���̱� ����
            viewImg(); //�̹��� ����� ���̱� ����
        }
    }
    public void endButton() {
        if (this.gameObject.activeSelf) { //'����' ��ư ������ 
            tutorial_panel.SetActive(false); //��ȭâ �ݱ�
        }
    }
    public void viewButton() {
        if (script <= 0) { prev_button.SetActive(false); next_button.SetActive(true); end_button.SetActive(false); } //�� ó�� ��簡 ���� ��
        else if (script > 0 && script < 25) { prev_button.SetActive(true); next_button.SetActive(true); end_button.SetActive(false); } // �߰� ���
        else if (script >= 25) { prev_button.SetActive(true); next_button.SetActive(false); end_button.SetActive(true); } //�� ������ ��簡 ���� ��
    }
    public void viewImg() {
        //�̹��� ����� (���� �̹��� ����)
        tutorial_img1.SetActive(false);
        tutorial2 = false; tutorial_img2_1.SetActive(false); tutorial_img2_2.SetActive(false);
        tutorial3 = false; tutorial_img3_1.SetActive(false); tutorial_img3_2.SetActive(false);
        tutorial4 = false; tutorial_img4_1.SetActive(false); tutorial_img4_2.SetActive(false);
        tutorial5 = false; tutorial_img5_1.SetActive(false); tutorial_img5_2.SetActive(false);
        tutorial6 = false; tutorial_img6_1.SetActive(false); tutorial_img6_2.SetActive(false);
        tutorial7 = false; tutorial_img7_1.SetActive(false); tutorial_img7_2.SetActive(false);
        tutorial_img8.SetActive(false);
        tutorial_img9.SetActive(false);
        tutorial_img10.SetActive(false);
        tutorial_img11.SetActive(false);
        tutorial_img12.SetActive(false);
        tutorial_img13.SetActive(false);
        tutorial_img14.SetActive(false);

        //�̹��� ���̱�
        if (script == 3) { tutorial_img1.SetActive(true); }
        else if (script == 4) { tutorial_img1.SetActive(true); }
        else if (script == 5) { 
            tutorial2 = true; //gif ȿ�� 
            tutorial_img2_1.SetActive(true);
        }
        else if (script == 6) {
            tutorial3 = true; //gif ȿ�� 
            tutorial_img3_1.SetActive(true);
        }
        else if (script == 7) {
            tutorial4 = true; //gif ȿ�� 
            tutorial_img4_1.SetActive(true);
        }
        else if (script == 8) {
            tutorial5 = true; //gif ȿ�� 
            tutorial_img5_1.SetActive(true);
        }
        else if (script == 9) {
            tutorial6 = true; //gif ȿ�� 
            tutorial_img6_1.SetActive(true);
        }
        else if (script == 10)
        {
            tutorial7 = true; //gif ȿ�� 
            tutorial_img7_1.SetActive(true);
        }
        else if (script == 11) { tutorial_img8.SetActive(true); }
        else if (script == 12) { tutorial_img9.SetActive(true); }
        else if (script == 13) { tutorial_img10.SetActive(true); }
        else if (script == 14) { tutorial_img11.SetActive(true); }
        else if (script == 15) { tutorial_img12.SetActive(true); }
        else if (script == 16) { tutorial_img13.SetActive(true); }
        else if (script == 17) { tutorial_img13.SetActive(true); }
        else if (script == 18) { tutorial_img14.SetActive(true); }

    }
    public void tutorial_gif(GameObject tutorial_imgn_1, GameObject tutorial_imgn_2) {
        img_time += Time.deltaTime;
        if (img_time >= 0.5f) {
            tutorial_imgn_1.SetActive(!tutorial_imgn_1.activeSelf);
            tutorial_imgn_2.SetActive(!tutorial_imgn_2.activeSelf);
            img_time = 0.0f;
        }
    }
    public void setY1() { // �ؽ�Ʈ�� ���̿� ���� ���̰� ��ȭ�ϴ� ���� ����
        Vector3 pos = tmp.rectTransform.anchoredPosition; //Label ��ġ
        pos.y = 60f; // y��ǥ
        tmp.rectTransform.anchoredPosition = pos; // �� ��ġ�� ����
    }
    public void setY2() { // �ؽ�Ʈ�� ���̿� ���� ���̰� ��ȭ�ϴ� ���� ����
        Vector3 pos = tmp.rectTransform.anchoredPosition; //Label ��ġ
        pos.y = 41f; // y��ǥ
        tmp.rectTransform.anchoredPosition = pos; // �� ��ġ�� ����
    }
    public void changeScript() {
        if (script == 0) { setY1(); tmp.text = "��� ü���忡 ���� ���� ȯ���մϴ�!"; }
        else if (script == 1) { setY1(); tmp.text = "�̰��� ������ ������ '���'�� ü���� �� �ִ� �����Դϴ�."; }
        else if (script == 2) { setY1(); tmp.text = "����, ����� ��Ģ�� ������ �Ұ��ص帮�ڽ��ϴ�."; }
        else if (script == 3) { setY2(); tmp.text = "����̶�, Ȱ�� ȭ���� �߻��Ͽ� ���� �Ÿ� �̻� ������ ������ ������ �������Դϴ�."; }
        else if (script == 4) { setY1(); tmp.text = "ȭ���� ������ ���߾ӿ� ������ �����Ҽ���, ���� ������ ȹ���� �� �ֽ��ϴ�."; }
        else if (script == 5) { setY1(); tmp.text = "����� ��ġ�� ����� ������ 10~9��,"; }
        else if (script == 6) { setY1(); tmp.text = "�� �ۿ� ��ġ�� ������ ������ 8~7��,"; }
        else if (script == 7) { setY1(); tmp.text = "�� �ۿ� ��ġ�� �Ķ��� ������ 6~5��,"; }
        else if (script == 8) { setY1(); tmp.text = "�� �ۿ� ��ġ�� ������ ������ 4~3��,"; }
        else if (script == 9) { setY1(); tmp.text = "�� �ۿ� ��ġ�� �Ͼ�� ������ 2~1��,"; }
        else if (script == 10) { setY1(); tmp.text = "�� �ۿ� ������ ������ 0������ ó���˴ϴ�."; }
        else if (script == 11) { setY1(); tmp.text = "����� ��Ģ�� '�ø��� ���� ������'�� �������� �����ϵ��� �ϰڽ��ϴ�."; }
        else if (script == 12) { setY2(); tmp.text = "'�ø��� ���� ������'�̶�, �� ������ 1�� �����Ͽ� 3�߾� ���� ��Ʈ�� ��� ��Ģ�Դϴ�."; }
        else if (script == 13) { setY2(); tmp.text = "1�δ� 1�߾� �����ư��� ���� �� 3�߾� ��� �� ��Ʈ�� ���� ���̰�, ��Ʈ���� �¸��ϸ� 2��, ���ºδ� 1��, �й�� 0���� ȹ���մϴ�."; }
        else if (script == 14) { setY2(); tmp.text = "��� ��Ʈ�� ���� �� ��Ʈ ������ �� ���� ���� �¸��մϴ�. ��, �¸��� �ʿ��� �ּ� ��Ʈ ������ 6�� �Դϴ�."; }
        else if (script == 15) { setY1(); tmp.text = "��� ��Ʈ�� ���� �Ŀ��� �� ���� ������ ������ ���, �������� �����մϴ�."; }
        else if (script == 16) { setY2(); tmp.text = "��������, 1�δ� 1�߾� �����ư��� ���� ������ �� ���� ���� �¸��ϴ� ��Ʈ�Դϴ�."; }
        else if (script == 17) { setY1(); tmp.text = "3���� ������ �ջ����� �ʰ� 1�߾� �º��Ͽ� �ܷ�ϴ�."; }
        else if (script == 18) { setY1(); tmp.text = "���� �������� ������ ������ ���, ������ �߽ɿ� �� ������ �� ���� �¸��մϴ�."; }
        else if (script == 19) { setY1(); tmp.text = "�̰����� ����� ��Ģ�� ������ �˾ƺ��ҽ��ϴ�."; }
        else if (script == 20) { setY1(); tmp.text = "������ ����� �߻� ������ �˾ƺ����� �ϰڽ��ϴ�."; }
        else if (script == 21) { setY2(); tmp.text = "����, ����� ������ �߽ɰ� �������� �ǵ��� ����, ����� ������ ��� �ʺ� ������ �����մϴ�."; }
        else if (script == 22) { setY1(); tmp.text = "�� ���� Ȱ�� ȭ���� �����, ȭ���� ���� ��ġ�� Ȱ�� ������ ���ϴ�."; }
        else if (script == 23) { setY2(); tmp.text = "Ȱ ������ ���� ���� ���̳� ���ʿ� �� ���·� ���ῡ ������ ��, ���� ���� �߻��մϴ�."; }
        else if (script == 24) { setY1(); tmp.text = "��, �߻� �ð��� 20�ʷ� ���ѵǿ��� ���ǹٶ��ϴ�."; }
        else if (script == 25) { setY1(); tmp.text = "�̻����� Ʃ�丮���� ��ġ�ڽ��ϴ�."; }
    }

}
