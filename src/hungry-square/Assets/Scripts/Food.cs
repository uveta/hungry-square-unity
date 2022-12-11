using UnityEngine;

public class Food : MonoBehaviour
{
    public static void Spawn()
    {
        var position = new Vector2(0, 0);
        var food = Instantiate(PrefabRegistry.FoodPrefab, position, Quaternion.identity);
        var collider = food.GetComponent<Collider2D>();
        var bounds = collider.bounds;
        var camera = Camera.main;
        var maxY = camera.orthographicSize - bounds.extents.y;
        var maxX = maxY * camera.aspect - bounds.extents.x;
        position = new Vector2(Random.Range(-maxX, maxX), Random.Range(-maxY, maxY));
        food.transform.position = position;
    }
}