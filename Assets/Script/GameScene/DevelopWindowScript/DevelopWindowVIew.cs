using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class DevelopWindowVIew : MonoBehaviour
{
    public Slider Scrollbar;
    public DevelopWindowController controller;
    public DevelopWindowData data;
    public Text LBpointText;
    void Start()
    {
        Scrollbar.onValueChanged.AddListener(UpdateData);
    }
    private void UpdateData(float value)
    {
        data.lvlFinans =(int)value;
        controller.Obnova();
        UpdateText();
    }
    void UpdateText()
   {
        LBpointText.text = Convert.ToString(data.lvlFinans);
   }
}
