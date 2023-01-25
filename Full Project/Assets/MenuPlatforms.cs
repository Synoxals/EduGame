using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.Rendering;

public class MenuPlatforms : MonoBehaviour
{
    public float jumpForce = 5f;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (jumpForce == 0)
        {
            jumpForce = 5f;
        }

        if (collision.relativeVelocity.y <= 0f) ;
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;
            }
        }
    }
}
