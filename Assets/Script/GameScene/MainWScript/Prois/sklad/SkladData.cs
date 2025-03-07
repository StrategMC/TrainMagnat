using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkladData 
{
    public Dictionary<Locomotiew, int> lovomotivy;
    public SkladData()
    {
        lovomotivy = new Dictionary<Locomotiew, int>();
    }
}
