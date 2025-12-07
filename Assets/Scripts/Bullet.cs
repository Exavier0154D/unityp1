using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 direction;
    public float speed = 8f;

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    // Detectar colisiones
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si toca un enemigo, lo destruye
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject); // mata enemigo
            Destroy(gameObject);           // destruye la bala
        }

        // Si toca cualquier otra cosa sólida, se destruye la bala
        if (collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
