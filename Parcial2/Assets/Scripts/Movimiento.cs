using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{   
    private float horizontal;
    public float velocidad = 6f;
    private bool mirandoDerecha = true;

    
    public Animator animator;



    [SerializeField] private Rigidbody2D rb;

    private void Start()
    {
       animator = GetComponent<Animator>();
    }

   
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        voltear();

        animator.SetFloat("Horizontal",Mathf.Abs(horizontal));

    }

     private void voltear()
    {
        if (mirandoDerecha && horizontal < 0f || !mirandoDerecha && horizontal > 0f)
        {
            mirandoDerecha = !mirandoDerecha;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;               
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal*velocidad, rb.velocity.y);
        
    }

   

  
}
