using UnityEngine;

public class Food : MonoBehaviour
{
    public static void Spawn()
    {
        var camera = Camera.main;
        var maxY = camera.orthographicSize;
        var maxX = maxY * camera.aspect;
        var position = new Vector2(Random.Range(-maxX, maxX), Random.Range(-maxY, maxY));
        Instantiate(PrefabRegistry.FoodPrefab, position, Quaternion.identity);
    }
}