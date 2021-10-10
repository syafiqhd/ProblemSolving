using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject item;
    public int maxItem;
    private int itemCount = 0; 

    void Start()
    {
        StartCoroutine(Spawn());
    }

    void Update()
    {
        if (itemCount > maxItem)
        {
            StopAllCoroutines();
        }
    }

    IEnumerator Spawn() 
    {
        while (true) 
        {
            yield return new WaitForSeconds(1);
            float randomX = Random.Range(-8, 8);
            float randomY = Random.Range(-3.5f, 3.5f);
            transform.position = new Vector3(randomX, randomY);

            Instantiate(item, transform.position, Quaternion.identity);
            itemCount++;
        }
    }
}
