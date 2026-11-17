using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private float resetTime;
    private float lifetime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // hides the bullet after the time set in the editor
        lifetime += Time.deltaTime;
        if (lifetime > resetTime)
        {
            gameObject.SetActive(false);
        }
    }
           
    //Calls when a collision is detected
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false); //Makes the bullet disappear
    }
}
