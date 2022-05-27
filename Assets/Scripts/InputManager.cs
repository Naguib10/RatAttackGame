using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] PlayerActions playerActions;

    public GameObject clickedGameObject;
    public string whichChamber;

    private int hKeyHitNumber;

    public void ControlScheme() 
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

        if (Input.GetMouseButtonDown(1)) // When clicked Mouse-Right-Button
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

        if (Input.GetKeyDown(KeyCode.H))
        {
            hKeyHitNumber++;

            if (hKeyHitNumber % 2 != 0) 
            {
                HelpMessageManager.instance.ToggleHelpMessageHowToPlay("Show");// ShowHelp:How to Play

                //UnityEditor.EditorApplication.isPaused = true; // Pause current gameplay
            }
            else
            {
                HelpMessageManager.instance.ToggleHelpMessageHowToPlay("Hide");

                //UnityEditor.EditorApplication.isPaused = false;
                //UnityEditor.EditorApplication.isPlaying = true;
            }
        }
    }
}
