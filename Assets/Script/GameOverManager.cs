using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOverManager : MonoBehaviour
{
    public void RestartLevel()
    {
        // Ladda om den aktuella scenen
        SceneManager.LoadScene("level 1");
    }
}

