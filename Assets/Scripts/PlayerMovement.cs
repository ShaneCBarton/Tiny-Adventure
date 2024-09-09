using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private PlayerControls playerControls;
    private Animator animator;
    private Rigidbody2D rb;
    private Vector2 movementVector;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    /// <summary>
    /// This function polls the input action map for player input and sets it within the animator.
    /// </summary>
    private void PlayerInput()
    {
        movementVector = playerControls.Movement.Move.ReadValue<Vector2>();
        animator.SetFloat("MoveX", movementVector.x);
        animator.SetFloat("MoveY", movementVector.y);
    }

    private void MovePlayer()
    {
        Vector2 position = rb.position + movementVector * (moveSpeed * Time.fixedDeltaTime);
        rb.MovePosition(position);
    }
}
