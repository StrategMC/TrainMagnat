using GlabalGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class MoneyView : MonoBehaviour
{
    public Text TextMoney;
    public MoneyData Money;
   
    public void Vyvod()
    {
        TextMoney.text = Preobrazovanie(Money.money);
    }
    public string Preobrazovanie(int amount)
    {
        if (amount >= 1000000000) 
        { 
            return (amount / 1000000000f).ToString("0.##") + "B"; 
        } 
        else if (amount >= 1000000) 
        {
            return (amount / 1000000f).ToString("0.##") + "M"; 
        }
        else if (amount >= 1000) 
        { 
            return (amount / 1000f).ToString("0.##") + "K";
        } 
        else { return amount.ToString(); }
    }
}
