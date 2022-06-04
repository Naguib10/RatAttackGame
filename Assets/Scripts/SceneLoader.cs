using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        Destroy(InputManager.instance);
        Destroy(InventoryManager.instance);
        Destroy(InventoryUIManager.instance);
        SceneManager.LoadScene(sceneName);
    }
}
