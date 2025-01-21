using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlabalGame
{
    public class MoneyController : MonoBehaviour
    {
        public MoneyData Money;
        public MoneyView View;
        private void Start()
        {
            View.Vyvod();
        }
        void AddMany(int bablo)
        {
            Money.money += bablo;
            View.Vyvod();
        }
        void RemoveMany(int bablo)
        {
            Money.money -= bablo;
            View.Vyvod();
        }

    }

}