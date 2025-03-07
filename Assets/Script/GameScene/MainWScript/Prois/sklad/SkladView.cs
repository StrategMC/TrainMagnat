using GlobalGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkladView : MonoBehaviour
{
    public SkladController SkladController;
    public Button OpenButton;
    public Button CloseButton;
    public GameObject Window;
    public GameObject LocoPrefab;
    public Transform LocoContent;
    public Text LocoNameText;
    public Text LocoSpeedText;
    public Text LocoPowerText;
    public Text LocoCostText;
    public TimeController time;
    private void Start()
    {
        OpenButton.onClick.AddListener(Open);
        CloseButton.onClick.AddListener(Close);
    }
    void Open()
    {
        View();
        time.Pause();
        Window.SetActive(true);
    }
    void Close()
    {
        Window.SetActive(false);
    }
    public void View()
    {
        foreach (Transform child in LocoContent)
        {
            Destroy(child.gameObject);
        }

        AddLayoutComponents(LocoContent);

        foreach(var locomotive in SkladController.skladData.lovomotivy)
        {
            GameObject button = Instantiate(LocoPrefab, LocoContent);
            Text[] texts = button.GetComponentsInChildren<Text>();
            texts[0].text= locomotive.Key.name;
            texts[1].text = locomotive.Value+" εδ.";
            var loco = locomotive.Key;
            button.GetComponent<Button>().onClick.AddListener(() => OnLocomotiewButtonClicked(loco));

           
        }

    }
    void OnLocomotiewButtonClicked(Locomotiew loco)
    {
        LocoNameText.text = loco.name;
        LocoSpeedText.text = $"{loco.speed}κμ/χ";
        LocoPowerText.text = $"{loco.power}λ.ρ.";
        LocoCostText.text = $"{loco.cost}σ.e.";

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
