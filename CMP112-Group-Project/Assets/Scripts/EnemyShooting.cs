using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    //Initialize Variables

    // Shooting
    [SerializeField] private GameObject bulletPrefab;
    private Rigidbody2D rb;
    [SerializeField] private int bulletForce;
    [SerializeField] private Transform firePoint;

    // Add Cooldown 
    [SerializeField] private float attackCooldown;
    private float cooldownTimer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer += Time.deltaTime;

        //Checks if the cooldown is over before firing the bullet
        if (cooldownTimer > attackCooldown)
        {
            Shoot();
        }
    }

    // Called When the keys set to shoot input (Space)
    void Shoot()
    { 
        cooldownTimer = 0;

        // Create bullet
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

        Bullet BltScript = bullet.GetComponent<Bullet>(); // Get bullet script
        BltScript.Shooter = "Enemy"; // Set the current shooter so bullet does not hit the enemy
        BltScript.Target = "Player"; // Set the intended target to the player

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        }
    }
}
