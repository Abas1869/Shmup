using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void ResetFirstLevel()
    {
        SceneManager.LoadScene("YourFirstLevelSceneName"); // Byt ut "YourFirstLevelSceneName" med namnet p� din f�rsta scen
    }
}
