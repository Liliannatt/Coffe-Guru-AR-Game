using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mix_function : MonoBehaviour
{
    public GameObject objectA; // A��Ʒ
    public GameObject objectB; // B��Ʒ
    public GameObject objectC; // ��Ҫ��ʾ��C��Ʒ

    public float thresholdDistance = 0.02f; // A��B��Ʒ֮�����С����

    private bool isObjectCActive = false; // C��Ʒ��ǰ�ļ���״̬

    public Text distanceText; // ������ʾ�����UI Text

    void Update()
    {
        // ���A��B��Ʒ�Ƿ񶼱�ʶ���ˣ������Ƕ����ڼ���״̬��
        if (objectA.activeInHierarchy && objectB.activeInHierarchy)
        {
            float distance = Vector3.Distance(objectA.transform.position, objectB.transform.position);

            if (distanceText != null)
            {
                distanceText.text = "Distance: " + distance.ToString("F2"); // ������λС��
            }

            // ���A��B��Ʒ�ľ���С����ֵ����C��Ʒ��δ��ʾ������ʾC��Ʒ
            if (distance < thresholdDistance && !isObjectCActive)
            {
                Vector3 middlePoint = (objectA.transform.position + objectB.transform.position) / 2;
                objectC.transform.position = middlePoint; // ����C��Ʒ��λ��ΪA��B���е�
                objectC.SetActive(true);
                isObjectCActive = true;
            }
            // ���A��B��Ʒ�ľ��������ֵ����C��Ʒ����ʾ��������C��Ʒ
            else if (distance >= thresholdDistance && isObjectCActive)
            {
                objectC.SetActive(false);
                isObjectCActive = false;
            }
        }
    }
}
