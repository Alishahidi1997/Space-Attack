using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class ScoreBoard : MonoBehaviour
{
    int score = 0;
    TMP_Text scoreText; 
    // Start is called before the first frame update
    private void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = "Start";
    }
    public void UpdateScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
