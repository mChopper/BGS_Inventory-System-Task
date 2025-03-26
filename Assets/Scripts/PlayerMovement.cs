using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;

    [HideInInspector] public Vector2 direction;

    Rigidbody2D rb;
    Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    
    public void Movement()
    {
        float xMovement = Input.GetAxisRaw("Horizontal");
        float yMovement = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(xMovement, yMovement).normalized * speed;
        rb.linearVelocity = movement;

        if (xMovement != 0f || yMovement != 0f)
        {
            direction = new Vector2(xMovement, yMovement);
            animator.SetFloat("Horizontal", xMovement);
            animator.SetFloat("Vertical", yMovement);
            animator.SetBool("Walking", true);
        }
        else
        {
            animator.SetBool("Walking", false);
        }
    }
}
