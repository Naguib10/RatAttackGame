using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    InputManager inputManager;
    EnemyBehaviors enemyBehaviors;
    
    public int ratCounter = 0;
    public int catCounter = 0;
    public int kidCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(enemyBehaviors.EnemyBehaviors());
    }

    // Update is called once per frame
    void Update()
    {
        inputManager.ControlScheme();//Moved to GameManager 

        CountDown();//Moved to GameManager
    }
}
