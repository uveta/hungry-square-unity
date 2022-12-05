using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 3.0f;
    
    private float _horizontal;

    // movement
    private Rigidbody2D _rigidbody2D;
    private float _vertical;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        var position = _rigidbody2D.position;
        var move = new Vector2(_horizontal, _vertical);
        position += move * (speed * Time.deltaTime);
        _rigidbody2D.MovePosition(position);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Enemy"))
        {
            // collision with enemy
            // game over
            transform.position = new Vector2(-6, 0);
        }
        if (col.collider.CompareTag("MainCamera"))
        {
            // collision with screen edge
            // game over
            transform.position = new Vector2(-6, 0);
        }
        if (col.collider.CompareTag("Food"))
        {
            // picked up food
            // remove food
            Destroy(col.collider.gameObject);
            // TODO: increase score
            // TODO: increase game speed
            // spawn enemy
            Enemy.Spawn();
            // spawn food
            Food.Spawn();
        }
    }
}