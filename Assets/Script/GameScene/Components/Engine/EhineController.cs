using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EhineController : MonoBehaviour
{
    public EngineData data;

    void Awake()
    {
        if (PlayerPrefs.GetInt("Load") == 0)
        {
            data = new EngineData();
        }
    }
    public void AddEngine(string name,int size,int power, int ves, int difficulties)
    {
         Engine engine = new Engine(name,size,power,ves,difficulties);
        data.engines.Add(engine);
    }
}
