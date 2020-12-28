using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Caught a gold soul!");
            Destroy(gameObject);
            DestroyAllImps();
        }
    }

    private void DestroyAllImps()
    {
        GameObject[] imps = GameObject.FindGameObjectsWithTag("Imp");
        foreach (GameObject imp in imps)
        {
            Destroy(imp);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Hell"))
        {
            Destroy(gameObject);
        }
    }

}
