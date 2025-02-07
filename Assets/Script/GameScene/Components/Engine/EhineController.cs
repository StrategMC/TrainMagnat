using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EhineController : MonoBehaviour
{
    public EngineData data;

    void Start()
    {  
    }
    public void AddEngine(string name,int size,int power, int ves, int difficulties)
    {
         Engine engine = new Engine(name,size,power,ves,difficulties);
        data.engines.Add(engine);
    }
}
