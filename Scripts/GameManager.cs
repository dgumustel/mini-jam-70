using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score;
    public GameObject goldSoul;
    public TextMeshProUGUI gameOverText;
    public bool isGameActive;
    public TextMeshProUGUI timerText;
    public float timeLeft;
    public Button restartButton;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScore(0);
        StartCoroutine(SpawnGoldSoul());
        isGameActive = true;
        timeLeft = 120;
        //gameOverText.gameObject.SetActive(false);
        //restartButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.RoundToInt(timeLeft);
        }

        if (timeLeft <= 0)
        {
            timerText.text = "Time has run out!";
            StopAllCoroutines();
            isGameActive = false;
            gameOverText.text = "Game Over!";
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
        }
    }


    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
    Vector2 RandomSpawnPos()
    {
        float randomXPos = Random.Range(-8, 4);
        return new Vector2(randomXPos, 5);
    }

    IEnumerator SpawnGoldSoul()
    {
        while (true)
        {
            yield return new WaitForSeconds(6);

            Instantiate(goldSoul, RandomSpawnPos(), transform.rotation);
            Debug.Log(Time.time);
            yield return null;
        }
    }

    public void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
