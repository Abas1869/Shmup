using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void ResetFirstLevel()
    {
        SceneManager.LoadScene("YourFirstLevelSceneName"); // Byt ut "YourFirstLevelSceneName" med namnet på din första scen
    }
}
