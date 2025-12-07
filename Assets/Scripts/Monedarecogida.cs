using UnityEngine;

public class Monedarecogida : MonoBehaviour
{
    public int coinValue = 1; // Puedes cambiar esto en el inspector

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Sumar puntos
            if (GameManager.Instance != null)
                GameManager.Instance.AddScore(coinValue);

            // Desactivar moneda visualmente
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;

            // Destruir después de un tiempo
            Destroy(gameObject, 0.2f);
        }
    }
}
