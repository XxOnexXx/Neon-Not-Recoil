using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] TMP_Text enemiesLeftText;
    [SerializeField] GameObject youWinText;

    const string ENEMIES_LEFT_STRING = "Enemies Left: ";
    int enemiesLeft = 0;
    public void AdjustEnemies(int amount)
    {
        enemiesLeft += amount;
        enemiesLeftText.text = ENEMIES_LEFT_STRING + enemiesLeft.ToString();

        if (enemiesLeft <= 0)
        {
            youWinText.SetActive(true);
        }
    }


    void Update()
    {
        DebugCodes();
    }
    public void RestartScene()
    {
        int currentScnerio = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScnerio);
    }

    public void QuitButton()
    {
        Debug.LogWarning("You Fucker");
        Application.Quit();
    }

    void DebugCodes()
    {
        if (Input.GetKey(KeyCode.P))
        {
            RestartScene();
        }
    }

}
