using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectEngineView : MonoBehaviour
{

    public SelectEngineData engineData;
    public SelectEngine selectEngine;
    EngineData data;
    public EhineController controller;
    public Text nameText;
    public Text sizeText;
    public Text powerText;
    public Text vesText;
    public Text difficultText;
    public Transform EngContent;
    public GameObject PrefabEngine;
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
            string name = data.engines[indexSelect].name;
            int size = data.engines[indexSelect].size;
            int power = data.engines[indexSelect].power;
            int ves = data.engines[indexSelect].ves;
            int different = data.engines[indexSelect].difficulties;
            engineData.Inicialize(name, size, power, ves, different);
            selectEngine.SelectClick();
        }
    }
    public void View()
    {
        data= controller.data;
        foreach (Transform child in EngContent)
        {
            Destroy(child.gameObject);
        }

        AddLayoutComponents(EngContent);

        for (int i = 0; i < data.engines.Count; i++)
        {
            GameObject button = Instantiate(PrefabEngine, EngContent);
            button.GetComponentInChildren<Text>().text = data.engines[i].name;
            int index = i;
            button.GetComponent<Button>().onClick.AddListener(() => OnEngineButtonClicked(data.engines[index]));

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
    void OnEngineButtonClicked(Engine engine)
    {
        nameText.text = engine.name;
        sizeText.text = SizeEngineAdapter(engine.size);
        vesText.text = $"{engine.ves}Í„";
        powerText.text = $"{engine.power}Î.Ò.";
        difficultText.text = $"{engine.difficulties}";
        indexSelect = data.engines.IndexOf(engine);
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
