using GlabalGame;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.UI;

public class СhassisWindowView : MonoBehaviour
{
    public MoneyController MoneyController;
    public Slider placeSlider;
    public Slider placeEngineSlider;
    public Slider HodovaaSlider;
    public Slider TechnologySlider;
    public InputField inputField;
    public Text placeText;
    public Text placeEngineText;
    public Text hodovaaText;
    public Text technologyText;
    public СhassisWindowData data;
    public СhassisWindowController controller;

    public Text placeEText;
    public Text bonusText;
    public Text vesText;
    public Text differentText;

    public Text pointText;
    public Text moneyText;

    public GameObject Window;
    public Button AcceptButton;
    public Button CancelButton;

    public ChassisWindowReaserch ChassisWindowReaserch;
    private void Start()
    {
        placeSlider.onValueChanged.AddListener(ChangePlace);
        placeEngineSlider.onValueChanged.AddListener(ChangeEnginePlace);
        HodovaaSlider.onValueChanged.AddListener(ChangeHodovaa);
        TechnologySlider.onValueChanged.AddListener(ChangeTechnology);

        AcceptButton.onClick.AddListener(Acept);
        CancelButton.onClick.AddListener(Cancel);
    }
    void Cancel()
    {
       
        Window.SetActive(false);
    }
    void Acept()
    {
        if(inputField.text.Length>3)
        {
            ChassisWindowReaserch.Vyzov(inputField.text, data.placeEngine, data.bonusKPD, data.ves, data.difficult, data.point);
            Window.SetActive(false);
            MoneyController.RemoveMany(data.money);
        }
        else
        {
            Debug.Log("Название должно быть больше 3х симвалов");
        }
    }
    void ChangePlace(float value)
    {
        data.place = (int)value;
        placeText.text=$"{data.place}";
        controller.PodschetSvoistv();
    }
    void ChangeEnginePlace(float value)
    {
        data.placeE = (int)value;
        placeEngineText.text = $"{data.placeE}";
        controller.PodschetSvoistv();
    }
    void ChangeHodovaa(float value)
    {
        data.hodovaa = (int)value;
        hodovaaText.text=$"{data.hodovaa}";
        controller.PodschetSvoistv();
    }
    void ChangeTechnology(float value)
    {
        data.technologi = (int)value;
        technologyText.text=$"{data.technologi}";
        controller.PodschetSvoistv();

    }
    public void ViewSvoistva()
    {
        placeEText.text = "Место под двигатель: ";
        switch (data.placeEngine)
        {
            case 1:
                placeEText.text += "A";break;
            case 2: 
                placeEText.text += "B";break;
            case 3: 
                placeEText.text += "C";break;
            default:
                placeEText.text += "D";break;
        }
        bonusText.text = $"Бонус: {data.bonusKPD}%";
        vesText.text = $"Вес: {data.ves}кг";
        differentText.text = $"Сложность: {data.difficult}у.е";

        pointText.text = $"Время разработки: {data.point}";
        moneyText.text = $"Требуется очков разработки: {data.money}";
    }
}
