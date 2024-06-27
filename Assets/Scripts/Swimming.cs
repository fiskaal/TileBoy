using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Swimming : MonoBehaviour
{
    private float vertical;
    private float speed = 4f;
    private bool inWater;
    private bool isSwimming;
    
    [SerializeField] private Rigidbody2D rb;



    // Update is called once per frame
    void Update()
    {
        

        vertical = Input.GetAxis("Vertical");

        if (inWater && Mathf.Abs(vertical) > 0f)
        {
            isSwimming = true;
        }
    }

    private void FixedUpdate()
    {
        if (isSwimming)
        {
            rb.gravityScale = 3f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
        }
        else
        {
            rb.gravityScale = 5f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Swim"))
        {
            inWater = true;

            
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Swim"))
        {
            inWater = false;
            isSwimming = false;
            

        }
    }
}
