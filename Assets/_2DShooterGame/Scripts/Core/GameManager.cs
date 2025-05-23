using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    private HUD hud;

    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private string startScreenSceneName;
    
    private EnemySpawner enemySpawner;
    private void Start()
    {
        Globals.PlayerScore = 0;
        hud.UpdateScore(Globals.PlayerScore);
        hud.UpdateHighestScore(Globals.PlayerHighestScore);

        playerController.OnKilled += OnPlayerKilled;
        
        enemySpawner = GetComponent<EnemySpawner>();
        enemySpawner.Activate();
    }
    
    private void OnPlayerKilled()
    {
        StartCoroutine(GameOver());
    }
    
    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(startScreenSceneName);
    }

    public void OnEnemyKilled(int score)
    {
        Globals.PlayerScore += score;
        hud.UpdateScore(Globals.PlayerScore);

        if (Globals.PlayerScore > Globals.PlayerHighestScore)
        {
            Globals.PlayerHighestScore = Globals.PlayerScore;
            hud.UpdateHighestScore(Globals.PlayerHighestScore);
        }
    }
}