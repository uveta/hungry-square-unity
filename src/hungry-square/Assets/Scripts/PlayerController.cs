using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3.0f;

    // movement
    private Rigidbody2D _rigidbody2D;
    private float _vertical;
    private float _horizontal;

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
}