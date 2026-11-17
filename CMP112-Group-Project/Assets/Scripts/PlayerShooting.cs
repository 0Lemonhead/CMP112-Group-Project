using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
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
    }

    // Called When the keys set to shoot input (Space)
    void OnShoot()
    {
        //Checks if the cooldown is over before firing the bullet
        if (cooldownTimer > attackCooldown)
        {

            cooldownTimer = 0;

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            }
        }
    }
}
