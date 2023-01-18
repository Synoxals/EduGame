using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.Rendering;

public class Platform : MonoBehaviour
{
    public float jumpForce = 5f;

    PlayerController playerController;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpForce = 12f;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        
        if (collision.relativeVelocity.y <= 0f);
        {
            Rigidbody2D rb = collision.gameObject.GetComponent< Rigidbody2D>();
            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        jumpForce = 5f;
        Debug.Log("hi");
    }

}
