using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicManagerScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public BirdScript birdScript;

    [ContextMenu("Add score")]
    public void addScore(int scoreToAdd)
    {
        if (this.birdScript.GetIsBirdAlive())
        {
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
    }
}
