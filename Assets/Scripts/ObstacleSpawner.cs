using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstacle;
    public float maxTime;
    float timer;
    public float maxY;
    public float minY;
    float randomY;
    void Update()
    {
        Timer();
    }

    public void InstantiateObstacle()
    {
            GameObject newObstacle = Instantiate(obstacle);
            newObstacle.transform.position = new Vector2(transform.position.x, randomY);
    }

    void Timer()
    {
        if(GameManager.gameOver == false && GameManager.gameStarted == true)
        {
            timer += Time.deltaTime;

            if(timer >= maxTime)
            {
                randomY = Random.Range(minY, maxY);
                InstantiateObstacle();
                timer = 0;
            }
        }  
    }
}
