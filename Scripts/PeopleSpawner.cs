using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleSpawner : MonoBehaviour
{   
    public GameObject person;
    Vector2 personPos;

    // Start is called before the first frame update
    void Start()
    {
        personPos = new Vector2(0, 0);
        StartCoroutine(SpawnPerson());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnPerson()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);

            Instantiate(person, RandomSpawnPos(), transform.rotation);
            
            yield return null;
        }
    }

    Vector2 RandomSpawnPos()
    {
        float randomXPos = Random.Range(-8, 4);
        return new Vector2(randomXPos, 5);
    }
}
