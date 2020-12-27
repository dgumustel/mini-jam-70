using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    public float speed = 10.0f;
    public Vector2 movement; 

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        MovePlayer(movement);

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
