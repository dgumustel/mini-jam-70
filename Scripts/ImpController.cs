using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpController : MonoBehaviour
{
    public float speed = 1.0f;
    private Rigidbody2D impRb;
    private GameObject player;
    public Vector2 chasePlayer;
    public bool hitPlayer = false;
    public bool hasPerson = false;
    public Vector2 goToHell;
    private GameObject hell;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        impRb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        hell = GameObject.Find("Hell");
        impRb = this.GetComponent<Rigidbody2D>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        chasePlayer = (Vector2)(player.transform.position - transform.position);
        goToHell = (Vector2)(hell.transform.position - transform.position);

    }

    private void FixedUpdate()
    {
        if (hasPerson)
        {
            MoveImp(goToHell);
        }
        else
        {
            MoveImp(chasePlayer);
        }
    }

    private void MoveImp(Vector2 direction)
    {
        impRb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
        if (direction.x > 0)
        {
            spriteRenderer.flipX = false;
        }

        if (direction.x < 0)
        {
            spriteRenderer.flipX = true;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !hasPerson)
        {
            hitPlayer = true;
            hasPerson = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Hell") && hasPerson)
        {
            Destroy(gameObject);
        }
    }
}
