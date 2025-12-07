using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour
{
    [System.Serializable]
    public class SpawnItem
    {
        public GameObject prefab;
        public bool isHigh;   // true = usar highY, false = usar lowY
    }

    public SpawnItem[] items;

    public float lowY = -2f;
    public float highY = -1f;
    public float gapX = 5f;

    float nextX;

    void Start()
    {
        nextX = transform.position.x;
        StartCoroutine(SpawnCoRoutine());
    }

    IEnumerator SpawnCoRoutine()
    {
        while (true)
        {
            if (items == null || items.Length == 0)
            {
                Debug.LogWarning("No items defined in EnemyGenerator");
                yield break;
            }

            // Elegir un item válido
            int index = Random.Range(0, items.Length);

            SpawnItem item = items[index];
            if (item.prefab == null)
            {
                Debug.LogWarning("Null prefab in items array at index " + index);
                continue;
            }

            float y = item.isHigh ? highY : lowY;

            Instantiate(item.prefab, new Vector3(nextX, y, 0), Quaternion.identity);

            nextX += gapX;

            yield return new WaitForSeconds(1f);
        }
    }
}