using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SelectEngine : MonoBehaviour
{
    public Text NameText;
    public Text SizeText;
    public Text PowerText;
    public Text VesText;
    public Text costText;

    public Button OpenButton;
    public Button CloseButton;

    public GameObject EngineWindow;
    public GameObject EnginePanel;

    public SelectEngineView view;
    public SelectEngineData data;
    public SelectLocomotive locomotive;
    private void Start()
    {
        OpenButton.onClick.AddListener(OpenWindow);
    }
    private void OpenWindow()
    {
        EngineWindow.SetActive(true);
        view.View();
    }
    private void CloseWindow()
    {
        EngineWindow.SetActive(false);
    }
    public void SelectClick()
    {
        EngineWindow.SetActive(false);
        EnginePanel.SetActive(true);
        EngineInfo();
        locomotive.eng = true;
        locomotive.View();
    }
    public void EngineInfo()
    {
        NameText.text = data.Name;
        SizeText.text = $"Размер: ";
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
        PowerText.text = $"Мощность: {data.Power}л.с.";
        VesText.text = $"Вес: {data.Ves}кг";
        costText.text = $"Стоимость: {data.Different}у.е.";

    }
}
