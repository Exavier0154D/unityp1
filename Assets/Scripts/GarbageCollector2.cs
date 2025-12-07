using UnityEngine;

public class GarbageCollector2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que entra es un disparo (por tag)
        if (other.CompareTag("Fireball"))
        {
            Destroy(other.gameObject);  // Destruye la bola de fuego
            Debug.Log("¡Disparo eliminado por Garbage Collector!");  // Opcional: para debug
        }
    }
}