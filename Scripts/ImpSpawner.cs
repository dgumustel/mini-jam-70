using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpSpawner : MonoBehaviour
{
    public GameObject imp;
    private GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnImp());
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.isGameActive)
        {
            StopAllCoroutines();
        }
    }

    IEnumerator SpawnImp()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);

            Instantiate(imp, RandomSpawnPos(), transform.rotation);
            Debug.Log(Time.time);
            yield return null;
        }
    }

    Vector2 RandomSpawnPos()
    {
        float randomXPos = Random.Range(-8, 4);
        return new Vector2(randomXPos, -5);
    }

}
