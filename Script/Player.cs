using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float PlayerSpeed = 5f;
    public float Acceleration = 1.2f;
    public float jumpForce = 5f; 
    private Rigidbody2D rb; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update() 
    {
        PlayerSpeed += Acceleration * Time.deltaTime;
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector2(1f, 0f) * PlayerSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        
    }
}
