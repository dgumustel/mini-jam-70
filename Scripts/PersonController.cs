using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonController : MonoBehaviour
{
    private GameManager gameManager;
    private GameObject player;
    //public Transform parent;
    public bool isOnPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isOnPlayer)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.5f, player.transform.position.z);
            
        }
        else
        {
            gameObject.transform.SetParent(null);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            transform.SetParent(player.transform);
            isOnPlayer = true;
        }
    } 

    /*
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isOnPlayer = false;
        }
    }*/

    private void OnTriggerEnter2D(Collider2D other)
    {
        /*
        if (other.gameObject.tag.Equals("Player"))
        {
            //SetParent(parent);
        }*/

        if (other.gameObject.tag.Equals("Heaven"))
        {
            Destroy(gameObject);
            gameManager.UpdateScore(5);
        }
        
        if (other.gameObject.tag.Equals("Hell"))
        {
            Destroy(gameObject);
            gameManager.UpdateScore(-5);
        }
    }  
    

/*
    public void SetParent(Transform newParent)
    {
        gameObject.transform.SetParent(newParent);
        Debug.Log("Person's Parent: " + gameObject.transform.parent.name);
    }
    
    public void SetParent(GameObject newParent)
    {
        gameObject.transform.parent = newParent.transform;
        Debug.Log("Person's Parent: " + gameObject.transform.parent.name);
    }*/
}
