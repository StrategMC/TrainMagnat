using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EngineDevelopView : MonoBehaviour
{
    public EngineDevelopData data;
    public EngineDevelopController controller;
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
    private void Start()
    {
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
        materialSlider.onValueChanged.AddListener(ChangeMaterial);
        technologySlider.onValueChanged.AddListener(ChangeTechnology);
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

        timeText.text = $"Время разработки(при бонусе 0): {data.timeResearch} недель";
        manyText.text = $"Стоимость разработки: {data.manyResearch}$";
    }
}
