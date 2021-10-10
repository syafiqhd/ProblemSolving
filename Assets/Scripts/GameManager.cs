using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject item;
    public float timeSpawn;
    public int maxItem;
    public Text scoreText;
    public Text win;
    public Text lose;
    public GameObject menu;
    public static int itemCount;
    public static int score = 50;
    public int duration;
    public Text timeText;
    private float time;

    void Start()
    {
        StartCoroutine(Spawn(timeSpawn));
    }

    void Update()
    {
        scoreText.text = "Score : " + score;

        if (score > 50)
        {
            scoreText.color = Color.green;
        }
        else 
        {
            scoreText.color = Color.red;
        }

        TimerCount();
        GameOver();

        if (Input.GetKeyDown(KeyCode.R)) 
        {
            Restart();
        }
    }

    IEnumerator Spawn(float sec) 
    {
        while (true)
        {
            yield return new WaitForSeconds(sec);
            float randomX = Random.Range(-8, 8);
            float randomY = Random.Range(-3.5f, 3.5f);
            transform.position = new Vector3(randomX, randomY);

            if (itemCount < maxItem)
            {
                Instantiate(item, transform.position, Quaternion.identity);
                itemCount++;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player")) 
        {
            float randomX = Random.Range(-8, 8);
            float randomY = Random.Range(-3.5f, 3.5f);
            transform.position = new Vector3(randomX, randomY);
        }
    }

    void TimerCount()
    {
        time += Time.deltaTime;

        timeText.text = GetTimeString(GetRemainingTime() + 1);
    }

    public float GetRemainingTime()
    {
        return duration - time;
    }

    private string GetTimeString(float timeRemaining)
    {
        int minute = Mathf.FloorToInt(timeRemaining / 60);
        int second = Mathf.FloorToInt(timeRemaining % 60);

        return string.Format("{0} : {1}", minute.ToString(), second.ToString());
    }

    void GameOver() 
    {
        if (score >= 100)
        {
            win.gameObject.SetActive(true);
            menu.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else if (score <= 0) 
        {
            lose.gameObject.SetActive(true);
            menu.gameObject.SetActive(true);
            Time.timeScale = 0;
        }

        if (time > duration)
        {
            if (score > 50)
            {
                win.gameObject.SetActive(true);
                menu.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
            else 
            {
                lose.gameObject.SetActive(true);
                menu.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void Restart() 
    {
        Time.timeScale = 1;
        score = 50;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
