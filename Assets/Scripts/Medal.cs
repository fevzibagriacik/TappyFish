using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Medal : MonoBehaviour
{
    public Sprite metal, bronze, silver, gold;
    Image img;
    int gameScore;
    void Start()
    {
        img = GetComponent<Image>();
    }

    void Update()
    {
        MedalControl();
    }

    void MedalControl()
    {
        gameScore = GameManager.gameScore;

        if(gameScore <= 8 && gameScore  >= 0)
        {
            img.sprite = metal;
        }
        else if(gameScore <= 16 &&  gameScore > 8)
        {
            img.sprite = bronze;
        }
        else if(gameScore <= 24 && gameScore > 16) 
        {
            img.sprite = silver;
        }
        else if(gameScore > 24)
        {
            img.sprite = gold;
        }
    }
}
