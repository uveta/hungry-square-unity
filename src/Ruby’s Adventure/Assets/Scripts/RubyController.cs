using UnityEngine;

public class RubyController : MonoBehaviour
{
    public float speed = 3.0f;
    public float timeInvincible = 2.0f; // seconds
    public GameObject projectilePrefab;
    private Animator animator;
    private float horizontal;
    private float invincibleTimer;
    private bool isInvincible;
    private Vector2 lookDirection = new(1, 0);
    private Rigidbody2D rigidbody2d;
    private float vertical;

    public int MaxHealth => 5;
    public int Health { get; private set; }

    // Start is called before the first frame update
    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Health = MaxHealth;
    }

    // Update is called once per frame
    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        var move = new Vector2(horizontal, vertical);
        if (Input.GetKeyDown(KeyCode.C)) Launch();

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
    }

    private void FixedUpdate()
    {
        var position = rigidbody2d.position;
        var move = new Vector2(horizontal, vertical);
        position += move * (speed * Time.deltaTime);
        rigidbody2d.MovePosition(position);
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible) return;
            animator.SetTrigger("Hit");
            isInvincible = true;
            invincibleTimer = timeInvincible;
        }

        Health = Mathf.Clamp(Health + amount, 0, MaxHealth);
        Debug.Log(Health + "/" + MaxHealth);
    }

    private void Launch()
    {
        var projectileObject =
            Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);

        var projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 300);

        animator.SetTrigger("Launch");
    }
}