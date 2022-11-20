using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 2.0f;
    public bool vertical = true;
    public float changeTime = 1.0f;
    private int direction = 1;

    private Rigidbody2D rigidbody2d;
    private float timer;

    // Start is called before the first frame update
    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        timer = changeTime;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }

    private void FixedUpdate()
    {
        var position = rigidbody2d.position;
        if (vertical)
            position.y += Time.deltaTime * speed * direction;
        else
            position.x += Time.deltaTime * speed * direction;

        rigidbody2d.MovePosition(position);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.gameObject.GetComponent<RubyController>();
        if (player != null) player.ChangeHealth(-1);
    }
}