using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Game vars
    public int score = 0;

    // Game over stuff
    public GameObject GameOverScreen;
    public TextMeshProUGUI FinalScoreText;

    // Main UI stuff
    public GameObject MainUI;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI HPText;

    void Setup()
    {
        // Deactivate game over screen
        GameOverScreen.SetActive(false);
        // Activate main UI
        MainUI.SetActive(true);

        UpdateHP(3);
    }

    public void UpdateHP(int HP)
    {
        HPText.text = "HP: " + HP.ToString();
    }

    public void UpdateScore()
    {
        score += 1;
        ScoreText.text = "Score: " + score.ToString();
    }

    public void GameOver()
    {
        // Deactivate main UI
        MainUI.SetActive(false);

        // Activate game over screen
        GameOverScreen.SetActive(true);
        ScoreText.text = "Score: " + score.ToString();
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Main");
    }
}
