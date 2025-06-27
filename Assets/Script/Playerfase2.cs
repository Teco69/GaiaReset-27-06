using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playerfase2 : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float groundCheckDistance = 0.3f;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer spriteRenderer;

     private float initialX;
    private float moveInput;
    private bool isGrounded;
    private bool wasGrounded;
     public float leftLimit = 2f; // Limite para a esquerda
    public float rightLimit = 5f;


    void Start()
    {
        
        
        initialX = transform.position.x; // Salva a posição inicial da câmera
        
    }
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (rb == null || coll == null || anim == null || spriteRenderer == null)
        {
            Debug.LogError("Componente(s) faltando no Playerfase2!");
            enabled = false;
            return;
        }

        wasGrounded = true;
    }

    void Update()
    {
        float newX = transform.position.x + moveInput * moveSpeed * Time.deltaTime;
         newX = Mathf.Clamp(newX, initialX - leftLimit, initialX + rightLimit);
    transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        moveInput = Input.GetAxisRaw("Horizontal");

        if (moveInput > 0)
        {
            spriteRenderer.flipX = false;
            anim.SetBool("direita", true);
            anim.SetBool("esquerda", false);
        }
        else if (moveInput < 0)
        {
            spriteRenderer.flipX = true;
            anim.SetBool("direita", true);
        }
        else
        {
            anim.SetBool("direita", false);
            anim.SetBool("esquerda", false);
        }

        bool groundedForAnim = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, groundCheckDistance, groundLayer);
        anim.SetBool("isGrounded", groundedForAnim);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            anim.SetTrigger("pulo");
            StartCoroutine(ResetTriggerAfterDelay("pulo", 0.25f));
            isGrounded = false;
        }
        
         
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        wasGrounded = isGrounded;
        isGrounded = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, groundCheckDistance, groundLayer);

        if (!wasGrounded && isGrounded)
        {
            anim.SetTrigger("caindochao");
            StartCoroutine(ResetTriggerAfterDelay("caindochao", 0.3f));
        }
    }

    IEnumerator ResetTriggerAfterDelay(string triggerName, float delay)
    {
        yield return new WaitForSeconds(delay);
        anim.ResetTrigger(triggerName);
    }

    void OnDrawGizmos()
    {
        if (coll != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(coll.bounds.center + Vector3.down * groundCheckDistance, coll.bounds.size);
        }
    }

     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("gota"))
        {
            SceneManager.LoadScene("FimDeJogo");
        }
    }
}
