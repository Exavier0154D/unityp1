using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject prefab;
    public bool isHigh;

    public float lowY = -2f;
    public float highY = -1f;
    public float gapX = 5f;

    private float nextX;

    void Start()
    {
        nextX = transform.position.x;
        InvokeRepeating(nameof(SpawnPlatform), 0f, 1f);
    }

    void SpawnPlatform()
    {
        if (prefab == null)
            return;

        float y = isHigh ? highY : lowY;

        Instantiate(prefab, new Vector3(nextX, y, 0), Quaternion.identity);

        nextX += gapX;
    }
}
