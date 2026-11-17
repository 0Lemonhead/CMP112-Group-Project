using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private float resetTime;
    private float lifetime;
    public EnemyHealth Enemy;

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
            lifetime = 0;
            Destroy(gameObject);

        }
    } 
           
    //Calls when a collision is detected
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) //Check is if object is an enemy
        {
            Enemy = collision.gameObject.GetComponent<EnemyHealth>(); // gets the values from EnemyHealth Script and sets it to enemy
            Enemy.Health = Enemy.Health - 1;
          
        }

        Destroy(gameObject); //Makes the bullet disappear
    }
}
