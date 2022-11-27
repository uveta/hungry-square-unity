using UnityEngine;

public class PlayerController : MonoBehaviour
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
        switch (col.collider.tag)
        {
            case "Enemy":
                // collision with enemy
                break;
            case "MainCamera":
                transform.position = new Vector2(-5, 0);
                // collision with screen edge
                break;
            case "Food":
                // picked up food
                break;
        }
    }
}