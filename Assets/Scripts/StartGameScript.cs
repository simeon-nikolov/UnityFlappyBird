using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameScript : MonoBehaviour
{
    public void OnStartGameClick()
    {
        SceneManager.UnloadSceneAsync("TitleScreenScene");
        SceneManager.LoadScene("GameScene");
    }
}
