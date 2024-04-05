using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class player : MonoBehaviour
{
    //functions declared
    //rigidbody
    Rigidbody2D rb;
    //animator
    public Animator animator;
    //speed of player
    public float speed = 50f;
    //destination and movement for player to walk around for fun
    Vector2 dest;
    Vector2 movement;
   
    
    void Start()
    {
        //grab componenets needed
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //grab right mouse button to move character around
        if (Input.GetKey(KeyCode.Mouse1))
        {
            dest = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        //play walking animation
        animator.SetFloat("movement", movement.magnitude);
    }
    private void FixedUpdate()
    {
        //movement so the lil guy doesn't freak out on screen, as he likes to do
        movement = dest - (Vector2)transform.position;
        //if movement is less than
        if (movement.magnitude < 0.1)
        {
            //doesnt budge
            movement = Vector2.zero;
        }
        rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime);
    }

    protected virtual void OnMouseDown()
    {
        //when clicking on player, you summon the watering can animation. just the animation
            animator.SetTrigger("wateringcan");
        
    }
}
