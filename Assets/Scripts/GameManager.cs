using UnityEngine;
using TMPro; 

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;   

    private bool isGameOver = false;
    private EnemySpawner spawner;
    private PlayerController player;

    void Start()
    {
        spawner = FindFirstObjectByType<EnemySpawner>();
        player = FindFirstObjectByType<PlayerController>();

        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(false); // Ocultar al inicio
        }
    }

    public void GameOver()
    {
        if (isGameOver) return;
        isGameOver = true;

        // Mostrar texto Game Over
        if (gameOverText != null)
            gameOverText.gameObject.SetActive(true);

        // Detener el spawner
        if (spawner != null)
            spawner.StopSpawning();

        // Desactivar al jugador
        if (player != null)
            player.Die();
    }
}
