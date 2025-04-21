using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreenLogicScript : MonoBehaviour
{
    public Text highScoreText;

    void Start()
    {
        int highScore = PlayerPrefs.GetInt("highScore");
        this.highScoreText.text = "High score: " + highScore;
    }

    public void StartGame()
    {
        SceneManager.UnloadSceneAsync("TitleScreenScene");
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
#if UNITY_STANDALONE
        Application.Quit();
#endif
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
