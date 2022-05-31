using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveResourceFromInventoryButton : MonoBehaviour
{

    public int buttonID;
    private Resource thisResource;

    private Resource GetThisResource() 
    {
        for (int i = 0; i < InventoryManager.instance.resources.Count; i++) 
        {
            if (buttonID == i) 
            {
                thisResource = InventoryManager.instance.resources[i];
            }
        }

        return thisResource;
    }

    public void CloseButton() 
    {
        InventoryManager.instance.RemoveResourceFromInventory(GetThisResource());
    }

}
