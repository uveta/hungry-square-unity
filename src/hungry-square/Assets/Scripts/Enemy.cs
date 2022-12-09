using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Collider2D _collider2D;

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

    private void OnCollisionExit2D(Collision2D col)
    {
        if (!col.collider.CompareTag("MainCamera")) return;
        // var velocity = _rigidbody2D.velocity;
        // var bounds = _collider2D.bounds;
        // var moveX = Mathf.Abs(Time.fixedDeltaTime * velocity.x);
        // var moveY = Mathf.Abs(Time.fixedDeltaTime * velocity.y);
        // if (moveX < bounds.extents.x && moveY < bounds.extents.y)
        // {
        //     var increase = velocity.magnitude * 0.1f;
        //     _initialForce.x += increase;
        //     _initialForce.y += increase;
        //     _rigidbody2D.AddForce(velocity.normalized * increase, ForceMode2D.Impulse);
        // }
    }

    public static void Spawn()
    {
        var camera = Camera.main;
        var maxY = camera.orthographicSize;
        var maxX = maxY * camera.aspect;
        var position = new Vector2(Random.Range(-maxX, maxX), Random.Range(-maxY, maxY));
        Instantiate(PrefabRegistry.EnemyPrefab, position, Quaternion.identity);
    }
}