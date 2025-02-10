using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChassisView : MonoBehaviour
{
    public ChassisData data;
    public GameObject Window;
    public Button CancelButton;
    public Text nameText;
    public Text sizeText;
    public Text kpdText;
    public Text vesText;
    public Text difficultText;
    public Transform ChaContent;
    public GameObject PrefabChassi;
    private void Start()
    {
        CancelButton.onClick.AddListener(Cancel);
    }
    public void Cancel()
    {
        Window.SetActive(false);
    }
    public void View()
    {
        foreach (Transform child in ChaContent)
        {
            Destroy(child.gameObject);
        }

        AddLayoutComponents(ChaContent);

        for (int i = 0; i < data.chassis.Count; i++)
        {
            GameObject button = Instantiate(PrefabChassi, ChaContent);
            button.GetComponentInChildren<Text>().text = data.chassis[i].name;
            button.GetComponent<Button>().onClick.AddListener(() => OnChassiButtonClicked(data.chassis[i - 1]));

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
    void OnChassiButtonClicked(Chassi chassi)
    {
        nameText.text = chassi.name;
        sizeText.text = SizeEngineAdapter(chassi.size);
        vesText.text = $"{chassi.ves}Í„";
        kpdText.text = $"{chassi.bonusKpd}%";
        difficultText.text = $"{chassi.difficult}";
    }
    string SizeEngineAdapter(int size)
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
