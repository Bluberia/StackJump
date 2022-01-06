using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textScore;
    [SerializeField] private TextMeshProUGUI textBest;
    private int score = 0;
    
    // Display score
    private void Start() {
        textBest.text = "Best: " + PlayerPrefs.GetInt("BestScore").ToString();
    }

    // When a cube disappear, update the actual score
    public void OnCubeDisappear(int add)
    {
        score += add;
        textScore.text = score.ToString();
        if (score >= PlayerPrefs.GetInt("BestScore")) {
            PlayerPrefs.SetInt("BestScore", score);
        }
        textBest.text = "Best: " + PlayerPrefs.GetInt("BestScore").ToString();
    }
}
