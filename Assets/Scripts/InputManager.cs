using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    [SerializeField] PlayerActions playerActions;

    public GameObject clickedGameObject;
    public string whichChamber;

    public void ControlScheme() 
    {
        if (Input.GetMouseButtonDown(0))// When clicked Mouse-Left-Button
        {

            clickedGameObject = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast(ray.origin, ray.direction);// No need "(Vector2)" in front of ray

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
    }

}
