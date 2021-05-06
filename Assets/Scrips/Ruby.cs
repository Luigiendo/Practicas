using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruby : MonoBehaviour
{
    public Animator Animator;
    public SpriteRenderer ruby;
    [Header("Balance variables")]
    [SerializeField]
    private float moveSpeed;
    private int HP = 30;
    [SerializeField]
    private int currentHP = 30;
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
       if(Input.GetKey(KeyCode.W))
        {
            Animator.SetBool("RunBack",true);
            Animator.SetBool("RunFront",false);
            Animator.SetBool("RunSide",false);
            transform.position = new Vector2(transform.position.x,transform.position.y + moveSpeed);
        } 
        
        if(Input.GetKey(KeyCode.S))
        {
            Animator.SetBool("RunBack",false);
            Animator.SetBool("RunFront",true);
            Animator.SetBool("RunSide",false);
            transform.position = new Vector2(transform.position.x,transform.position.y - moveSpeed);
        }
        
        if(Input.GetKey(KeyCode.A))
        {
            ruby.flipX = false;
            Animator.SetBool("RunBack",false);
            Animator.SetBool("RunFront",false);
            Animator.SetBool("RunSide",true);
            transform.position = new Vector2(transform.position.x - moveSpeed, transform.position.y);
        }
        
        if(Input.GetKey(KeyCode.D))
        {
            ruby.flipX = true;
            Animator.SetBool("RunBack",false);
            Animator.SetBool("RunFront",false);
            Animator.SetBool("RunSide",true);
            transform.position = new Vector2(transform.position.x + moveSpeed, transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Hazard"))
        {
            Animator.SetTrigger("Damage1");
            if ((currentHP - collision.GetComponent<Hazard>().VidaAQuitar) < 0)
                currentHP = 0;
            else 
                currentHP -= collision.GetComponent<Hazard>().VidaAQuitar;


        }

        if(collision.CompareTag("Heal"))
        {
            if ((currentHP + collision.GetComponent<Heal>().VidaAObtener) > HP)
                currentHP = HP;
            else
                currentHP += collision.GetComponent<Heal>().VidaAObtener;
            
            //activar particulas
        }
    }



}
