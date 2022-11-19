using UnityEngine;

public class RubyController : MonoBehaviour
{
    private float horizontal;
    private Rigidbody2D rigidbody2d;
    private float vertical;

    // Start is called before the first frame update
    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        var position = rigidbody2d.position;
        position.x += 3.0f * horizontal * Time.deltaTime;
        position.y += 3.0f * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }
}