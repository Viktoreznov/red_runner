using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMouvement : MonoBehaviour
{
    Rigidbody2D playerRB;
    Animator anim;
    bool isGrounded = true;
    public float JumpForce,speed;
    private void Awake()
    {
        playerRB = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        anim.SetBool("Jump", !isGrounded);
        move();
        Jump();
    }

    private void FixedUpdate()
    {
       
       
    }

    void move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        if (h != 0) anim.SetBool("Running", true); else anim.SetBool("Running", false);

        playerRB.velocity = new Vector2(speed * h, playerRB.velocity.y);
        if (h < 0)
            transform.rotation = new Quaternion(transform.rotation.x, 180, transform.rotation.z, transform.rotation.w);
        else if (h > 0)
            transform.rotation = new Quaternion(transform.rotation.x, 0, transform.rotation.z, transform.rotation.w);

    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            gameObject.GetComponent<AudioSource>().Play();
            playerRB.AddForce(new Vector2(playerRB.velocity.x, JumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }


}
