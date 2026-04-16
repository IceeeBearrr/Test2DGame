using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private InputSystem_Actions inputActions;
    private Vector2 moveInput;  //when right (1, 0), when left (-1, 0)
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private float speed = 7f;
    [SerializeField] private float jump = 14f;

    private enum MovementState { idle, running, jumping, falling };

    // Happens after Awake()
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Reads movement input every frame
    private void Update()
    {
        // Get X and Y input values
        moveInput = inputActions.Player.Move.ReadValue<Vector2>();

        // Apply horizontal movement by moveInput.x * speed while the y-axis remains unchanged
        rb.linearVelocity = new Vector2(moveInput.x * speed, rb.linearVelocity.y);

        // When Jump is triggered, x-axis remains unchanged while y-axis is set to jump value
        if (inputActions.Player.Jump.triggered)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jump);
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (moveInput.x > 0f)
        {
            state = MovementState.running;
            spriteRenderer.flipX = false;
        }
        else if (moveInput.x < 0f)
        {
            state = MovementState.running;
            spriteRenderer.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        // check whether player is jumping
        if (rb.linearVelocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        // check whether player is falling
        else if (rb.linearVelocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        
        animator.SetInteger("state", (int)state);
    }

    // Prepare input system before start
    private void Awake()
    {
        inputActions = new InputSystem_Actions();
    }

    // Turns ON input listening
    private void OnEnable()
    {
        inputActions.Enable();
    }

    // Turns OFF input listening preventing memory leaks
    private void OnDisable()
    {
        inputActions.Disable();
    }
}
