using UnityEngine;

public class StartScreenManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        BgmManager.instance.ManageBGM("Play", 0);
    }
}
