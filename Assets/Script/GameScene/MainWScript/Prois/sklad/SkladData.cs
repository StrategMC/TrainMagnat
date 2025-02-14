using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkladData : MonoBehaviour
{
    public Dictionary<Locomotiew, int> lovomotivy;
    private void Start()
    {
        lovomotivy=new Dictionary<Locomotiew, int>();
    }
}
