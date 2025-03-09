using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlabalGame
{
    public class MoneyController : MonoBehaviour
    {
        public MoneyData Money;
        public MoneyView View;
        private void Awake()
        {
            if (PlayerPrefs.GetInt("Load") == 0)
            {
                Money = new MoneyData();
                Money.money = 300000;
            }

            View.Vyvod();
        }
        public void AddMany(int bablo)
        {
            Money.money += bablo;
            View.Vyvod();
        }
        public void RemoveMany(int bablo)
        {
            Money.money -= bablo;
            View.Vyvod();
        }

    }

}