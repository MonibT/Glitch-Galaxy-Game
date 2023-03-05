using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    public AudioSource jumpsound;
    public float speed = 10f;
    public float jumpForce = 500f;
    private bool isGrounded;
    private bool isWalking;
    private float dirX = 0f;
    private bool faceright = true;


    private enum MovementState { idle, Walk, jump, fall}

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {

        dirX = Input.GetAxisRaw("Horizontal");
        
        if (Input.GetKey("d"))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else if (Input.GetKey("a"))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce);
            isGrounded = false;
            jumpsound.Play();
        }
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        
        MovementState state;

        if (dirX > 0f || dirX < 0f )
        {
            state = MovementState.Walk;

            if (dirX > 0f && !faceright)
            {

                Flip();
            }
            else if (dirX < 0f && faceright)
            {

                Flip();
            }
        }

        

        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > 0.1f)
        {
            state = MovementState.jump;
        }
        else if (rb.velocity.y < -0.1f)
        {
            state = MovementState.fall;
        }
        anim.SetInteger("state", (int)state);
    }

    private void Flip()
    {
        faceright = !faceright;
        transform.Rotate(0f, 180f, 0f);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}