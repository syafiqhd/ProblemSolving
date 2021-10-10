using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject item;
    public float timeSpawn;
    public int maxItem;
    public Text scoreText;
    public static int itemCount;
    public static int score;

    void Start()
    {
        StartCoroutine(Spawn(timeSpawn));
    }

    void Update()
    {
        scoreText.text = "Score " + score;
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
}
