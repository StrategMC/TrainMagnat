using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectChassisView : MonoBehaviour
{
    public SelectChassisData chassisData;
    public SelectChassis selectChassis;
    public ChassisData data;
    public Text nameText;
    public Text sizeText;
    public Text bonusText;
    public Text vesText;
    public Text difficultText;
    public Transform ChsContent;
    public GameObject PrefabChassis;
    public Button SelectButton;
    private int indexSelect;

    private void Start()
    {
        SelectButton.onClick.AddListener(SelectEngine);
    }
    public void SelectEngine()
    {
        if (nameText.text.Length >= 3)
        {
            string name = data.chassis[indexSelect].name;
            int size = data.chassis[indexSelect].size;
            int bonus = data.chassis[indexSelect].bonusKpd;
            int ves = data.chassis[indexSelect].ves;
            int different = data.chassis[indexSelect].difficult;
            chassisData.Inicialize(name, size, bonus, ves, different);
            selectChassis.SelectClick();
        }
    }
    public void View()
    {
        foreach (Transform child in ChsContent)
        {
            Destroy(child.gameObject);
        }

        AddLayoutComponents(ChsContent);

        for (int i = 0; i < data.chassis.Count; i++)
        {
            GameObject button = Instantiate(PrefabChassis, ChsContent);
            button.GetComponentInChildren<Text>().text = data.chassis[i].name;
            button.GetComponent<Button>().onClick.AddListener(() => OnChassisButtonClicked(data.chassis[i - 1]));

            if (i == 0)
            {
                Transform buttonTransform = button.transform.GetChild(0);
                if (buttonTransform != null && buttonTransform.name == "Button")
                {
                    Destroy(buttonTransform.gameObject);
                }
            }
        }

    }
    void OnChassisButtonClicked(Chassi chassi)
    {
        nameText.text = chassi.name;
        sizeText.text = $"Место под двигатель: {SizeChassisAdapter(chassi.size)}";
        vesText.text = $"Вес: {chassi.ves}кг";
        bonusText.text = $"Бонус КПД: {chassi.bonusKpd}%";
        difficultText.text = $"Сложность: {chassi.difficult}";
        indexSelect = data.chassis.IndexOf(chassi);
    }
    string SizeChassisAdapter(int size)
    {
        switch (size)
        {
            case 1:
                return "A";
            case 2:
                return "B";
            case 3:
                return "C";
            default:
                return "D";
        }
    }
    void AddLayoutComponents(Transform content)
    {
        if (content.gameObject.GetComponent<VerticalLayoutGroup>() == null)
        {
            VerticalLayoutGroup verticalLayoutGroup = content.gameObject.AddComponent<VerticalLayoutGroup>();
            verticalLayoutGroup.childAlignment = TextAnchor.UpperCenter;
            verticalLayoutGroup.spacing = 10;
            verticalLayoutGroup.padding = new RectOffset(10, 10, 10, 10);
            verticalLayoutGroup.childForceExpandWidth = true;
            verticalLayoutGroup.childForceExpandHeight = false;
        }

        if (content.gameObject.GetComponent<ContentSizeFitter>() == null)
        {
            ContentSizeFitter contentSizeFitter = content.gameObject.AddComponent<ContentSizeFitter>();
            contentSizeFitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
        }
    }
}
