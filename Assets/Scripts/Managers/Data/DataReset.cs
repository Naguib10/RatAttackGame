using UnityEngine;

public class DataReset : MonoBehaviour
{
    public void ResetScore()
    {
        DataManager.instance.playerRatPointResults.Clear();
        DataManager.instance.enemyRatPointResults.Clear();
        DataManager.instance.levels.Clear();

        DataManager.instance.playerRatPoint = 0;
        DataManager.instance.enemyRatPoint = 0;
        DataManager.instance.whichLevel = 0;

        BgmManager.instance.ManageBGM("Stop", 0);
    }
}
