using UnityEngine;

public class MixingManager : MonoBehaviour
{
    // �����ı���
    public Vector4 correctProportions;

    // ����ͨ��Inspector���õ�ģ�ͺʹ�����Ϣ������
    public GameObject coffeeModel;
    public GameObject errorText;

    // Voice Control���������
    public GameObject voiceControlObject;

    public IngredientDetector ingredientDetector_esp;
    public IngredientDetector ingredientDetector_milk;
    public IngredientDetector ingredientDetector_milkfoam;
    public IngredientDetector ingredientDetector_water;

    private voiceMovement vm;

    public Camera arCamera;
    public int direction;

    void Start()
    {
        vm = voiceControlObject.GetComponent<voiceMovement>();
        if (vm == null)
        {
            Debug.LogError("VoiceMovement component not found on the voice control object!");
        }
    }

    void Update()
    {
        // ����Ƿ���ɻ��
        if (vm != null && vm.finish_mixing)
        {
            // ���ԭ�ϱ����Ƿ���ȷ
            CheckProportions();
            // ����finish_mixing��־�Է�ֹ�ظ����
            vm.finish_mixing = false;
        }
    }

    void CheckProportions()
    {
        // ���ԭ�ϱ����Ƿ����Ԥ���ı���
        bool isProportionCorrect =
            ingredientDetector_esp.espressoCount == correctProportions.x &&
            ingredientDetector_milk.milkCount == correctProportions.y &&
            ingredientDetector_milkfoam.milkfoamCount == correctProportions.z &&
            ingredientDetector_water.waterCount == correctProportions.w;

        // ��ʾ����ģ�ͻ������Ϣ
        coffeeModel.SetActive(isProportionCorrect);
        errorText.SetActive(!isProportionCorrect);
       
    }

}
