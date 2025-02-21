using UnityEngine;

public class SkladController : MonoBehaviour
{
    public SkladData skladData;
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
