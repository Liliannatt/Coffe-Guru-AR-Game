using UnityEngine;
using UnityEngine.UI; // ����UI�����ռ�

public class PrintPosRot : MonoBehaviour
{
    public Transform objectToTrack; // Ҫ׷�ٵ�����
    public Text positionText; // ��ʾλ�õ�UI Text
    public Text rotationText; // ��ʾ��ת��UI Text

    void Update()
    {
        // ����λ�ú���ת��TextԪ������
        if (objectToTrack != null && positionText != null && rotationText != null)
        {
            positionText.text = "Position: " + objectToTrack.position.ToString();
            rotationText.text = "Rotation: " + objectToTrack.rotation.ToString();
        }
    }
}