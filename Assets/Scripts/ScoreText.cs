using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    private int score;
    private int bestScore;
    private TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
    }

    public void OnCubeSpawned()
    {
        score++;
        text.text = score.ToString();
    }
}
