using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SelectChassis : MonoBehaviour
{
    public Text NameText;
    public Text SizeText;
    public Text KpdText;
    public Text VesText;
    public Text costText;

    public Button OpenButton;
    public Button CloseButton;

    public GameObject ChassisWindow;
    public GameObject WindowPanel;

    public SelectChassisView view;
    public SelectChassisData data;
    public SelectLocomotive locomotive;
    private void Start()
    {
        OpenButton.onClick.AddListener(OpenWindow);
    }
    private void OpenWindow()
    {
        ChassisWindow.SetActive(true);
        view.View();
    }
    private void CloseWindow()
    {
        ChassisWindow.SetActive(false);
    }
    public void SelectClick()
    {
        ChassisWindow.SetActive(false);
        WindowPanel.SetActive(true);
        EngineInfo();
        locomotive.cha = true;
        locomotive.View();
    }
    public void EngineInfo()
    {
        NameText.text = data.Name;
        SizeText.text = $"Место под двигатель: ";
        switch (data.Size)
        {
            case 1:
                SizeText.text += "A";
                break;
            case 2:
                SizeText.text += "B";
                break;
            case 3:
                SizeText.text += "C";
                break;
            default:
                SizeText.text += "D";
                break;
        }
        KpdText.text = $"Бонус КПД: {data.bonus}%";
        VesText.text = $"Вес: {data.Ves}кг";
        costText.text = $"Стоимость: {data.Different}у.е.";

    }
}
