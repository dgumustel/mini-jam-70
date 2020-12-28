using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonController : MonoBehaviour
{
    private GameManager gameManager;
    private GameObject player;
    private GameObject imp;
    //public Transform parent;
    public bool isOnPlayer = false;
    public PlayerController1 playerController;
    public bool isOnImp = false;
    public ImpController impController;
    public Animation anim;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController1>();
        player = GameObject.Find("Player");
        //imp = GameObject.Find("Imp");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isOnImp && imp == null)
        {
            Destroy(gameObject);
        }
        else if (isOnImp)
        {
            MovePerson(imp, 1f);
        }
        else if (isOnPlayer)
        {
            MovePerson(player, 1f);
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && playerController.count < 3)
        {
            isOnPlayer = true;
            isOnImp = false;
            playerController.count += 1;
            Debug.Log("People on player = " + playerController.count);
        }
    } 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Heaven"))
        {
            Destroy(gameObject);
            gameManager.UpdateScore(5);
            playerController.count = 0;
            Debug.Log("People on player = " + playerController.count);
            playerController.hasPerson = false;
            //Debug.Log("# on player " + playerController.count);
        }
        
        else if (other.gameObject.tag.Equals("Hell"))
        {
            Destroy(gameObject);
            gameManager.UpdateScore(-5);
            //anim.Play();
            Debug.Log("soul lost to hell");
        }
        
        else if (other.gameObject.tag.Equals("Imp"))
        {
            //transform.SetParent(other.transform);
            isOnImp = true;
            isOnPlayer = false;
            impController = other.GetComponent<ImpController>();
            impController.hasPerson = true;
            imp = other.gameObject;
            playerController.count -= 1;
            Debug.Log("People on player = " + playerController.count);
        }

    }

    private void MovePerson(GameObject vehicle, float offsetY)
    {

        transform.position = new Vector3(vehicle.transform.position.x, vehicle.transform.position.y + +offsetY, vehicle.transform.position.z);
    }

}
