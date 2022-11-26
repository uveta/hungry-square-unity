using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private float _pushForce = 4f;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _rigidbody2D.AddForce(_pushForce * Vector2.up, ForceMode2D.Impulse);
        _rigidbody2D.AddForce(_pushForce * Vector2.right, ForceMode2D.Impulse);
    }

    private void Update()
    {
    }

    private void FixedUpdate()
    {
        var position = _rigidbody2D.position;
        // if (Mathf.Abs(position.y) > 5 || Mathf.Abs(position.x) > 10) _pushForce *= 1.05f;
        switch (position.y)
        {
            case > 5:
                Debug.Log("Reached upper border, moving down");
                _rigidbody2D.AddForce(_pushForce * Vector2.down, ForceMode2D.Impulse);
                return;
            case < -5:
                Debug.Log("Reached lower border, moving up");
                _rigidbody2D.AddForce(_pushForce * Vector2.up, ForceMode2D.Impulse);
                return;
        }
        switch (position.x)
        {
            case > 10:
                Debug.Log("Reached left border, moving right");
                _rigidbody2D.AddForce(_pushForce * Vector2.left, ForceMode2D.Impulse);
                return;
            case < -10:
                Debug.Log("Reached right border, moving left");
                _rigidbody2D.AddForce(_pushForce * Vector2.right, ForceMode2D.Impulse);
                return;
        }
    }
}