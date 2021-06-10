using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruby : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer ruby;
    public Rigidbody2D rigibody;
    [Header("Balance variables")]
    [SerializeField]
    private float moveSpeed;
    public int HP = 30;
    [HideInInspector]
    public int currentHP = 30;
    [SerializeField]
    private float jumpForce = 1;
    private float horizontal;
    private float vertical;
    private Vector3 direction;
    public void RestarVida(int VidaRestar) 
    {
        Debug.Log("Pego");
        currentHP -= VidaRestar;
    }
    public void ObtenerVida(int VidaSumar)
    {
        Debug.Log("Curo");
        currentHP += VidaSumar;

    }


    // Start is called before the first frame update
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
       //if(Input.GetKey(KeyCode.W))
       // {
       //     animator.SetBool("RunBack",true);
       //     animator.SetBool("RunFront",false);
       //     animator.SetBool("RunSide",false);
       //     transform.position = new Vector2(transform.position.x,transform.position.y + moveSpeed);
       // } 
        
       // if(Input.GetKey(KeyCode.S))
       // {
       //     animator.SetBool("RunBack",false);
       //     animator.SetBool("RunFront",true);
       //     animator.SetBool("RunSide",false);
       //     transform.position = new Vector2(transform.position.x,transform.position.y - moveSpeed);
       // }
        
        if(Input.GetKey(KeyCode.A))
        {
            ruby.flipX = false;
            //animator.SetBool("RunBack",false);
            //animator.SetBool("RunFront",false);
            animator.SetBool("RunSide",true);
            transform.position = new Vector2(transform.position.x - moveSpeed, transform.position.y);
        }
        
        if(Input.GetKey(KeyCode.D))
        {
            ruby.flipX = true;
            //animator.SetBool("RunBack",false);
            //animator.SetBool("RunFront",false);
            animator.SetBool("RunSide",true);
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
            animator.SetTrigger("Damage1");
            if ((currentHP - collision.GetComponent<Hazard>().vidaAQuitar) < 0)
                currentHP = 0;
            else 
                currentHP -= collision.GetComponent<Hazard>().vidaAQuitar;


        }

        if(collision.CompareTag("Heal"))
        {
            if ((currentHP + collision.GetComponent<Heal>().vidaAObtener) > HP)
                currentHP = HP;
            else
                currentHP += collision.GetComponent<Heal>().vidaAObtener;
            
            //activar particulas
        }
    }



}
