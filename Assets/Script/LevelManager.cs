using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int totalEnemies;

    private void FixedUpdate()
    {
        // Räkna antalet fiender i scenen
        UpdateTotalEnemies();
    }

    public void EnemyDied()
    {
        // Minska antalet fiender och kontrollera om alla fiender är döda
        totalEnemies--;

        if (totalEnemies <= 0)
        {
            // Ladda "happy ending"-scenen om det är Level 3
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                LoadHappyEndingScene();
            }
            else
            {
                // Annars, ladda nästa nivå
                LoadNextLevel();
            }
        }
    }

    private void LoadNextLevel()
    {
        // Ladda nästa scen baserat på den aktuella scenens byggindex
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        // Kontrollera om nästa scen finns och ladda den
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            // Om det inte finns någon nästa scen, exempelvis om det är den sista nivån, kan du utföra annan logik här eller ladda en viss scen
            Debug.Log("Alla nivåer är slutförda!");
        }
    }

    private void LoadHappyEndingScene()
    {
        SceneManager.LoadScene("happy ending");
    }

    private void UpdateTotalEnemies()
    {
        // Uppdatera antalet fiender varje gång den kallas
        totalEnemies = FindObjectsOfType<EnemyHealth>().Length;

        // Kontrollera om ShipHp är null (förstört) och ladda Game Over-scenen
        if (FindObjectOfType<ShipHp>() == null)
        {
            LoadGameOverScene();
        }
    }

    private void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    // Ny metod för att ladda om första nivån
    public void LoadFirstLevel()
    {
        SceneManager.LoadScene("level1");
    }
}

