using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    public float speed = 10.0f;
    public Vector2 movement;
    public bool hasPerson = false;
    private Rigidbody2D rb;
    public int count = 0;
    private SpriteRenderer spriteRenderer;
    public float velocityx;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        MovePlayer(movement);
        velocityx = Input.GetAxis("Horizontal");
        if (velocityx > 0)
        {
            spriteRenderer.flipX = false;
        }
        if (velocityx < 0)
        {
            spriteRenderer.flipX = true;
        }
    }
    
    private void FixedUpdate()
    {
        MovePlayer(movement);
    }
    
    private void MovePlayer(Vector2 direction)
    {
        //rb.AddForce(direction * speed);
        //rb.velocity = direction * speed;
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }

}
