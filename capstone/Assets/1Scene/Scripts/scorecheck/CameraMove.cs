using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject targetObject; // ������ ��� ������Ʈ
    public Vector3 offset = new Vector3(0, 0, -1); // ī�޶� ������
    public float smoothSpeed = 0.125f; // ī�޶� �̵� �ӵ�
    public float sizePadding = 0.5f; // ������Ʈ ũ�⿡ ���� ī�޶� �е�

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        if (targetObject != null)
        {
            // ������Ʈ�� ��� ���
            Bounds targetBounds = CalculateBounds(targetObject);
            float targetSize = Mathf.Max(targetBounds.size.x, targetBounds.size.y, targetBounds.size.z);

            // ī�޶� �Ÿ� ���
            float distance = (targetSize * sizePadding) / Mathf.Tan(cam.fieldOfView * 0.5f * Mathf.Deg2Rad);

            // ���ο� ��ġ ���
            Vector3 desiredPosition = targetBounds.center + offset.normalized * distance;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // ī�޶� ��ġ ������Ʈ
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

