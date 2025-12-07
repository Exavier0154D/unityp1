using System.Collections;           // ← necesario para la corrutina
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runSpeed = 4f;
    public float jumpForce = 7f;

    public GameObject balaPrefab;

    // 🔊 sonido del disparo
    public AudioClip fireSound;
    AudioSource audioSrc;

    Rigidbody2D rb;
    SpriteRenderer sr;

    // 🟢 DOBLE SALTO + COOLDOWN
    private int jumpsLeft = 2;          // cuántos saltos quedan
    private float jumpCooldown = 3f;    // segundos de cooldown
    private bool isCooldown = false;    // ¿está en cooldown?

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        // 🔊 Inicializamos AudioSource del Player
        audioSrc = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        float moveX = 0f;

        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            moveX = runSpeed;
            sr.flipX = false;
        }
        else if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            moveX = -runSpeed;
            sr.flipX = true;
        }

        rb.linearVelocity = new Vector2(moveX, rb.linearVelocity.y);
    }

    void Update()
    {
        // 🟢 DOBLE SALTO CON COOLDOWN
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpsLeft > 0 && !isCooldown)
            {
                jumpsLeft--;

                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

                // si ya no quedan saltos, arrancar cooldown
                if (jumpsLeft == 0)
                {
                    StartCoroutine(ResetJumpCooldown());
                }
            }
        }

        // DISPARO
        if (Input.GetMouseButtonDown(0))
        {
            DispararBala();
        }
    }

    void DispararBala()
    {
        if (balaPrefab == null)
            return;

        bool mirandoDerecha = !sr.flipX;
        Vector2 direccion = mirandoDerecha ? Vector2.right : Vector2.left;

        float offsetX = mirandoDerecha ? 0.5f : -0.5f;
        Vector3 spawnPos = transform.position + new Vector3(offsetX, 0, 0);

        GameObject bala = Instantiate(balaPrefab, spawnPos, Quaternion.identity);

        Bullet bulletScript = bala.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.direction = direccion;
        }

        // 🔊 Reproducir sonido del disparo
        if (fireSound != null && audioSrc != null)
        {
            audioSrc.PlayOneShot(fireSound);
        }
    }

    // Corrutina para recargar los saltos
    private IEnumerator ResetJumpCooldown()
    {
        isCooldown = true;

        yield return new WaitForSeconds(jumpCooldown);

        jumpsLeft = 3;
        isCooldown = false;
    }
}
