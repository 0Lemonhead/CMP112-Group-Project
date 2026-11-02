using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] private float speed;
    private Vector2 PlayerInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = PlayerInput * speed;
    }

    public void movement(InputAction.CallbackContext context) // used for with the player input set to "Invoke Unity Events"
    {
        PlayerInput = context.ReadValue<Vector2>();
    }
}
