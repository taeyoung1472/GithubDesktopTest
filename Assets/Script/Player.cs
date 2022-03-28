using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Vector2 limitPos;
    [SerializeField] private UnityEvent deadEvent;
    bool isGround = true;
    float pos;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        pos += Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        pos = Mathf.Clamp(pos, limitPos.x, limitPos.y);
        transform.position = new Vector2(pos, transform.position.y);
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            spriteRenderer.flipX = spriteRenderer.flipX;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGround = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            isGround = true;
        }
        if (collision.transform.CompareTag("Enemy"))
        {
            deadEvent.Invoke();
        }
    }
}