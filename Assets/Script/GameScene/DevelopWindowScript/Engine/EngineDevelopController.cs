using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineDevelopController : MonoBehaviour
{
    public EngineDevelopData data;
    public EngineDevelopView view;
    public ReasearchBonus bonus;
    private void Start()
    {
        PodschetSvoistva();
        view.ViewSvoistva();
    }
    public void PodschetSvoistva()
    {
        // Расчет мощности
        data.power = 50;
        data.power += (int)(data.power * (bonus.PowerEngine / 100f));
        data.power += (int)(data.power * (data.volume * 10 / 100f));
        data.power += (int)(data.power * (data.technology * 10 / 100f));

        // Расчет веса
        data.ves = 1000;
        data.ves -= (int)(data.ves * (bonus.VesEngine / 100f));
        data.ves += (int)(data.ves * (data.volume * 10 / 100f));
        data.ves -= (int)(data.ves * (data.material * 10 / 100f));

        // Расчет размера
        switch (data.volume)
        {
            case 1:
            case 2:
                data.size = 1;
                break;
            case 3:
            case 4:
                data.size = 2;
                break;
            case 5:
            case 6:
                data.size = 3;
                break;
            default:
                data.size = 4;
                break;
        }

        // Расчет сложности
        data.difficulties = 100;
        data.difficulties += data.technology * 15;
        data.difficulties += data.material * 15;
        data.difficulties += (int)(data.material * (bonus.SlognostEngine * 5 / 100f));

        // Расчет времени и стоимости исследования
        data.timeResearch = 10;
        data.timeResearch += data.volume + data.material + data.technology;
        data.manyResearch = 10000;
        data.manyResearch += (data.volume + data.material + data.technology) * 1000;

        view.ViewSvoistva();

    }
}
