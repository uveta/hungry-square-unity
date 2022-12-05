using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Collider2D _collider2D;
    private Vector2 _initialForce = new(4f, 4f);

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<Collider2D>();
    }

    private void Start()
    {
        _rigidbody2D.AddForce(_initialForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        // TODO: check collision with player?
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        var velocity = _rigidbody2D.velocity;
        var bounds = _collider2D.bounds;
        var moveX = Mathf.Abs(Time.fixedDeltaTime * velocity.x);
        var moveY = Mathf.Abs(Time.fixedDeltaTime * velocity.y);
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