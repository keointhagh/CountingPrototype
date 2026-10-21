using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    //public Text CounterText;
    public int boxValue;
    private GameManager gameManager;

    private int count = 0;

    private void Start()
    {
        count = 0;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        count += 1;
        //CounterText.text = "Count : " + count;
        gameManager.UpdateScore(boxValue);
    }

    public int returnTotalValue()
    {
        return boxValue * count;
    }
}
