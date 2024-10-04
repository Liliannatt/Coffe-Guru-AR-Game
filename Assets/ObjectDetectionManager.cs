using System;
using UnityEngine;
using Vuforia;

public class ObjectDetectionManager : MonoBehaviour
{
    public RectTransform uiImageFrame; // UI���RectTransform
    public Camera arCamera; // ARCamera����
    public ObserverBehaviour observerBehaviour; // �����Observer���

    private float detectionTimeThreshold = 3.0f; // ���ʱ����ֵ
    private float timeInsideFrame = 0.0f; // �����ڿ��ڵ�ʱ��
    private bool isInsideFrame = false; // �����Ƿ��ڿ���

    public event Action<string> OnObjectDetected;

    void Update()
    {
        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(arCamera, observerBehaviour.transform.position);
        Vector3[] corners = new Vector3[4];
        uiImageFrame.GetWorldCorners(corners);
        for (int i = 0; i < corners.Length; i++)
        {
            corners[i] = RectTransformUtility.WorldToScreenPoint(arCamera, corners[i]);
        }

        if (IsWithinBounds(screenPoint, corners))
        {
            if (!isInsideFrame)
            {
                isInsideFrame = true;
                timeInsideFrame = 0.0f;
            }

            timeInsideFrame += Time.deltaTime;

            if (timeInsideFrame >= detectionTimeThreshold)
            {
                OnObjectDetected?.Invoke(observerBehaviour.TargetName);
                observerBehaviour.enabled = false; // ����Observer���
                isInsideFrame = false; // ���ñ�־
            }
        }
        else
        {
            if (isInsideFrame)
            {
                // �����뿪UI��׼���������ü��
                isInsideFrame = false;
                observerBehaviour.enabled = true; // ��������Observer���
            }
            timeInsideFrame = 0.0f;
        }
    }


    private bool IsWithinBounds(Vector2 screenPoint, Vector3[] corners)
    {
        float minX = Mathf.Min(corners[0].x, corners[1].x, corners[2].x, corners[3].x);
        float maxX = Mathf.Max(corners[0].x, corners[1].x, corners[2].x, corners[3].x);
        float minY = Mathf.Min(corners[0].y, corners[1].y, corners[2].y, corners[3].y);
        float maxY = Mathf.Max(corners[0].y, corners[1].y, corners[2].y, corners[3].y);

        return screenPoint.x >= minX && screenPoint.x <= maxX && screenPoint.y >= minY && screenPoint.y <= maxY;
    }

    // �������ü�����ʾģ��
    public void EnableDetection()
    {
        observerBehaviour.enabled = true;
        isInsideFrame = false;
        timeInsideFrame = 0.0f;
    }
}
