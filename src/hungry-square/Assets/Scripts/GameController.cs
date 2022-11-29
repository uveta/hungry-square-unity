using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject foodPrefab;

    private void Awake()
    {
        SpawnFood(foodPrefab);
    }

    public static void SpawnFood(GameObject foodPrefab)
    {
        var camera = Camera.main;
        var maxY = camera.orthographicSize;
        var maxX = maxY * camera.aspect;
        var position = new Vector2(Random.Range(-maxX, maxX), Random.Range(-maxY, maxY));
        Instantiate(foodPrefab, position, Quaternion.identity);
    }
}