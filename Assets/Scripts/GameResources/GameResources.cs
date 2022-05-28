using UnityEngine;

public class GameResources : MonoBehaviour
{
    public GameObject resourcePrefab;

    public GameResourcesTypes gameResourcesTypes;

    public float spawnTime;

    public float speed;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    private float[] rightOrLeft = { 1f, -1f };

    void Start()
    {
        spawnTime = 1.0f;
        speed = 6.0f;

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        MoveAround();
    }

    void Update()
    {
        if (transform.position.x < -screenBounds.x * 1.2 || transform.position.x > screenBounds.x * 1.2)
        {
            Destroy(this.gameObject);
        }
    }


    public void MoveAround()
    {
        speed = Random.Range(3.0f, 10.0f);
        rb = this.GetComponent<Rigidbody2D>();

        if (transform.position.x > 0)
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        else if (transform.position.x < 0)
        {
            rb.velocity = new Vector2(speed, 0);
        }
    }

    /*
    public void DestroyResource()
    {
        // destroy resource either in house or pick up from street

        Destroy(this.gameObject);
    }

    public void PlaceInHouse()
    {
        //placing the object in either house by the player
    }
    */


    public enum GameResourcesTypes
    {
        Rat,
        Cat,
        Kid
    }

}
