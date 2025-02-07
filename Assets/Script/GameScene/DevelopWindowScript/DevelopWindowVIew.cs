using GlobalGame;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class DevelopWindowVIew : MonoBehaviour
{
    public TimeController TimeController;
    public Slider Scrollbar;
    public DevelopWindowController controller;
    public DevelopWindowData data;
    public Text LBpointText;

    public Button DevelopEngButton;
    public GameObject DevelopEngine;
    public EngineDevelopController EngineDevelopController;

    public Button ViewEngineButton;
    public GameObject ViewEngineWindow;
    public EngineView ViewEngine;
    void Start()
    {
        Scrollbar.onValueChanged.AddListener(UpdateData);
        DevelopEngButton.onClick.AddListener(DEB);
        ViewEngineButton.onClick.AddListener(VEB);
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
    private void DEB()
    {
        DevelopEngine.gameObject.SetActive(true);
        TimeController.Pause();
        EngineDevelopController.Start();
    }
    private void VEB()
    {
        ViewEngineWindow.gameObject.SetActive(true);
        TimeController.Pause();
        ViewEngine.View();
    }
}
