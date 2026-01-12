using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movimiento")]
    public float speed = 5f;
    public float minX = -8f;
    public float maxX = 8f;

    [Header("Disparo")]
    public GameObject bulletPrefab;   // Prefab de la bala
    public Transform firePoint;       // Punto desde donde se dispara
    public float bulletSpeed = 10f;
    public float fireCooldown = 0.25f;

    private float nextFireTime = 0f;
    private bool isAlive = true;

    void Update()
    {
        if (!isAlive) return;

        Move();
        Shoot();
    }

    void Move()
    {
        float inputX = Input.GetAxisRaw("Horizontal"); // A/D o flechas
        Vector3 movement = new Vector3(inputX, 0f, 0f) * speed * Time.deltaTime;
        transform.position += movement;

        // Limitar movimiento en X
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }

    void Shoot()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireCooldown;

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = Vector2.up * bulletSpeed;
            }
        }
    }

    public void Die()
    {
        isAlive = false;
    }
}
