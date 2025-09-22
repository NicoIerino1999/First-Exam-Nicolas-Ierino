using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private InputActionReference jumpAction;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private int maxJumps = 2;

    private Rigidbody2D rb;
    private int jumpsUsed = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        moveAction.action.Enable();
        jumpAction.action.Enable();
    }

    private void Update()
    {
        Vector2 moveInput = moveAction.action.ReadValue<Vector2>();
        rb.linearVelocity = new Vector2(moveInput.x * speed, rb.linearVelocity.y);

        if (jumpAction.action.triggered && jumpsUsed < maxJumps)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            rb.linearVelocity += Vector2.up * jumpForce;
            jumpsUsed++;
        }

        if (PlayerInGround())
        {
            jumpsUsed = 0;
        }
    }

    private bool PlayerInGround()
    {
        return rb.linearVelocity.y == 0f;
    }
}

