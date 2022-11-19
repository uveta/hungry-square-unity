using UnityEngine;

public class RubyController : MonoBehaviour
{
    public float speed = 3.0f;

    public int MaxHealth => 5;
    public int Health => currentHealth;
    private int currentHealth;

    private float horizontal;
    private Rigidbody2D rigidbody2d;
    private float vertical;

    // Start is called before the first frame update
    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

        currentHealth = MaxHealth;
        // currentHealth = 1;
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
        position.x += speed * horizontal * Time.deltaTime;
        position.y += speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }

    public void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, MaxHealth);
        Debug.Log(currentHealth + "/" + MaxHealth);
    }
}