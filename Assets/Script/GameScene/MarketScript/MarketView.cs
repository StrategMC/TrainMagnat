using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MarketView : MonoBehaviour
{
    public Transform PredlogenieContent;
    public GameObject PredlogeniePrefab;
    public MarketData MarketData;
    public void PredlogenieView()
    {
        foreach (Transform child in PredlogenieContent)
        {
            Destroy(child.gameObject);
        }

        AddLayoutComponents(PredlogenieContent);

        foreach (var locomotive in MarketData.supplys)
        {
            GameObject button = Instantiate(PredlogeniePrefab, PredlogenieContent);
            Text[] texts = button.GetComponentsInChildren<Text>();
            texts[0].text = locomotive.CompanyName;
            texts[1].text = locomotive.loco.name;
            texts[2].text = locomotive.col + " ед.";
            texts[3].text = locomotive.cost + "$";
          


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
