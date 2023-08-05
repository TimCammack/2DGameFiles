using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerInput;
    public Vector2 desiredMovement, groundPosition;
    public float groundSpeed, airSpeed, groundAcceleration, airAcceleration, gravity;
    public bool jumping;
    public float jumpPower;
    public bool onGround = false;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        desiredMovement = rb.velocity;
        playerInput = Input.GetAxisRaw("Horizontal");
        if (!jumping && onGround && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("jump");
            Jump();
        }

        if (onGround)
        {
            desiredMovement.x = Mathf.MoveTowards(desiredMovement.x, playerInput * groundSpeed, groundAcceleration * Time.deltaTime);
        }
        else
        {
            desiredMovement.x = Mathf.MoveTowards(desiredMovement.x, playerInput * airSpeed, airAcceleration * Time.deltaTime);
        }
        
        

        rb.velocity = desiredMovement;
        
    }

    void Jump()
    {
        jumping = true;
        desiredMovement.y = jumpPower;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "ground")
        {
            jumping = false;
            onGround = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag == "ground")
        {
            jumping = false;
            onGround = true;
            Debug.Log("grounded");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "ground")
        {

            onGround = false;
            Debug.Log("grounded");
        }
    }


}
