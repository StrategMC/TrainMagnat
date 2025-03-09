using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class MarketView : MonoBehaviour
{
    //public AddToMarketController AddToMarketController;
    public Transform PredlogenieContent;
    public GameObject PredlogeniePrefab;
    public Transform DemandContent;
    public GameObject DemandPrefab;
    public DemandController DemandController;
    //private void Start()
    //{
    //    DemandView();
    //    PredlogenieView();
    //}
    public void PredlogenieView()
    {
        foreach (Transform child in PredlogenieContent)
        {
            Destroy(child.gameObject);
        }

        AddLayoutComponents(PredlogenieContent);

        for (int i= 0; i< DemandController.MarketData.supplys.Count;i++)
        {
            GameObject button = Instantiate(PredlogeniePrefab, PredlogenieContent);
            Text[] texts = button.GetComponentsInChildren<Text>();
            texts[0].text = DemandController.MarketData.supplys[i].CompanyName;
            texts[1].text = DemandController.MarketData.supplys[i].loco.name;
            texts[2].text = DemandController.MarketData.supplys[i].col + " ед.";
            texts[3].text = DemandController.MarketData.supplys[i].cost + "$";
            //Button btn = button.GetComponentInChildren<Button>();
            //int index = i;
            //btn.onClick.AddListener(() => ChangePrice(index));
         }
    }
    public void LastPredlogenieView()
    {
        foreach (Transform child in PredlogenieContent)
        {
            Destroy(child.gameObject);
        }

        AddLayoutComponents(PredlogenieContent);

        for (int i = 0; i < DemandController.MarketData.Lastsupplys.Count; i++)
        {
            GameObject button = Instantiate(PredlogeniePrefab, PredlogenieContent);
            Text[] texts = button.GetComponentsInChildren<Text>();
            texts[0].text = DemandController.MarketData.Lastsupplys[i].CompanyName;
            texts[1].text = DemandController.MarketData.Lastsupplys[i].loco.name;
            texts[2].text = DemandController.MarketData.Lastsupplys[i].col + " ед.";
            texts[3].text = DemandController.MarketData.Lastsupplys[i].cost + "$";
            //Button btn = button.GetComponentInChildren<Button>();
            //int index = i;
            //btn.onClick.AddListener(() => ChangePrice(index));
        }
    }
    public void DemandView()
    {
        foreach (Transform child in DemandContent)
        {
            Destroy(child.gameObject);
        }

        AddLayoutComponents(DemandContent);

        for (int i = 0; i < DemandController.MarketData.demands.Count; i++)
        {
            GameObject button = Instantiate(DemandPrefab, DemandContent);
            Text[] texts = button.GetComponentsInChildren<Text>();
            texts[0].text = DemandController.MarketData.demands[i].line.Name;
            texts[1].text =  $"Нужно: {DemandController.MarketData.demands[i].col.ToString()}ед.";
        }
    }
    public void LastDemandView()
    {
        foreach (Transform child in DemandContent)
        {
            Destroy(child.gameObject);
        }

        AddLayoutComponents(DemandContent);

        for (int i = 0; i < DemandController.MarketData.Lastsdemands.Count; i++)
        {
            GameObject button = Instantiate(DemandPrefab, DemandContent);
            Text[] texts = button.GetComponentsInChildren<Text>();
            texts[0].text = DemandController.MarketData.Lastsdemands[i].line.Name;
            texts[1].text = $"Нужно: {DemandController.MarketData.Lastsdemands[i].col.ToString()}ед.";
        }
    }
    //void ChangePrice(int index)
    //{

    //}
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
