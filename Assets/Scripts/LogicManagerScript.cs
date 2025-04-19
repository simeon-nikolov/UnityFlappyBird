using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicManagerScript : MonoBehaviour
{
    public int playerScore;
    public int highScore;
    public Text scoreText;
    public Text highScoreText;
    public AudioSource scoreAudio;
    public GameObject gameOverScreen;
    public BirdScript birdScript;

    private void Start()
    {
        this.highScore = PlayerPrefs.GetInt("highScore");
        this.UpdateHighScoreText(this.highScore);
    }

    [ContextMenu("Add score")]
    public void addScore(int scoreToAdd)
    {
        if (this.birdScript.GetIsBirdAlive())
        {
            this.scoreAudio.Play();
            this.playerScore += scoreToAdd;
            this.scoreText.text = playerScore.ToString();
        }

    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        this.gameOverScreen.SetActive(true);

        if (this.playerScore > this.highScore)
        {
            this.SetHighScore(this.playerScore);
        }
    }

    private void SetHighScore(int highScore)
    {
        this.highScore = this.playerScore;
        PlayerPrefs.SetInt("highScore", this.highScore);
        this.UpdateHighScoreText(this.highScore);
    }

    private void UpdateHighScoreText(int highScore)
    {
        this.highScoreText.text = "High score: " + this.highScore;
    }
}
