using GlabalGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResearchView : MonoBehaviour
{
    public Text BonusText;
    public GameObject PrefabResearch;
    public GameObject NoResScrollView;
    public Transform NoResContent;
    public GameObject ResScrollView;
    public Transform ResContent;
    public ReasearchData data;
    public ReasearchBonus bonus;
    public ResearchController researchController;
    public void ViewBonus()
    {
        BonusText.text = "";
        BonusText.text += "�������� +" + bonus.PowerEngine + "%" +"\n";
        BonusText.text += "��� ����� +" + bonus.KPDShasi + "%" + "\n";
        BonusText.text += "��� ����� -" + bonus.VesShasi + "%" + "\n";
        BonusText.text += "��� ��������� -" + bonus.VesEngine + "%" + "\n";
        BonusText.text += "��������� ��������� +" + bonus.SlognostEngine + "%" + "\n";
        BonusText.text += "�������� ����� +" + bonus.SlognostShasi + "%" + "\n";
    }
    public void View()
    {
        foreach (Transform child in NoResContent)
        {
            Destroy(child.gameObject);
        }

        AddLayoutComponents(NoResContent);

        Debug.Log($"���������� {data.technologys.Count}");

        for (int i = 0; i < data.technologys.Count; i++)
        {
            GameObject button = Instantiate(PrefabResearch, NoResContent);
            button.GetComponentInChildren<Text>().text = data.technologys[i].name;

            // ���������� ����������� ������� ��� ������
            Button btn = button.GetComponentInChildren<Button>();
            int index = i; // ��������� ����� ���������� ��� ���������
            btn.onClick.AddListener(() => researchController.MoveUp(index));

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

    public void View2()
    {
        foreach (Transform child in ResContent)
        {
            Destroy(child.gameObject);
        }

        AddLayoutComponents(ResContent);

        Debug.Log($"���������� {data.Redytechnologys.Count}");

        for (int i = data.Redytechnologys.Count - 1; i > -1; i--)
        {
            GameObject button = Instantiate(PrefabResearch, ResContent);
            button.GetComponentInChildren<Text>().text = data.Redytechnologys[i].name;

            Transform buttonTransform = button.transform.GetChild(0);
            if (buttonTransform != null && buttonTransform.name == "Button")
            {
                Destroy(buttonTransform.gameObject);
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
