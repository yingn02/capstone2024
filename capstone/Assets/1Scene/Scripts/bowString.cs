using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bowString : MonoBehaviour
{
    //https://github.com/SunnyValleyStudio/VR-Archery-in-Unity-2022/blob/main/Vid%201-2/BowString.cs
    [SerializeField]
    private Transform endpoint_1, endpoint_2;

    private LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void CreateString(Vector3? midPosition)
    {
        Vector3[] linePoints = new Vector3[midPosition == null ? 2 : 3];
        linePoints[0] = endpoint_1.localPosition;
        if (midPosition != null)
        {
            linePoints[1] = transform.InverseTransformPoint(midPosition.Value);
        }
        linePoints[^1] = endpoint_2.localPosition;

        lineRenderer.positionCount = linePoints.Length;
        lineRenderer.SetPositions(linePoints);
    }

    private void Start()
    {
        CreateString(null);
    }
}
