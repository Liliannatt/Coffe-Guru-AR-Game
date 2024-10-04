using UnityEngine;

public class KeepInCenter : MonoBehaviour
{
    public Camera arCamera; // ָ��AR�����
    public float distanceFromCamera = 2.0f; // ָ����������ľ���

    void Update()
    {
        if (arCamera != null)
        {
            // ����ģ��λ��Ϊ�����ǰ�������ĵ�
            Vector3 newPosition = arCamera.transform.position + arCamera.transform.forward * distanceFromCamera;
            transform.position = newPosition;

            // ��ѡ: ȷ��ģ��ʼ�����������
            transform.LookAt(arCamera.transform);
            transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
        }
        else
        {
            Debug.LogError("AR Camera is not assigned.");
        }
    }
}
