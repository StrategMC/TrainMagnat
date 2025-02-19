using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocomotiewView : MonoBehaviour
{
    public LocomotiveData data;
    public GameObject Window;
    public Button CancelButton;
    public Button OpenButton;
    public Text nameText;
    public Text speedText;
    public Text powerText;
    public Text difficultText;
    public Transform LocContent;
    public GameObject PrefabLocomotiev;
    private void Start()
    {
        OpenButton.onClick.AddListener(Open);
        CancelButton.onClick.AddListener(Cancel);

    }
    public void Open()
    {
        Window.SetActive(true);
        View();
    }
    public void Cancel()
    {
        Window.SetActive(false);
    }

    public void View()
    {
        foreach (Transform child in LocContent)
        {
            Destroy(child.gameObject);
        }

        AddLayoutComponents(LocContent);

        for (int i = 0; i < data.locomotiews.Count; i++)
        {
            GameObject button = Instantiate(PrefabLocomotiev, LocContent);
            button.GetComponentInChildren<Text>().text = data.locomotiews[i].name;
            int index = i;
            button.GetComponent<Button>().onClick.AddListener(() => OnLocomotiewButtonClicked(data.locomotiews[index]));

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
    void OnLocomotiewButtonClicked(Locomotiew loco)
    {
        nameText.text = loco.name;
        speedText.text = $"{loco.speed}κμ/χ";
        powerText.text = $"{loco.power}λ.ρ.";
        difficultText.text = $"{loco.cost}σ.e.";

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
