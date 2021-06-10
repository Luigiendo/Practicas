using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer character;
    public Rigidbody2D rigibody;

    [Header("Balance variables")]
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float jumpForce = 1;

    public int currentHP = 30;
    public int HP = 30;

    private float horizontal;
    private float vertical;
    private Vector3 direction;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        direction = new Vector3(horizontal, 0f, vertical);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            rigibody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

        if(Input.GetKey(KeyCode.A))
        {
            character.flipX = false;
            animator.SetBool("RunSide", true);
            transform.position = new Vector2(transform.position.x - moveSpeed, transform.position.y);
        }

        if (Input.GetKey(KeyCode.D))
        {
            character.flipX = true;
            animator.SetBool("RunSide", true);
            transform.position = new Vector2(transform.position.x + moveSpeed, transform.position.y);
        }

        if(direction.magnitude == 0f)
        {
            animator.SetBool("RunSide", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Hazard"))
        {
            animator.SetTrigger("Damage");
            if ((currentHP - collision.GetComponent<Hazard>().vidaAQuitar) < 0)
                currentHP = 0;
            else
                currentHP = currentHP - collision.GetComponent<Hazard>().vidaAQuitar;
                    
        }

        if (collision.CompareTag("Enemy"))
        {
            animator.SetTrigger("Damage");
            if ((currentHP - collision.GetComponent<Enemy>().vidaAQuitar) < 0)
                currentHP = 0;
            else
                currentHP = currentHP - collision.GetComponent<Enemy>().vidaAQuitar;

        }

        if (collision.CompareTag("Heal"))
        {
            if ((currentHP + collision.GetComponent<Heal>().vidaAObtener) > HP)
                currentHP = HP;
            else
                currentHP += collision.GetComponent<Heal>().vidaAObtener;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.CompareTag("Spring"))
        {
            rigibody.AddForce(new Vector2(0f, jumpForce * 2), ForceMode2D.Impulse);
        }
    }
}
