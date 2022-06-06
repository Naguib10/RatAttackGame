using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAgain : MonoBehaviour
{
    public void ResetScore()
    {
        DataManager.instance.playerRatPointResults.Clear();
        DataManager.instance.enemyRatPointResults.Clear();
        DataManager.instance.levels.Clear();

        DataManager.instance.playerRatPoint = 0;
        DataManager.instance.enemyRatPoint = 0;
        DataManager.instance.whichLevel = 0;
    }
}
