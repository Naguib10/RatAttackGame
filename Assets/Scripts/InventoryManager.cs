using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{

    #region Singleton
    public static InventoryManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of InventoryManager found!");
            return;
        }

        instance = this;

        DontDestroyOnLoad(gameObject);// not delete data
    }
    #endregion

    //public bool isPaused;

    [SerializeField] PlayerActions playerActions;
    [SerializeField] GameManager gameManager;

    public List<Resource> resources = new List<Resource>(); // which type of resouse player has
    public List<int> resourceNumbers = new List<int>(); // how many resources player has
    public GameObject[] slots;

    //public Dictionary<Resource, int> resourceDictionary = new Dictionary<Resource, int>(); //

    private void Start()
    {
        DisplayResourcesInInventory();
    }


    public void DisplayResourcesInInventory()
    {
        #region
        for (int i = 0; i < resources.Count; i++)
        {
            ////Update slots resource image
            //slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
            //slots[i].transform.GetChild(0).GetComponent<Image>().sprite = resources[i].resourceSprite;

            ////Update slots resource text
            //slots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(1, 1, 1, 1);
            //slots[i].transform.GetChild(1).GetComponent<Text>().text = resourceNumbers[i].ToString();

            ////Update slots remove button image
            //slots[i].transform.GetChild(2).gameObject.SetActive(true);
        }
        #endregion

        // ignore the fact
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < resources.Count)
            {
                //Update slots resource image
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = resources[i].resourceSprite;

                //Update slots resource text
                slots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(1, 1, 1, 1);
                slots[i].transform.GetChild(1).GetComponent<Text>().text = resourceNumbers[i].ToString();

                //Update slots remove button image
                slots[i].transform.GetChild(2).gameObject.SetActive(true);
            }
            else // some remove resource
            {

                //Update slots resource image
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0);
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;

                //Update slots resource text
                slots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(1, 1, 1, 0);
                slots[i].transform.GetChild(1).GetComponent<Text>().text = null;

                //Update slots remove button image
                slots[i].transform.GetChild(2).gameObject.SetActive(false);
            }
        }
    }

    public void AddResourceIntoInventory(Resource resource)
    {
        if (!resources.Contains(resource)) //If there is one existing resource in list(resources)
        {
            resources.Add(resource);
            resourceNumbers.Add(1);//Add 1
        }
        else  //If there is a new resource in list(resources)
        {
            Debug.Log("You have already have this one");

            for (int i = 0; i < resources.Count; i++)
            {
                if (resource == resources[i])
                {
                    resourceNumbers[i]++;
                }
            }
        }

        DisplayResourcesInInventory();
    }

    public void RemoveResourceFromInventory(Resource resource)//Updated
    {
        if (resources.Contains(resource)) //If there is one existing resource in list(resources)
        {
            for (int i = 0; i < resources.Count; i++)
            {
                if (resource == resources[i])
                {
                    //resourceNumbers[i]--;


                    if (resources[i].resourceName == "Rat_I" && playerActions.ratCounter > 0 && resourceNumbers[i] > 0)//Rat_I
                    {
                        playerActions.ratCounter--;
                        gameManager.ratCounterText.text = "" + playerActions.ratCounter;

                        resourceNumbers[i]--;
                    }
                    else if (resources[i].resourceName == "Cat_I" && playerActions.catCounter > 0 && resourceNumbers[i] > 0)//Cat_I
                    {
                        playerActions.catCounter--;
                        gameManager.catCounterText.text = "" + playerActions.catCounter;

                        resourceNumbers[i]--;
                    }
                    else if (resources[i].resourceName == "Kid_I" && playerActions.kidCounter > 0 && resourceNumbers[i] > 0)//Kid_I
                    {
                        playerActions.kidCounter--;
                        gameManager.kidCounterText.text = "" + playerActions.kidCounter;

                        resourceNumbers[i]--;
                    }
                    else if (resourceNumbers[i] == 0)
                    {
                        // it needs to remove this
                        resources.Remove(resource);
                        resourceNumbers.Remove(resourceNumbers[i]);
                    }
                }
            }
        }
        else
        {
            Debug.Log("There is no " + resource + " in the list (resources)");
        }

        //If there is no resource in nventory
        DisplayResourcesInInventory();
    }

}
