using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawningManager : MonoBehaviour
{
    public GameResources rat;
    public GameResources cat;
    public GameResources kid;

    Scene currentScene;

    public float spawnTime;
    private Vector2 screenBounds;

    private float[] rightOrLeft = { 1f, -1f };

    void Start()
    {
        spawnTime = 1.0f;

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        InvokeRepeating("Spawn", 0f, spawnTime);

        currentScene = SceneManager.GetActiveScene();
    }


    public void Spawn()
    {
        int randomResource = 1;

        if (currentScene.name == "Scene1")
        {
            randomResource = Random.Range(1, 2);
        }
        else if (currentScene.name == "Scene2")
        {
            randomResource = Random.Range(1, 3);
        }
        else if (currentScene.name == "Scene3")
        {
            randomResource = Random.Range(1, 4);
        }

        float startingSide = rightOrLeft[Random.Range(0, 2)];

        switch (randomResource) {
            case 1:
                Instantiate(rat, new Vector2(screenBounds.x * startingSide, Random.Range(-screenBounds.y * 0.7f, -screenBounds.y * 0.45f)), Quaternion.identity);
                break;
            case 2:
                Instantiate(cat, new Vector2(screenBounds.x * startingSide, Random.Range(-screenBounds.y * 0.7f, -screenBounds.y * 0.45f)), Quaternion.identity);
                break;
            case 3:
                Instantiate(kid, new Vector2(screenBounds.x * startingSide, Random.Range(-screenBounds.y * 0.7f, -screenBounds.y * 0.45f)), Quaternion.identity);
                break;
        }
    }

    public void CancelSpawn()
    {
        CancelInvoke("Spawn");
    }
}
