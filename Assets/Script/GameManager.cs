using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public float score;
    public Text scoreText;
    void Start()
    {
        scoreText.text = score.ToString();
    }

    public void AddScore(float addedScore){
        score += addedScore;
        scoreText.text = "" + (int)score;
    }

    public void ResetScore(){
        score = 0;
        scoreText.text = "" + (int)score;
    }
}
