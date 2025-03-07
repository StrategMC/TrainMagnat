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
    private DevelopWindowData data;
    public Text LBpointText;

    public Button DevelopEngButton;
    public GameObject DevelopEngine;
    public EngineDevelopController EngineDevelopController;

    public Button ViewEngineButton;
    public GameObject ViewEngineWindow;
    public EngineView ViewEngine;

    public Button DevelopShButton;
    public GameObject DevelopChassi;
    public ÑhassisWindowController ÑhassisWindowController;

    public Button ViewChassiButton;
    public GameObject ViewChassiWindow;
    public ChassisView ViewChassi;


    void Start()
    {
        data=controller.data;
        Scrollbar.onValueChanged.AddListener(UpdateData);
        DevelopEngButton.onClick.AddListener(DEB);
        ViewEngineButton.onClick.AddListener(VEB);
        DevelopShButton.onClick.AddListener(DCB);
        ViewChassiButton.onClick.AddListener(VCB);
         
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
    private void DCB()
    {
        DevelopChassi.SetActive(true);
        TimeController.Pause();
        ÑhassisWindowController.Start();
    }
    private void VCB()
    {
        ViewChassiWindow.gameObject.SetActive(true);
        TimeController.Pause();
        ViewChassi.View();

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
