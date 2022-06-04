using UnityEngine;

public class InputManager : MonoBehaviour
{
    #region Singleton
    public static InputManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of InputManager found!");
            return;
        }

        instance = this;
    }
    #endregion


    [SerializeField] PlayerActions playerActions;

    public GameObject clickedGameObject;
    public string whichChamber;

    public bool isPaused;

    private int hKeyHitNumber;
    private int pKeyHitNumber;

    public void ControlScheme() 
    {
        if (!isPaused) 
        {
            if (Input.GetMouseButtonDown(0))// When clicked Mouse-Left-Button
            {

                clickedGameObject = null;

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit2d = Physics2D.Raycast(ray.origin, ray.direction);

                if (hit2d)
                {
                    clickedGameObject = hit2d.transform.gameObject;

                    if (clickedGameObject.tag == "GameResources")
                    {
                        playerActions.Collect();

                        Destroy(clickedGameObject);
                    }
                    else if (clickedGameObject.tag == "PlayerChamber" || clickedGameObject.tag == "EnemyChamber")
                    {
                        if (clickedGameObject.tag == "PlayerChamber")
                        {
                            whichChamber = "PlayerChamber";
                        }
                        else if (clickedGameObject.tag == "EnemyChamber")
                        {
                            whichChamber = "EnemyChamber";
                        }

                        playerActions.Throw();
                    }
                }
            }

            if (Input.GetMouseButtonDown(1)) // When clicked Mouse-Right-Button on game object, it show short discription.
            {
                clickedGameObject = null;

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit2d = Physics2D.Raycast(ray.origin, ray.direction);

                if (hit2d)
                {
                    clickedGameObject = hit2d.transform.gameObject;

                    switch (clickedGameObject.tag)
                    {
                        case "GameResources":
                            HelpMessageManager.instance.ShowShortHelp(1);
                            break;

                        case "RatCounter":
                            HelpMessageManager.instance.ShowShortHelp(2);
                            break;

                        case "CatCounter":
                            HelpMessageManager.instance.ShowShortHelp(3);
                            break;

                        case "KidCounter":
                            HelpMessageManager.instance.ShowShortHelp(4);
                            break;

                        case "Timer":
                            HelpMessageManager.instance.ShowShortHelp(5);
                            break;

                        case "PlayerHousesRatCounter":
                            HelpMessageManager.instance.ShowShortHelp(6);
                            break;

                        case "EnemyHousesRatCounter":
                            HelpMessageManager.instance.ShowShortHelp(7);
                            break;

                        case "PlayerChamber":
                            HelpMessageManager.instance.ShowShortHelp(8);
                            break;

                        case "EnemyChamber":
                            HelpMessageManager.instance.ShowShortHelp(9);
                            break;

                        default:
                            break;
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.H))// ShowHelp:How to Play
        {
            hKeyHitNumber++;

            if (hKeyHitNumber % 2 != 0) 
            {
                HelpMessageManager.instance.ToggleHelpMessageHowToPlay("Show");

                Time.timeScale = 0.0f; // time stop

                isPaused = true;//
            }
            else
            {
                HelpMessageManager.instance.ToggleHelpMessageHowToPlay("Hide");

                Time.timeScale = 1.0f; // real time is 1.0f

                isPaused = false;//
            }
        }
        else if (Input.GetKeyDown(KeyCode.P))// Pause gameplay
        {
            pKeyHitNumber ++;

            if (pKeyHitNumber % 2 != 0)
            {
                Time.timeScale = 0.0f; // time stop

                isPaused = true;//
            }
            else
            {
                Time.timeScale = 1.0f; // real time is 1.0f

                isPaused = false;//
            }
        }
        else if (Input.GetKeyDown(KeyCode.I))//Show Inventory
        {
            InventoryUIManager.instance.InventoryUIControl();
        }
    }
}
