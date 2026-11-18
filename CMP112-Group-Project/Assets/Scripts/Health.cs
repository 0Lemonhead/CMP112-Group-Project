using UnityEngine;

public class Health : MonoBehaviour
{
    // Vars
    public int HP = 3;

    // Get game Controller
    public GameObject gameController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        // Get game controller script
        GameController gameControllerScript = gameController.GetComponent<GameController>();

        // If the object is the player do game over
        if (gameObject.CompareTag("Player"))
        {
            gameControllerScript.GameOver();
        }
        // If the object is an enemy then destroy it and increase score
        else if (gameObject.CompareTag("Enemy"))
        {
            gameControllerScript.score += 1;
            Destroy(gameObject);
        }
    }
}