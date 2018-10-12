using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Juda Hensen
public class Score : MonoBehaviour
{

    private int _score = 0;
    public Text scoreField;


    private void Update()
    {
        scoreField.text = "score: " + _score;
    }

    // resets score on death
    public void ResetScore()
    {
        _score = 0;
    }


    // send current score
    public int GetScore()
    {
        return _score;
    }


    // set score to a specific amount
    public void SetScore(int score)
    {
        _score = score;
    }


    // add an amount to your current score
    public void AddScore(int amount)
    {
        _score += amount;
    }
}