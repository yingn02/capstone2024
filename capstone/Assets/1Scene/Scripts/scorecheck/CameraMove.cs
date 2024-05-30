using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject targetObject; // 추적할 대상 오브젝트
    public Vector3 offset = new Vector3(0, 0, -1); // 카메라 오프셋
    public float smoothSpeed = 0.125f; // 카메라 이동 속도
    public float sizePadding = 0.5f; // 오브젝트 크기에 따른 카메라 패딩

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        if (targetObject != null)
        {
            // 오브젝트의 경계 계산
            Bounds targetBounds = CalculateBounds(targetObject);
            float targetSize = Mathf.Max(targetBounds.size.x, targetBounds.size.y, targetBounds.size.z);

            // 카메라 거리 계산
            float distance = (targetSize * sizePadding) / Mathf.Tan(cam.fieldOfView * 0.5f * Mathf.Deg2Rad);

            // 새로운 위치 계산
            Vector3 desiredPosition = targetBounds.center + offset.normalized * distance;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // 카메라 위치 업데이트
            transform.position = smoothedPosition;
            transform.LookAt(targetBounds.center);
        }
    }

    Bounds CalculateBounds(GameObject obj)
    {
        Renderer[] renderers = obj.GetComponentsInChildren<Renderer>();
        if (renderers.Length == 0)
        {
            return new Bounds(obj.transform.position, Vector3.zero);
        }

        Bounds bounds = renderers[0].bounds;
        foreach (Renderer renderer in renderers)
        {
            bounds.Encapsulate(renderer.bounds);
        }

        return bounds;
    }
}

