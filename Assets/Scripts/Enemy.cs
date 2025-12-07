using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public float destroyX = -25f;

    public int enemyValue = 5; // ← puntos que da matar al enemigo

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (rb != null)
            rb.linearVelocity = new Vector2(-speed, rb.linearVelocity.y);

        if (transform.position.x < destroyX)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 🔥 Cuando le cae una bala
        if (other.CompareTag("Bullet"))
        {
            if (GameManager.Instance != null)
                GameManager.Instance.AddScore(enemyValue);

            Destroy(other.gameObject); // destruir bala
            Destroy(gameObject);       // destruir enemigo
            return;
        }

        // 💀 Cuando toca al jugador
        if (other.CompareTag("Player"))
        {
            Debug.Log("El enemigo tocó al jugador!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
