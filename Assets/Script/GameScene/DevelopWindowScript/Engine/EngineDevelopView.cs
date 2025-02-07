using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EngineDevelopView : MonoBehaviour
{
    public EngineDevelopData data;
    public EngineDevelopController controller;
    public EngineDevelopReaserchesEngines engineDevelopReaserchesEngines;
    public InputField inputField;
    public Text sizeText;
    public Text powerText;
    public Text vesText;
    public Text difficultiesText;
    public Text timeText;
    public Text manyText;

    public Slider volumeSlider;
    public Text volumeText;
    public Slider materialSlider;
    public Text materialText;
    public Slider technologySlider;
    public Text technologyText;

    public GameObject Window;
    public Button CancelButton;
    public Button AgreeButton;
    private void Start()
    {
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
        materialSlider.onValueChanged.AddListener(ChangeMaterial);
        technologySlider.onValueChanged.AddListener(ChangeTechnology);
        CancelButton.onClick.AddListener(Cancel);
        AgreeButton.onClick.AddListener(Agree);
    }
    private void Agree()
    {
        if(inputField.text.Length>3)
        {
            engineDevelopReaserchesEngines.Vyzov(inputField.text, data.size, data.power, data.ves, data.difficulties, data.timeResearch);
            Window.SetActive(false);
        }
        else
        {
            Debug.Log("Название должно быть длинее 3 символов");
        }
    }
    private void Cancel()
    {
        Window.SetActive(false);
    }
    private void ChangeVolume(float value)
    {
        volumeText.text= value.ToString();
        data.volume=(int)value;
        controller.PodschetSvoistva();
    }
    private void ChangeMaterial(float value)
    {
        materialText.text = value.ToString();
        data.material = (int)value;
        controller.PodschetSvoistva();
    }
    private void ChangeTechnology(float value)
    {
        technologyText.text = value.ToString();
        data.technology = (int)value;
        controller.PodschetSvoistva();
    }
    public void ViewSvoistva()
    {
        string sizeS;
        switch (data.size)
        {
            case 1:
                sizeS = "A";
                data.size = 1;
                break;
            case 2:
                sizeS = "B";
                data.size = 2;
                break;
            case 3:
                sizeS = "C";
                data.size = 3;

                break;
            default:
                sizeS = "D";
                break;
        }
        sizeText.text = $"Размер: {sizeS}";
        powerText.text = $"Мощность: {data.power}л.с.";
        vesText.text = $"Вес: {data.ves}кг";
        difficultiesText.text = $"Сложность: {data.difficulties}у.е.";

        timeText.text = $"Требуется очков разработки: {data.timeResearch}";
        manyText.text = $"Стоимость разработки: {data.manyResearch}$";
    }
}
