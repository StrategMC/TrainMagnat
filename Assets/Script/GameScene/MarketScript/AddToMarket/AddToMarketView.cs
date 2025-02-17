using GlobalGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AddToMarketView : MonoBehaviour
{
    public TimeController time;
    public SkladData skladData;
    public Button OpenButton;
    public Button CloseButton;
    public Button SelectButton;
    public GameObject Window;
    public Transform LocoContent;
    public GameObject LocoContentPrefab;
    public Text LocoNameText;
    public Text LocoSpeedText;
    public Text LocoPowerText;
    public Text LocoCostText;
    public InputField InputCol;
    public InputField InputCost;
    public AddToMarketController addToMarketController;
    private Locomotiew selectLoco;
    private int selectLocoCount;
    private void Start()
    {
        OpenButton.onClick.AddListener(Open);
        CloseButton.onClick.AddListener(Close);
        SelectButton.onClick.AddListener(Select);
    }

    private void Select()
    {
        if (int.Parse(InputCol.text)<=selectLocoCount && int.Parse(InputCost.text)>0)
        {
            addToMarketController.AddToMarket(selectLoco, int.Parse(InputCost.text), int.Parse(InputCol.text));
            Close();
            
        }
        else
        {
           // Debug.Log("");
        }
        
    }
    void Open ()
    {
        time.Pause();
        Window.SetActive(true);
        View();
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

        foreach (var locomotive in skladData.lovomotivy)
        {
            GameObject button = Instantiate(LocoContentPrefab, LocoContent);
            Text[] texts = button.GetComponentsInChildren<Text>();
            texts[0].text = locomotive.Key.name;
            texts[1].text = locomotive.Value + " εδ.";
            button.GetComponent<Button>().onClick.AddListener(() => OnLocomotiewButtonClicked(locomotive.Key,locomotive.Value));


        }

    }
    void OnLocomotiewButtonClicked(Locomotiew loco, int count)
    {
        selectLoco = loco;
        selectLocoCount = count;

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