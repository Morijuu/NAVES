using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public float minY = -5.5f; // límite inferior de la pantalla

    private GameManager gameManager;

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }

    void Update()
    {
        // movimiento hacia abajo
        transform.position += Vector3.down * speed * Time.deltaTime;

       
        if (transform.position.y < minY)
        {
            if (gameManager != null)
            {
                gameManager.GameOver();
            }
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enemy trigger con: " + collision.name + " (tag: " + collision.tag + ")");

       
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject); // destruye la bala
            Destroy(gameObject);           // destruye el enemigo
        }
        
        else if (collision.CompareTag("Player"))
        {
            if (gameManager != null)
            {
                gameManager.GameOver();
            }
        }
    }

}
