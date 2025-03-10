using GlabalGame;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace GlobalGame
{
    
    public class TimeController : MonoBehaviour
    {
        public FinanseView finanseView;
        public GameOverController gameOverController;
        public MoneyController MoneyController;
        public TimeData Time;
        public VieTime TimeView;
        public ProgressBarController TimeProgressBar;
        public Button PauseButton;
        public Button PlayButton;
        public Button FastButton;

        private List<IWeeklyUpdate> weeklyUpdateObjects;
        private List<IYearsUpdate> yearsUpdateObjects;

        void Awake()
        {
            if (PlayerPrefs.GetInt("Load") == 0)
            {
                Time = new TimeData();
                Time.year = 1829;
                Time.month = 1;
                Time.week = 1;
                Time.dayProgress = 0;
                Time.timeScale = 0f;
            }

            PauseButton.onClick.AddListener(Pause);
            PlayButton.onClick.AddListener(Play);
            FastButton.onClick.AddListener(Fast);

            weeklyUpdateObjects = new List<IWeeklyUpdate>(FindObjectsOfType<MonoBehaviour>().OfType<IWeeklyUpdate>());
            yearsUpdateObjects = new List<IYearsUpdate>(FindObjectsOfType<MonoBehaviour>().OfType<IYearsUpdate>());
           
        }

       public void Pause()
        {
            Time.timeScale = 0.0f;
        }

        void Play()
        {
            Time.timeScale = 1.5f;
        }

        void Fast()
        {
            Time.timeScale = 3.0f;
        }

        void Update()
        {
          
            if (Time.timeScale > 0)
            {
                Time.dayProgress += UnityEngine.Time.deltaTime * Time.timeScale;
                TimeView.View(Time);
                TimeProgressBar.View(Time);
                if (Time.dayProgress >= 7.0f)
                {
                    Time.dayProgress = 0;
                    Time.week++;

                    
                    weeklyUpdateObjects = new List<IWeeklyUpdate>(FindObjectsOfType<MonoBehaviour>().OfType<IWeeklyUpdate>());
                    foreach (var weeklyUpdateObject in weeklyUpdateObjects)
                    {
                        if(MoneyController.Money.money<=0)
                        {
                            gameOverController.Over();
                            Pause();
                        }
                        weeklyUpdateObject.WeekTick();
                    }
                    finanseView.View();
                    if (Time.week > 4)
                    {
                        Time.week = 1;
                        Time.month++;

                        if (Time.month > 12)
                        {
                            Time.month = 1;
                            Time.year++;

                           
                            yearsUpdateObjects = new List<IYearsUpdate>(FindObjectsOfType<MonoBehaviour>().OfType<IYearsUpdate>());
                            foreach (var yearsUpdateObject in yearsUpdateObjects)
                            {
                                yearsUpdateObject.YearsTick();
                            }
                        }
                    }
                }
            }
        }
    }
}
