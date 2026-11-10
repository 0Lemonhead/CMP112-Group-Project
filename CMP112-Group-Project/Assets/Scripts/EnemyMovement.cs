using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    // Other vars
    public int map_x_min;
    public int map_y_min;
    public int map_x_max;
    public int map_y_max;

    // Navigation vars
    public Transform target;
    NavMeshAgent navAgent;
    bool chasing = false;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.updateRotation = false;
        navAgent.updateUpAxis = false;

        // Start patrolling
        // Get random x and y coord within the map boundries
        int destination_x = Random.Range(map_x_min, map_x_max);
        int destination_y = Random.Range(map_y_min, map_y_max);
        // Set random x and y to a position vector
        Vector2 destination = new Vector2(destination_x, destination_y);
        // Set nav to random location
        navAgent.SetDestination(destination);
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        // Nav to player when chasing
        if (chasing)
        {
            // Set destination
            navAgent.SetDestination(target.position);
        }
        else
        {
            // Check if reached destination
            // Check distance to target agaist stopping distance and
            // Check if another path is pending
            if (navAgent.remainingDistance <= navAgent.stoppingDistance && !navAgent.pathPending)
            {
                // If destination reached then get a new destination
                OnDestinationReached();
            }
        }
        // Face to direction of movement
        Vector3 direction = navAgent.destination - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        chasing = true;
        navAgent.destination = transform.position;
    }

    void OnDestinationReached()
    {
        // Get random x and y coord within the map boundries
        int destination_x = Random.Range(map_x_min, map_x_max);
        int destination_y = Random.Range(map_y_min, map_y_max);
        // Set random x and y to a position vector
        Vector2 destination = new Vector2(destination_x, destination_y);
        // Set nav to random location
        navAgent.SetDestination(destination);
    }
}
