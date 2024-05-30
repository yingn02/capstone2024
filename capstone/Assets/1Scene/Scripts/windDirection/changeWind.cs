using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Debug = UnityEngine.Debug;
using TMPro;
using UnityEngine;

public class changeWind : MonoBehaviour
{
    public GameObject ArrowControl; //화살 프리팹 스크립트

    public GameObject windDirection; //풍향 표시
    public Vector3 windVector; // 바람의 힘 벡터를 arrowControl 스크립트로 전달할 것임
    public Vector3 imgWindVector; //바람의 힘 벡터를 가져와서 UI에 표시할 것임
    public float changeTime = 3.0f; //풍향이 3초마다 변화
    public float changePassTime = 0.0f; //몇초 지났는지 세는 변수

    public bool isRemove = false; //풍향을 제거하겠는가 (removeWind 스크립트에서 관리)
    public bool isTyphoon = false; //풍향의 영향을 2배로 증가시키겠는가 (typhoon 스크립트에서 관리)
    public bool isRemoveEnemy = false; //풍향을 제거하겠는가 (removeWindEnemy 스크립트에서 관리)
    public bool isTyphoonEnemy = false; //풍향의 영향을 2배로 증가시키겠는가 (typhoonEnemy 스크립트에서 관리)
    public bool isChange = false; //풍향을 즉시 업데이트하라 (스킬 때문에 필요)
    public bool isChangeEnemy = false; //풍향을 즉시 업데이트하라 (스킬 때문에 필요)

    private float x; // 왼쪽 또는 오른쪽 바람
    private float y; // 위 또는 아래 바람은 제외했음
    private float z; // 앞 또는 뒤 바람, 이 값은 이미 arrowControl 스크립트의 diff값이 조절하므로 고정했음

    // Start is called before the first frame update
    void Start()
    {
        view_wind(); // 최초의 풍향 표시
    }

    // Update is called once per frame
    void Update()
    {
        if (isChange)
        {
            view_wind();
            isChange = false;
        }

        if (isChangeEnemy)
        {
            view_wind();
            isChangeEnemy = false;
        }

        if (changePassTime >= changeTime)
        { //풍향이 바뀐지 3초가 지나면
            view_wind();//풍향을 재설정하고 UI도 업데이트
            changePassTime = 0.0f;
        }
        else
        {
            changePassTime += Time.deltaTime;
        }

        //Debug.Log("현재 풍향 세기 - " + "x" + x + "/" + "y" + y + "/" + "z" + z + "/");
    }

    public void view_wind()
    { //풍향을 재설정하고 UI도 업데이트
        // 풍향을 랜덤으로 설정
        windVector = random_wind();
        imgWindVector = windVector;

        //z축의 바람을 생략하였으나, 이미지 상으로는 표시할 필요가 있다. 랜덤으로 표시할 것임
        if (Random.Range(-1.0f, 1.0f) < 0)
        {
            imgWindVector.z *= -1.0f;
        }

        // x와 z 컴포넌트를 사용하여 평면 각도 계산
        float angle = Mathf.Atan2(imgWindVector.z, imgWindVector.x) * Mathf.Rad2Deg;

        //화살표 이미지 회전
        windDirection.transform.rotation = Quaternion.Euler(-45, -30 + 180, 90 - angle);
    }

    public Vector3 random_wind()
    { //풍향을 랜덤으로 설정하고 벡터를 반환
        x = Random.Range(-1.0f, 1.0f); // 왼쪽 또는 오른쪽 바람
        y = Random.Range(0.0f, 0.0f); // 위 또는 아래 바람은 제외했음
        z = Random.Range(0.3f, 0.3f); // 앞 또는 뒤 바람, 이 값은 이미 arrowControl 스크립트의 diff값이 조절하므로 고정했음

        //바람 세기 조절 (풍향 관련 스킬)
        if (isRemove) { x *= 0; y *= 0; z *= 0; }
        else if (isTyphoon) { x *= 2; y *= 2; z *= 2; }

        if (isRemoveEnemy) { x *= 0; y *= 0; z *= 0; }
        else if (isTyphoonEnemy) { x *= 2; y *= 2; z *= 2; }

        Vector3 newWind = new Vector3(x, y, z);

        return newWind;
    }

}