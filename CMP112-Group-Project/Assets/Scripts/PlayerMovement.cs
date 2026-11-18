using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] private float speed;
    private Vector2 MovementInput;

    Vector3 prevPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = MovementInput * speed;

        // Face to direction of movement
        Vector3 direction = prevPos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
        if (prevPos != transform.position)
        { prevPos = transform.position; }
    }

    

    public void movement(InputAction.CallbackContext context) // used for with the player input set to "Invoke Unity Events"
    {
        MovementInput = context.ReadValue<Vector2>();
    }
}
