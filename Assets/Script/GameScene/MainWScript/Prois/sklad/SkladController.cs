using UnityEngine;

public class SkladController : MonoBehaviour
{
    public SkladData skladData;
    private void Awake()
    {
        if (PlayerPrefs.GetInt("Load") == 0)
        {
            skladData = new SkladData();
        }
    }
    public void MinusPoezda(Locomotiew loco, int count)
    {
        
            if (skladData.lovomotivy.ContainsKey(loco))
            {
                //Debug.Log("2");
                skladData.lovomotivy[loco] -= count;
                if (skladData.lovomotivy[loco] == 0)
                {
                   
                    skladData.lovomotivy.Remove(loco);
                }
            }
    }
    
}
