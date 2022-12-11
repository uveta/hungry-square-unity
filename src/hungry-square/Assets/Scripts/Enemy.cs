using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Collider2D _collider2D;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<Collider2D>();
    }

    private void Start()
    {
        var gameSpeed = FindObjectOfType<GameController>().GameSpeed;
        var velocity = Mathf.Sqrt(gameSpeed);
        var bounds = _collider2D.bounds;
        var maxVelocity = Mathf.Min(bounds.extents.x, bounds.extents.y) / Time.fixedDeltaTime;
        velocity = Mathf.Min(velocity, maxVelocity);
        var initialForce = new Vector2(velocity, velocity);
        _rigidbody2D.AddForce(initialForce, ForceMode2D.Impulse);
    }

    public static void Spawn(Vector2 playerPosition)
    {
        var position = new Vector2(-playerPosition.x, -playerPosition.y);
        Instantiate(PrefabRegistry.EnemyPrefab, position, Quaternion.identity);
    }
}