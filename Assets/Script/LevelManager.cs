using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int totalEnemies;

    private void FixedUpdate()
    {
        // R�kna antalet fiender i scenen
        UpdateTotalEnemies();
    }

    public void EnemyDied()
    {
        // Minska antalet fiender och kontrollera om alla fiender �r d�da
        totalEnemies--;

        if (totalEnemies <= 0)
        {
            // Ladda "happy ending"-scenen om det �r Level 3
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                LoadHappyEndingScene();
            }
            else
            {
                // Annars, ladda n�sta niv�
                LoadNextLevel();
            }
        }
    }

    private void LoadNextLevel()
    {
        // Ladda n�sta scen baserat p� den aktuella scenens byggindex
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        // Kontrollera om n�sta scen finns och ladda den
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            // Om det inte finns n�gon n�sta scen, exempelvis om det �r den sista niv�n, kan du utf�ra annan logik h�r eller ladda en viss scen
            Debug.Log("Alla niv�er �r slutf�rda!");
        }
    }

    private void LoadHappyEndingScene()
    {
        SceneManager.LoadScene("happy ending");
    }

    private void UpdateTotalEnemies()
    {
        // Uppdatera antalet fiender varje g�ng den kallas
        totalEnemies = FindObjectsOfType<EnemyHealth>().Length;

        // Kontrollera om ShipHp �r null (f�rst�rt) och ladda Game Over-scenen
        if (FindObjectOfType<ShipHp>() == null)
        {
            LoadGameOverScene();
        }
    }

    private void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    // Ny metod f�r att ladda om f�rsta niv�n
    public void LoadFirstLevel()
    {
        SceneManager.LoadScene("level1");
    }
}

