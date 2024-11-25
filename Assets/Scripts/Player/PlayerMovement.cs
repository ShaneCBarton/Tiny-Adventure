using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 CurrentPosition { get; private set; }
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject playerBoat;

    [Header("Layer Masks")]
    [SerializeField] private LayerMask waterLayer;
    [SerializeField] private LayerMask groundLayer;

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

    private void Start()
    {
        transform.position = PlayerStats.Instance.GetPosition();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        if (playerControls != null)
        {
            playerControls.Disable();
        }
    }

    private void Update()
    {
        HandlePlayerInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void HandlePlayerInput()
    {
        movementVector = playerControls.Movement.Move.ReadValue<Vector2>();
        animator.SetFloat("MoveX", movementVector.x);
        animator.SetFloat("MoveY", movementVector.y);
    }

    private void MovePlayer()
    {
        Vector2 position = rb.position + movementVector * (moveSpeed * Time.fixedDeltaTime);
        rb.MovePosition(position);
        CurrentPosition = transform.position;
    }

    private void EnterWater()
    {
        playerBoat.SetActive(true);
        animator.SetBool("InBoat", true);
    }

    private void ExitWater()
    {
        playerBoat.SetActive(false);
        animator.SetBool("InBoat", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            EnterWater();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            ExitWater();
        }
    }
}

