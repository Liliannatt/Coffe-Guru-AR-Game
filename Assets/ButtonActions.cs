using UnityEngine;

public class ButtonActions : MonoBehaviour
{
    public GameObject voiceControlObject; // ��ק����voiceMovement�ű��Ķ�������ֶ�

    // ����������ڰ�ť���ʱ����
    public void OnFinishMixingButtonClicked()
    {
        // ��ȡvoiceMovement�ű�������finish_mixingΪtrue
        voiceMovement vm = voiceControlObject.GetComponent<voiceMovement>();
        if (vm != null)
        {
            vm.finish_mixing = true;
        }
    }
}
