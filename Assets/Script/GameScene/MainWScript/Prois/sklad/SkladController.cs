using UnityEngine;

public class SkladController : MonoBehaviour
{
    public SkladData skladData;
    public void MinusPoezda(Locomotiew loco, int count)
    {
        for (int i = 0; i < skladData.lovomotivy.Count; i++)
        {
            if (skladData.lovomotivy.ContainsKey(loco))
            {
                skladData.lovomotivy[loco] -= count;
                if (skladData.lovomotivy[loco] == 0)
                {
                    skladData.lovomotivy.Remove(loco);
                }
            }
        }
    }
}
