using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private float resetTime;
    private float lifetime;
    public Health TargetHP;
    public string Shooter;
    public string Target;

    // Get game Controller
    public GameObject gameController;

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
        // Get game controller script
        GameController gameControllerScript = gameController.GetComponent<GameController>();

        if (!collision.gameObject.CompareTag(Shooter))
        {
            if (collision.gameObject.CompareTag(Target)) //Check is if object is a target
            {
                // Get reference to targets HP
                TargetHP = collision.gameObject.GetComponent<Health>();

                TargetHP.HP -= 1;

                // Check if player has taken damage and update ui
                if (gameObject.CompareTag("Player"))
                {
                    gameControllerScript.UpdateHP(TargetHP.HP);
                }
            }

            Destroy(gameObject); //Makes the bullet disappear
        }
    }
}
