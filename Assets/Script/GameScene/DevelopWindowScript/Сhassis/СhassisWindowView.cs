using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.UI;

public class СhassisWindowView : MonoBehaviour
{
    public Slider placeSlider;
    public Slider placeEngineSlider;
    public Slider HodovaaSlider;
    public Slider TechnologySlider;
    public Text placeText;
    public Text placeEngineText;
    public Text hodovaaText;
    public Text technologyText;
    public СhassisWindowData data;
    private void Start()
    {
        placeSlider.onValueChanged.AddListener(ChangePlace);
        placeEngineSlider.onValueChanged.AddListener(ChangeEnginePlace);
        HodovaaSlider.onValueChanged.AddListener(ChangeHodovaa);
        TechnologySlider.onValueChanged.AddListener(ChangeTechnology);
    }
    void ChangePlace(float value)
    {
        data.place = (int)value;
        placeText.text=$"{data.place}";
    }
    void ChangeEnginePlace(float value)
    {
        data.placeE = (int)value;
        placeEngineText.text = $"{data.placeE}";
    }
    void ChangeHodovaa(float value)
    {
        data.hodovaa = (int)value;
        hodovaaText.text=$"{data.hodovaa}";
    }
    void ChangeTechnology(float value)
    {
        data.technologi = (int)value;
        technologyText.text=$"{data.technologi}";
    }
}
