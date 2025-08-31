using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] float jumpSpeed;
    bool isGrounded = true;
    float directionX;
    Animator animator;
    SpriteRenderer sprite;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ValidateComponent(rb, nameof(rb));
        animator = GetComponent<Animator>();
        ValidateComponent(animator, nameof(animator));
        sprite = GetComponent<SpriteRenderer>();
        ValidateComponent(sprite, nameof(sprite));
    }

    private void ValidateComponent<T>(T component, string name)
    {
        if(component is null)
        {
            Debug.LogError($"{name} is null!");
        }
    }

    void Update()
    {
        directionX = Input.GetAxis(nameof(Movement.Horizontal));
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            HandleJump();
        }
        HandleMovementAnimations();
    }

    private void HandleJump()
    {
        isGrounded = false;
        animator.SetTrigger("IsJumping");
        rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new(directionX * speed, rb.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void HandleMovementAnimations()
    {
        animator.SetFloat("Speed", rb.linearVelocity.x);
        if (directionX != 0)
            sprite.flipX = directionX < 0;
    }

    enum Movement
    {
        Horizontal,
        Vertical
    }
}
