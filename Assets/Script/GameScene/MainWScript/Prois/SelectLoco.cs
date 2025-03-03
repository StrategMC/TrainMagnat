using GlobalGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SelectLoco : MonoBehaviour
{
    public ProisData proisData;
    public Text SelectText;
    public LocomotiveController locomotiveController;
    public Button openButton;
    public Button closeButton;
    public GameObject SelectWindows;
    public TimeController time;
    public Transform LocContent;
    public GameObject PrefabLocomotiev;

    public Text NameText;
    public Text SpeedText;
    public Text PowerText;
    public Text CostText;
    void Start()
    {
        openButton.onClick.AddListener(Open);
        closeButton.onClick.AddListener(Close);
    }
    void Open()
    {
        View();
        time.Pause();
        SelectWindows.SetActive(true);
    }
    void Close()
    {
        SelectWindows.SetActive(false);
    }
    void OnLocomotiewButtonClicked(Locomotiew loco)
    {
        SelectText.text = loco.name;
        proisData.locomotiew=loco;

        NameText.text = loco.name;
        SpeedText.text = loco.speed + "κμ/χ";
        PowerText.text = loco.power + "λ.ρ.";
        CostText.text = loco.cost + "σε";
    }
    public void View()
    {
        var data = locomotiveController.data;
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
