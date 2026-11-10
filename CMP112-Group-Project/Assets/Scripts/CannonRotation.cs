using UnityEngine;
using UnityEngine.InputSystem;

public class CannonRotation : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 MousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.value); //sets the Mouse Position to a vector3

        Vector2 direction = (MousePosition - transform.position); // converts the MousePosition to vector2 to get the game position of the mouse
        
        transform.up = direction; // rotates the base to the mouse location

    }
}
