using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleSpawner : MonoBehaviour
{   
    public GameObject person;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        StartCoroutine(SpawnPerson());
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.isGameActive)
        {
            StopAllCoroutines();
        }
    }

    IEnumerator SpawnPerson()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);

            Instantiate(person, RandomSpawnPos(), transform.rotation);
            Debug.Log(Time.time);
            yield return null;
        }
    }
    Vector2 RandomSpawnPos()
    {
        float randomXPos = Random.Range(-8, 4);
        return new Vector2(randomXPos, 5);
    }


}
