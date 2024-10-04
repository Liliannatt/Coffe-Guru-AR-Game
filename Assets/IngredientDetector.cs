using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Vuforia; // ȷ������Vuforia�����ռ�

public class IngredientDetector : MonoBehaviour
{
    public Text ingredientCountText; // UI Text�������
    private Dictionary<string, int> ingredientCounts = new Dictionary<string, int>(); // �洢ÿ��ԭ�ϵ�����

    public int espressoCount;
    public int milkCount;
    public int milkfoamCount;
    public int waterCount;

    // �ο��� ObjectDetectionManager ���
    public ObjectDetectionManager objectDetectionManager;

    void Start()
    {
        // �����¼�
        objectDetectionManager.OnObjectDetected += UpdateIngredientCount;
    }

    void UpdateIngredientCount(string ingredientName)
    {
        // ����ֵ��в����������Ʒ�ļ�¼���������
        if (!ingredientCounts.ContainsKey(ingredientName))
        {
            ingredientCounts[ingredientName] = 0;
        }
        // ������Ʒ�ļ���
        ingredientCounts[ingredientName]++;

        if (ingredientName == "QR_espresso")
        {
            espressoCount = ingredientCounts[ingredientName];
        }
        else if (ingredientName == "QR_water")
        {
            waterCount = ingredientCounts[ingredientName];
        }
        else if (ingredientName == "QR_milkfoam")
        {
            milkfoamCount = ingredientCounts[ingredientName];
        }
        else if (ingredientName == "QR_milk")
        {
            milkCount = ingredientCounts[ingredientName];
        }

        // ����UI
        UpdateIngredientText();
        
    }

    void UpdateIngredientText()
    {
        ingredientCountText.text = "";
        foreach (var ingredient in ingredientCounts)
        {
            ingredientCountText.text += ingredient.Key + ": " + ingredient.Value + "\n";
        }
    }

    void OnDestroy()
    {
        // ȡ�������¼�
        
        if (objectDetectionManager != null)
        {
            objectDetectionManager.OnObjectDetected -= UpdateIngredientCount;
        }
        
    }
}
